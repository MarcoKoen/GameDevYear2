/* Program name: starter-code
   Project file name: Rotate.cs
   Author:
   Date:
   Language:C#
   Platform:
   Purpose:
   Description: Controls rotation of heart
   Known Bugs: 
   Additional Features: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
