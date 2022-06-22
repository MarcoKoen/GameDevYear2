/* Program name: Tower Defence
   Project file name: Tutorial.cs
   Author:
   Date:
   Language: C#
   Platform:
   Purpose:
   Description: Displays the tutorial.
   Known Bugs:
   Additional Features: 
*/

using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{

    public void DisplayTutorial()
    {
        gameObject.GetComponent<Animator>().SetTrigger("displayTutorial");
    }

}
