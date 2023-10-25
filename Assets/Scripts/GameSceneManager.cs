using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Last loaded scene: 1 - game scene
    private void OnDestroy()
    {
        GameManager.instance.previousScene = 1;
    }
}
