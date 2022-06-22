
/* Program name: starter-code
   Project file name: StartButton.cs
   Author:
   Date:
   Language:C#
   Platform:
   Purpose:
   Description: Handles the start button loading the game.
   Known Bugs: 
   Additional Features: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game");
    }
}
