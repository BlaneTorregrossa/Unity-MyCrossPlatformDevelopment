using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGraph : MonoBehaviour
{

    public Vector2 Graph;
    public List<Vector2> Nodes = new List<Vector2>();
    public Vector2 PlayerVec;
    public Vector2 goal;
    public GameObject NodePrefab;

    private Vector3 NewNodePos = new Vector3(0, 0, 0);
    private int xCounter = 0;
    private int GoalPlacement = 0;

    // Creates Graph 
    void GenGraph()
    {
        if (Graph.x >= 5 || Graph.y >= 5)
        {
            xCounter = 0;
        }

        else
        {
            while (Graph.x != xCounter)
            {
                Nodes.Add(Graph);
            }
            while (Graph.x == xCounter)
            {
                Nodes.Add(Graph);
                Graph.y++;
                NewNodePos += new Vector3(0, 0, 1);
                Instantiate(NodePrefab).transform.position = NewNodePos;
                if (Graph.y >= 5)
                {

                    NewNodePos.x += 1;
                    NewNodePos.z = 0;
                    Graph.y = 0;
                    Graph.x++;
                    xCounter++;
                    GenGraph();
                }
            }
        }
    }


    public void DecideGoal()
    {
        GoalPlacement = Random.Range(1, 4);
        if (GoalPlacement == 1)
            goal = new Vector2(0, 3);
        if (GoalPlacement == 2)
            goal = new Vector3(2, 1);
        if (GoalPlacement == 3)
            goal = new Vector3(4, 4);
    }

    void Start()
    {
        Graph.x = 0;
        Graph.y = 0;
        GenGraph();
        DecideGoal();
    }

    void Update()
    {

    }
}
