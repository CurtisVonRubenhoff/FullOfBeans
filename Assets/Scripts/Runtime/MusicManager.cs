using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class MusicManager : Singleton<MusicManager>
    {
        // Dictionary to store AudioSources with audio clips as keys
        private Dictionary<AudioClip, AudioSource> audioSources = new Dictionary<AudioClip, AudioSource>();

        // Crossfade duration in seconds
        public float crossfadeDuration = 2f;

        // Public method to initiate crossfade to a new audio clip
        public void CrossfadeToClip(AudioClip newClip)
        {
            // If the new audio clip is already playing, do nothing
            if (IsClipPlaying(newClip))
            {
                return;
            }

            // Spawn a new AudioSource if it doesn't exist for the new audio clip
            if (!audioSources.ContainsKey(newClip))
            {
                AudioSource newSource = gameObject.AddComponent<AudioSource>();
                newSource.clip = newClip;
                audioSources.Add(newClip, newSource);
            }

            // Crossfade the currently playing track to the new one
            foreach (var kvp in audioSources)
            {
                AudioClip clip = kvp.Key;
                AudioSource source = kvp.Value;

                if (clip == newClip)
                {
                    // Play the new audio clip
                    source.Play();
                    source.volume = 0f; // Start with volume at 0
                    StartCoroutine(CrossfadeCoroutine(source, 0f, 1f, crossfadeDuration));
                }
                else
                {
                    // Fade out the currently playing track
                    StartCoroutine(CrossfadeCoroutine(source, source.volume, 0f, crossfadeDuration));
                }
            }
        }

        // Coroutine for crossfading
        private System.Collections.IEnumerator CrossfadeCoroutine(AudioSource source, float startVolume,
            float endVolume, float duration)
        {
            float currentTime = 0f;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                source.volume = Mathf.Lerp(startVolume, endVolume, currentTime / duration);
                yield return null;
            }

            source.volume = endVolume;

            // If the volume is 0, stop the AudioSource
            if (endVolume == 0f)
            {
                source.Stop();
            }
        }

        // Check if a specific audio clip is currently playing
        private bool IsClipPlaying(AudioClip clip)
        {
            if (audioSources.ContainsKey(clip))
            {
                return audioSources[clip].isPlaying;
            }

            return false;
        }
    }
}