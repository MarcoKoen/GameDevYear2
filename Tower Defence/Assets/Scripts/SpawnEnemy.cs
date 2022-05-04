using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    public List<GameObject> enemiesList;

    public GameObject testEnemyPrefab;
    private GameManagerBehaviour gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();

        enemiesList = new List<GameObject>(Resources.LoadAll<GameObject>("Enemy"));
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || (enemiesSpawned != 0 && timeInterval > spawnInterval)) &&
            (enemiesSpawned < waves[currentWave].maxEnemies))
            {
                lastSpawnTime = Time.time;

                if (currentWave > 0)
                {
                    int indexOfList = Random.Range(0, 2);
                    Debug.Log(indexOfList);
                    
                    GameObject newEnemy = (GameObject)Instantiate(enemiesList[indexOfList]);
                    newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                }
                else
                {
                    GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                }
                Debug.Log(currentWave);
                enemiesSpawned++;

            }
            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }
}
