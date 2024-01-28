using CleverCrow.Fluid.Dialogues.Actions;
using CleverCrow.Fluid.Dialogues;
using ScriptableObjectArchitecture;

using UnityEngine;

namespace Runtime
{
    [CreateMenu("SetMusic")]

    public class SetMusicAction: ActionDataBase
    {

        public AudioClipGameEvent audioEvent;
        public AudioClip clip;
        public override void OnInit (IDialogueController dialogue) {
            // Run the first time the action is triggered
        }

        public override void OnStart () {
            // Runs when the action begins triggering
            audioEvent.Raise(clip);
        }

        public override ActionStatus OnUpdate () {
            // Runs when the action begins triggering

            // Return continue to span multiple frames
            return ActionStatus.Success;
        }

        public override void OnExit () {
            // Runs when the actions `OnUpdate()` returns `ActionStatus.Success`
        }

        public override void OnReset () {
            // Runs after a node has fully run through the start, update, and exit cycle
        }
    }
}