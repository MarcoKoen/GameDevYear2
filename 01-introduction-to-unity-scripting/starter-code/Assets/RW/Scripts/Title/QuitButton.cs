/* Program name: starter-code
   Project file name: QuitButton.cs
   Author:
   Date:
   Language:C#
   Platform:
   Purpose:
   Description: Quits application on quit button click.
   Known Bugs: 
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
