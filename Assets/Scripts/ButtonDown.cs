using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDown : MonoBehaviour
{
    Vector2 initialPos;

    RectTransform rectTransform;

    [SerializeField] GameObject shadeImage;


    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        initialPos = rectTransform.position;
    }

    private void OnMouseDrag()
    {
        //rectTransform.position = new Vector2(initialPos.x, initialPos.y - 15);
        rectTransform.position = new Vector2(shadeImage.transform.position.x, shadeImage.transform.position.y);
    }

    private void OnMouseUp()
    {
        rectTransform.position = initialPos;
    }
}
