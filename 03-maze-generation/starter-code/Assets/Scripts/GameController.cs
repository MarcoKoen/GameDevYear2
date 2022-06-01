using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    private MazeConstructor constructor;
    public GameObject playerPrefab;

    [SerializeField] private int rows;
    [SerializeField] private int cols;

    void Awake()
    {
        constructor = GetComponent<MazeConstructor>();
    }

    void Start()
    {
        constructor.GenerateNewMaze(rows, cols);

        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Vector3 playerStartPosition = new Vector3(constructor.hallWidth, 1, constructor.hallWidth);
        GameObject player = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player.tag = "Generated";
    }
}