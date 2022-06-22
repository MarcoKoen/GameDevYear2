/* Program name: starter-code
   Project file name: DestroyOnTrigger.cs
   Author:
   Date:
   Language:C#
   Platform:
   Purpose:
   Description: Destroys sheep on collision with hay
   Known Bugs: 
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagFilter)) 
        {
            Destroy(gameObject);
        }
    }
}
