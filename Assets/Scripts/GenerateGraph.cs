using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGraph : MonoBehaviour
{

    public Vector2 Graph;
    private int xCounter = 0;
    public List<Vector2> Nodes = new List<Vector2>();
    public Vector2 PlayerVec;
    public Vector2 goal;

    // Creates Graph 
    void genGraph()
    {
        if (Graph.x >= 5 || Graph.y >= 5)
        {
            xCounter = 0;
        }

        else
        {
            while (Graph.x != xCounter)
            {
                Nodes.Add(Graph);                               // Adds current vector named Graph to Nodes List
            }
            while (Graph.x == xCounter)
            {
                Nodes.Add(Graph);                               // Adds current vector named Graph to Nodes List
                Graph.y++;
                if (Graph.y >= 5)
                {
                    Graph.y = 0;
                    Graph.x++;
                    xCounter++;
                    genGraph();
                }
            }
        }
    }


    void Start()
    {
        Graph.x = 0;
        Graph.y = 0;
        PlayerVec.x = 0;
        genGraph();
        
    }

    void Update()
    {

    }
}
