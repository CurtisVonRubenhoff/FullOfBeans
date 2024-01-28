using System.Collections;
using System.Collections.Generic;
using CleverCrow.Fluid.Dialogues;
using CleverCrow.Fluid.Dialogues.Graphs;
using Runtime;
using UnityEngine;

[System.Serializable]
public class RoomData 
{
    public string RoomName;
    public Sprite Background;
    public DialogueGraph RoomDialogTree;
    public List<ActorDefinition> Characters;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private List<RoomData> _rooms;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{DataBus.Get<PlayerProfile>("PlayerProfile").firstName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
