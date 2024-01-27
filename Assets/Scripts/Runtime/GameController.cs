using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
