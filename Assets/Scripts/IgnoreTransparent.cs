using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IgnoreTransparent :
    MonoBehaviour,
    IPointerClickHandler
{
    private void Awake()
    {
        var image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 1;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ƒNƒŠƒbƒN‚³‚ê‚½");
    }
}