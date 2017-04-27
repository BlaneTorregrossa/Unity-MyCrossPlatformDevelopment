using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{

    public GenerateGraph generateGraph;
    public GameObject textObject;
    public GameObject RoomInfo;



    void displayRoom()
    {
        textObject.GetComponent<TextMesh>().text = "Player Current position is: " + generateGraph.PlayerVec.ToString();
    }

    // Needs Work
    void displayInfo()
    {
        RoomInfo.GetComponent<TextMesh>().text = "Information about the current room"; 
    }

	void Start ()
    {
        displayRoom();
        displayInfo();
    }
	
	void Update ()
    {
        displayRoom();
	}
}
