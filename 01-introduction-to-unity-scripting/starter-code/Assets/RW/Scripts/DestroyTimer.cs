/* Program name: starter-code
   Project file name: DestroyTimer.cs
   Author:
   Date:
   Language:C#
   Platform:
   Purpose:
   Description: Destroys timer.
   Known Bugs: 
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
