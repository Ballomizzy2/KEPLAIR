using System;
using UnityEngine;
using UnityEngine.UI;

public class BrowserController : MonoBehaviour
{
    WebViewObject webViewObject;
    [SerializeField] private InputField offset;

    private void Start()
    {
        webViewObject = GetComponent<WebViewObject>();
        offset.text = webViewObject.offset.ToString();
    }

    public void RescaleiFrame()
    {
        webViewObject.offset =  int.Parse(offset.text);
    }
}
