using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public GenerateGraph GraphRef;
    public GameObject MainBackground;
    public GameObject MapBackground;
    public GameObject Player;
    public Text Player_Pos;

    private Vector3 MostRecentPos;
    private Vector2 PlayerVecDup;
    private string FailText = " ";
    private string WinText = " ";
    private Vector3 PlayerOrgion = new Vector3(87.7f, -11.73f, -0.01f);

    // If M is pressed switches to Map Camera and if T is Pressed switches to Main Camera
    void MapSwitch()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MapBackground.SetActive(true);
            MainBackground.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            MapBackground.SetActive(false);
            MainBackground.SetActive(true);
        }
    }

    // Checks if Player is in right spot to activate win condition
    void WinCheck()
    {
        if (GraphRef.PlayerVec == GraphRef.goal)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WinText = "You made it out!, You Win!!!";
                Debug.Log("Win!", MainBackground);
                GraphRef.PlayerVec = new Vector2(0, 0);
                Player.transform.position = PlayerOrgion;
                GraphRef.DecideGoal();
            }
    }

    // Player Movement along the graph (includes the given visual)
    void Movement()
    {
        //up
        if (Input.GetKeyDown(KeyCode.W))
            if (Player.transform.position.y >= 12.2f)
            {
                Player.transform.position = PlayerOrgion;
                GraphRef.PlayerVec = new Vector2(0, 0);
                FailText = "You went off the map so you lose!";
                WinText = " ";
            }
            else
            {
                GraphRef.PlayerVec += new Vector2(0, 1);
                MostRecentPos = Player.transform.position;
                Player.transform.position += new Vector3(0, 6, 0);
                Debug.Log(GraphRef.PlayerVec.ToString(), GraphRef);
                Debug.Log(Player.transform.position.ToString(), Player);
                MostRecentPos = Player.transform.position;
                FailText = " ";
                WinText = " ";
            }

        //down
        if (Input.GetKeyDown(KeyCode.S))
            if (Player.transform.position.y <= -11.7f)
            {
                Player.transform.position = PlayerOrgion;
                GraphRef.PlayerVec = new Vector2(0, 0);
                FailText = "You went off the map so you lose!";
                WinText = " ";
            }
            else
            {
                GraphRef.PlayerVec -= new Vector2(0, 1);
                MostRecentPos = Player.transform.position;
                Player.transform.position -= new Vector3(0, 6, 0);
                Debug.Log(GraphRef.PlayerVec.ToString(), GraphRef);
                Debug.Log(Player.transform.position.ToString(), Player);
                MostRecentPos = Player.transform.position;
                FailText = " ";
                WinText = " ";
            }

        //right
        if (Input.GetKeyDown(KeyCode.D))
            if (Player.transform.position.x >= 111.7f)
            {
                Player.transform.position = PlayerOrgion;
                GraphRef.PlayerVec = new Vector2(0, 0);
                FailText = "You went off the map so you lose!";
                WinText = " ";
            }
            else
            {
                GraphRef.PlayerVec += new Vector2(1, 0);
                MostRecentPos = Player.transform.position;
                Player.transform.position += new Vector3(6, 0, 0);
                Debug.Log(GraphRef.PlayerVec.ToString(), GraphRef);
                Debug.Log(Player.transform.position.ToString(), Player);
                MostRecentPos = Player.transform.position;
                FailText = " ";
                WinText = " ";
            }

        //left
        if (Input.GetKeyDown(KeyCode.A))
            if (Player.transform.position.x <= 87.7f)
            {
                Player.transform.position = PlayerOrgion;
                GraphRef.PlayerVec = new Vector2(0, 0);
                FailText = "You went off the map so you lose!";
                WinText = " ";
            }
            else
            {
                GraphRef.PlayerVec -= new Vector2(1, 0);
                MostRecentPos = Player.transform.position;
                Player.transform.position -= new Vector3(6, 0, 0);
                Debug.Log(GraphRef.PlayerVec.ToString(), GraphRef);
                Debug.Log(Player.transform.position.ToString(), Player);
                MostRecentPos = Player.transform.position;
                FailText = " ";
                WinText = " ";
            }
    }

    void Start()
    {
        MapBackground.SetActive(false);
        MainBackground.SetActive(true);
    }

    void Update()
    {
        MapSwitch();
        Movement();
        WinCheck();
        // Text Displayed that is to be changed with given information.
        Player_Pos.text = "Your position is: (" + GraphRef.PlayerVec.x.ToString() + ", " + GraphRef.PlayerVec.y.ToString() + ") \n"
                            + FailText + WinText;
    }
}
