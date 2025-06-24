using System;
using TMPro;
using UnityEngine;

public class ButtonScaler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI childText;

    [SerializeField]
    private RectTransform myRectTransform;

    private void Start()
    {
        childText =  GetComponentInChildren<TextMeshProUGUI>();
        myRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float initialScaleYVal = myRectTransform.sizeDelta.y;
        float newX = (7.5f * childText.text.Length) + 50;
        myRectTransform.sizeDelta = new Vector2(newX, initialScaleYVal);
    }
}
