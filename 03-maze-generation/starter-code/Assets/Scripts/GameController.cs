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
            GameObject[] objects = GameObject.FindGameObjectsWithTag("pathCube1");
            foreach (GameObject go in objects)
            {
                Destroy(go);
            }

            List<Node> pathCube = aIController.FindPath(playerRow, playerCol, goalRow, goalCol);
            for (int i = 0; i < pathCube.Count; i++)
            {
                GameObject pathCube1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pathCube1.tag = "pathCube1";
                pathCube1.GetComponent<SphereCollider>().enabled = false;
                pathCube1.transform.position = new Vector3((int)Mathf.Round(pathCube[i].y * size), 1, (int)Mathf.Round(pathCube[i].x * size));
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