﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using CleverCrow.Fluid.Dialogues;
using CleverCrow.Fluid.Dialogues.Graphs;
using CleverCrow.Fluid.Databases;
using TMPro;
using CleverCrow.Fluid.Utilities;

namespace Runtime
{
    public class DialogController : MonoBehaviour
    {
        private DialogueController _ctrl;

        public DialogueGraph dialogue;


        [Header("Graphics")] public GameObject speakerContainer;
        public Image portrait;
        public TMP_Text lines;
        public TMP_Text speakerName;


        public RectTransform choiceList;
        [SerializeField] private ChoiceButton choicePrefab;

        public GameObjectOverride[] gameObjectOverrides;


        private void Awake()
        {
            var database = new DatabaseInstanceExtended();
            _ctrl = new DialogueController(database);

            // @NOTE If you don't need audio just call _ctrl.Events.Speak((actor, text) => {}) instead
            _ctrl.Events.Speak.AddListener((actor, text) =>
            {
                speakerContainer.SetActive(true);
                ClearChoices();
                //portrait.sprite = actor.Portrait;
                lines.text = text;
                if (actor != null) speakerName.text = actor.DisplayName;
                else speakerName.text = "";
                StartCoroutine(NextDialogue());
            });

            _ctrl.Events.Choice.AddListener((actor, text, choices) =>
            {
                ClearChoices();
                speakerContainer.SetActive(true);
                //portrait.sprite = actor.Portrait;
                lines.text = text;
                if (actor != null) speakerName.text = actor.DisplayName;
                else speakerName.text = "";
                choices.ForEach(c =>
                {
                    var choice = Instantiate(choicePrefab, choiceList);
                    choice.title.text = $"[ {c.Text}";
                    choice.clickEvent.AddListener(_ctrl.SelectChoice);
                });
            });

            _ctrl.Events.End.AddListener(() => { speakerContainer.SetActive(false); });

            _ctrl.Events.NodeEnter.AddListener((node) =>
            {
                Debug.Log($"Node Enter: {node.GetType()} - {node.UniqueId}");
            });


            //_dialogueEvent.AddListener(StartDialogue);
            //_ctrl.Events.End.Invoke();
            
            StartDialogue(dialogue);
        }

        private void ClearChoices()
        {
            if (!choiceList) return;
            foreach (Transform child in choiceList)
            {
                Destroy(child.gameObject);
            }
        }

        private IEnumerator NextDialogue()
        {
            yield return null;

            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }

            _ctrl.Next();
        }

        public void StopDialog()
        {
            //_ctrl.Stop();
        }

        private void StartDialogue(DialogueGraph i_dialogue)
        {
            dialogue = i_dialogue;
            _ctrl.Play(dialogue, gameObjectOverrides.ToArray<IGameObjectOverride>());
        }

        private void Update()
        {
            // Required to run actions that may span multiple frames
            _ctrl.Tick();
        }

        public void PlayDialog(DialogueGraph i_dialog)
        {
            _ctrl.Play(i_dialog, gameObjectOverrides.ToArray<IGameObjectOverride>());
        }
    }
}