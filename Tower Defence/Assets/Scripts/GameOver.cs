/* Program name: Tower Defence
   Project file name: GameOver.cs
   Author:
   Date:
   Language: C#
   Platform:
   Purpose:
   Description: Loads the gameover scene.
   Known Bugs:
   Additional Features: 
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
