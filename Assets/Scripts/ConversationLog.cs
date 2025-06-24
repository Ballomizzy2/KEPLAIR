using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationLog : MonoBehaviour
{
    [SerializeField] private GameObject keplairLogText, learnerLogText;

    [SerializeField] private RectTransform lastText;

    [SerializeField] private float offsetY;
    
    [SerializeField] private ScrollRect myScrollRect;
    

    public void StoreLog(string keplair, string learner)
    {
        GameObject keplairLog = Instantiate(keplairLogText, this.transform);
        GameObject learnerLog = Instantiate(learnerLogText, this.transform);
        
        keplairLog.GetComponent<TextMeshProUGUI>().text = keplair;
        learnerLog.GetComponent<TextMeshProUGUI>().text = learner;

        
        
        RectTransform keplairRect =  keplairLog.GetComponent<RectTransform>();
        RectTransform learnerLogRect = learnerLog.GetComponent<RectTransform>();
        
        // adjust scale (7.5f * childText.text.Length) + 50
        keplairRect.sizeDelta = new Vector2(keplairRect.sizeDelta.x + keplair.Length, keplairRect.sizeDelta.y);
        learnerLogRect.sizeDelta = new Vector2(learnerLogRect.sizeDelta.x + learner.Length, learnerLogRect.sizeDelta.y);
        
        // adjust position
        keplairRect.position = new Vector2(keplairRect.position.x, lastText.position.y - lastText.sizeDelta.y * offsetY);
        learnerLogRect.position = new Vector2(learnerLogRect.position.x, keplairRect.position.y - keplairRect.sizeDelta.y * offsetY);

        lastText = learnerLogRect;
        FocusOnRecentLog();
    }

    public void FocusOnRecentLog()
    {
        myScrollRect.verticalNormalizedPosition = 0f;
        Debug.Log("Hii");
    }
}
