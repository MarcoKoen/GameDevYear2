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
        //Debug.Log("Player x" + Convert.ToInt32(aIController.Player.transform.position.x));
        //Debug.Log("Player y" + Convert.ToInt32(aIController.Player.transform.position.y));
        int goalRow = constructor.goalRow;
        int goalCol = constructor.goalCol;
        //Debug.Log("Goal Row = " + goalRow);
        //Debug.Log("Goal col = " + goalCol);
        float myFloat = (float)aIController.Player.transform.position.x;
        float playerZ = (float)aIController.Player.transform.position.z;
        int myInt = (int)myFloat;
        float size = (float)3.75;

        int playerRow = (int)Mathf.Round(myFloat / size);
        int playerCol = (int)Mathf.Round(playerZ / size);

        if (Input.GetKeyDown("f"))
        {
            List<Node> pathCube = aIController.FindPath(playerRow, playerCol, goalRow, goalCol);
            for (int i = 0; i < pathCube.Count; i++)
            {
                Debug.Log("Pathcube x " + pathCube[i].x);
                Debug.Log("Pathcube y " + pathCube[i].y);
                GameObject pathCube1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pathCube1.transform.position = new Vector3((int)Mathf.Round(pathCube[i].y * size), 1, (int)Mathf.Round(pathCube[i].x * size));
                //Destroy(pathCube1);

            }
            Debug.Log("Count " + pathCube.Count);
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