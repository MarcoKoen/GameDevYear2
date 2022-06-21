/* Program name: Maze Generation
   Project file name: GameController.cs
   Author: Marco Koen
   Date: 20/06/2022
   Language: C#
   Platform: Windows
   Purpose: To control the main operations of the game
   Description: Creates most of the prefabs and visuals for the game, responsible for triggers between different prefabs.
   Known Bugs:
   Additional Features:Able to use methods for other uses for example finding the path to the treasure.
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    private MazeConstructor constructor;
    public GameObject playerPrefab;
    public GameObject monsterPrefab;
    GameObject pathCube1;
    private AIController aIController;

    [SerializeField] private int rows;
    [SerializeField] private int cols;

    public int[,] data
    {
        get; private set;
    }

    void Awake()
    {
        constructor = GetComponent<MazeConstructor>();
        aIController = GetComponent<AIController>();
    }

    void Start()
    {
        constructor.GenerateNewMaze(rows, cols, OnTreasureTrigger);

        aIController.Graph = constructor.graph;
        aIController.Player = CreatePlayer();
        aIController.Monster = CreateMonster();
        aIController.HallWidth = constructor.hallWidth;
        aIController.StartAI();
    }

    void Update()
    {
        int goalRow = constructor.goalRow;
        int goalCol = constructor.goalCol;
        int playerCol = (int)Mathf.Round(aIController.Player.transform.position.x / constructor.hallWidth);
        int playerRow = (int)Mathf.Round(aIController.Player.transform.position.z / constructor.hallWidth);
        float size = (float)3.75;

        if (Input.GetKeyDown("f")) 
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("pathCube1"); //creates an array of objects with the pathcube1 tag
            foreach (GameObject go in objects)
            {
                Destroy(go); //destroys each gamecube
            }

            List<Node> pathSphere = aIController.FindPath(playerRow, playerCol, goalRow, goalCol); //creates a list of node called pathCube, which is the path to the goal
            for (int i = 0; i < pathSphere.Count; i++) //iterates through the list and creates a sphere where the node is/
            {
                GameObject pathPhereObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pathPhereObject.tag = "pathCube1"; 
                pathPhereObject.GetComponent<SphereCollider>().enabled = false; //makes the sphere collider disabled
                pathPhereObject.transform.position = new Vector3((int)Mathf.Round(pathSphere[i].y * size), 1, (int)Mathf.Round(pathSphere[i].x * size));
            }
        }
    }

    private GameObject CreatePlayer()
    {
        Vector3 playerStartPosition = new Vector3(constructor.hallWidth, 1, constructor.hallWidth);
        GameObject player = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player.tag = "Generated";

        return player;
    }

    private GameObject CreateMonster()
    {
        Vector3 monsterPosition = new Vector3(constructor.goalCol * constructor.hallWidth, 0f, constructor.goalRow * constructor.hallWidth);
        GameObject monster = Instantiate(monsterPrefab, monsterPosition, Quaternion.identity);
        monster.tag = "Generated";

        return monster;
    }

    private void OnTreasureTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("You Won!");
        aIController.StopAI();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision has occured");
        }
    }
}