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

    [SerializeField] private SpriteRenderer _backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"{DataBus.Get<PlayerProfile>("PlayerProfile").firstName}");
        
        //DataBus.AddListener("CurrentRoom", HandleRoomChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleRoomChange(string roomName)
    {
        var newRoom = _rooms.Find((room) => room.RoomName == roomName);
        
        _backgroundRenderer.sprite = newRoom.Background;
        
    }
}
