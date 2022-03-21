using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public Text highScore;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;


    // Start is called before the first frame update
    void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

    }

    public void SavedSheep() 
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
        PlayerPrefs.SetInt("HighScore", sheepSaved);
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
}
