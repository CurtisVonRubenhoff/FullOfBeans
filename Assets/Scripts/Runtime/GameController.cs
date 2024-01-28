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
    [SerializeField] private DialogController _dc;

    [SerializeField] private SpriteRenderer _backgroundRenderer;
    
    public List<BeanController> beans = new();


    private RoomData currentRoom;

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
        
        //_dc.StopDialog();
        
        _backgroundRenderer.sprite = newRoom.Background;
        currentRoom = newRoom;

  
        foreach (var beanController in beans)
        {
            beanController.gameObject.SetActive(roomName == "CampusMap");
        }

        StartCoroutine(RunRoomRoutine());
        //_dc.PlayDialog(newRoom.RoomDialogTree);

    }

    private IEnumerator RunRoomRoutine()
    {
        
        yield return new WaitForSeconds(1);
        _dc.PlayDialog(currentRoom.RoomDialogTree);
    }
}
