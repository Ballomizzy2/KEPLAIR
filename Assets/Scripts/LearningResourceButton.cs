using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningResourceButton : MonoBehaviour
{
    private string link;
    private string buttonText;
    
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
        Application.OpenURL(link);
    }
}
