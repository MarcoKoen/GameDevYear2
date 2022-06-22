/* Program name: starter-code
   Project file name: ChangeColorOnMouseOver.cs
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
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;
    public Color normalColor;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }
}
