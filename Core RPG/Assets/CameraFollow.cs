using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // == Constants ==
    private const string PLAYER = "Player";

    GameObject Player;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(PLAYER);
        Debug.Log("Found player!");
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position;
    }


}
