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

    public int goalRow { get; private set; }
    public int goalCol { get; private set; }

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
        Debug.Log("Player x" + Convert.ToInt32(aIController.Player.transform.position.x));
        Debug.Log("Player y" + Convert.ToInt32(aIController.Player.transform.position.y));
        Debug.Log("col" + goalCol);
        Debug.Log("row" + goalRow);

        //List<Node> pathCube = aIController.FindPath(aIController.Player.transform.position.x)
        if (Input.GetKeyDown("f"))
        {
           
            
            //List<Node> pathCube = aIController.FindPath(Convert.ToInt32(playerPrefab.transform.position.x),Convert.ToInt32(playerPrefab.transform.position.y), goalCol, goalRow);

            //GameObject pathCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //for (int i = 0; i < pathCube.Count; i++)
            //{
            //    GameObject pathCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //    pathCube1.transform.position = new Vector3();

            //}
            //foreach (var x in pathCube)
            //{
            //    Debug.Log(x.ToString());
            //}



        }
        //Debug.Log(pathCube.Count);
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