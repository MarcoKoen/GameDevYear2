using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject testEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(testEnemyPrefab.name);
        Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
        Debug.Log(testEnemyPrefab.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
