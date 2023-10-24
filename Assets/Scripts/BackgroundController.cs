using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerr : MonoBehaviour {

    public Transform Player;
    public int offsetY = 10;

    void Update() {
        //Moves background together with the player. X is not changing
        //Offset scales the difference of the transform points

        Vector2 pos = new Vector2(transform.position.x, Player.position.y + offsetY);
        transform.position = pos;
    }
}