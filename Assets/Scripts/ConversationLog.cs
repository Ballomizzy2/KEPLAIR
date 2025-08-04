using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationLog : MonoBehaviour
{
    [SerializeField] private GameObject keplairLogText, learnerLogText;

    [SerializeField] private RectTransform lastText;

    [SerializeField] private float offsetY;
    
    [SerializeField] private ScrollRect myScrollRect;

    [SerializeField] private Toggle logToggle;

    [SerializeField] private TextMeshProUGUI fakeKeplairLog; 
    

    public void StoreLog(string keplair, string learner)
    {
        // we are creating an auxilliary keplair string that would always be displayed as soon as
        // the current node is changed in the graph.
        // as soon as we want to store a log, we disable it immediately.
        //fakeKeplairLog.gameObject.SetActive(false);
        
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
        //FocusOnRecentLog();
    }

    public void AppendLastText(string text)
    {
        lastText.GetComponent<TextMeshProUGUI>().text += "\n" + text;
    }
    public void InitiateAuxKeplairLog(string tempString)
    {
        fakeKeplairLog.gameObject.SetActive(true);
        fakeKeplairLog.text = tempString;
        RectTransform rt = fakeKeplairLog.gameObject.GetComponent<RectTransform>();
        rt = lastText;
    }

    public void FocusOnRecentLog()
    {
        myScrollRect.verticalNormalizedPosition = 0f;
        Debug.Log("Hii");
    }

    public void ShowLog()
    {
        myScrollRect.gameObject.SetActive(logToggle.isOn);
    }
}
