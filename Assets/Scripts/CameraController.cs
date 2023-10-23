using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Player;
    public int offsetY = 3;

    void Start()
    {
        
    }

    void Update() {

        //Moves camera up and down with the player. X and Z are not changing
        //Offset on Y used for camera being slightly higher - player not in the middle of a screen - can predict jumping

        Vector3 pos = new Vector3(transform.position.x, Player.position.y + offsetY, transform.position.z);
        transform.position = pos;
    }
}
