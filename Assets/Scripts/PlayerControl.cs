using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GenerateGraph GraphRef;
    public GameObject Player;
    public GameObject MainBackground;
    public GameObject MapBackground;

    void MapSwitch()
    {
        if (Input.GetKeyDown(KeyCode.M))
            if (MapBackground.activeSelf == false)
            {
                MapBackground.SetActive(true);
                MainBackground.SetActive(false);
            }
            else if (MapBackground.activeSelf == true)
            {
                MapBackground.SetActive(false);
                MainBackground.SetActive(true);
            }
    }

    // Needs Work
    void Movement()
    {
    
    }

    void Start()
    {
        MapBackground.SetActive(false);
    }

    void Update()
    {
        MapSwitch();
        Movement();
    }
}
