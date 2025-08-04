using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningResourceButton : MonoBehaviour
{
    private string link;
    private string buttonText;
    
    [SerializeField]
    private GameObject webViewGO;
    
    [SerializeField]
    private TextMeshProUGUI buttonTextUI;
    
    public void SetLink(string placeholder, string link)
    {
        this.buttonText = placeholder;
        this.link = link;
        buttonTextUI.text = placeholder;
    }

    public void OnClick()
    {
        SampleWebView web = Instantiate(webViewGO, transform).GetComponent<SampleWebView>();
        if (web != null)
        {
            web.Url =  link;
            StartCoroutine(web.Start());
        }
        else
        {
            Debug.LogError("No WebViewObject found");
        }
        
        //Application.OpenURL(link);
    }
}
