using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowSwitchingManager : MonoBehaviour
{
    [System.Serializable]
    public enum WindowType
    {
        Chatbot, LearningActivity, LearningPath, LearningProfile, Notebook
    }

    private WindowType currentWindowOpen;
    
    private ConversationUI conversationUI;
    
    [SerializeField]
    private GameObject ChatBotWindow, LearningActivityWindow, LearningPathWindow, LearningPathExtras, LearnerProfileWindow, NotebookWindow;
    
    // button switching
    [SerializeField]
    private Button ChatBotButton, LearningActivityButton, LearningPathButton, LearningProfileButton, NotebookButton;
    [SerializeField]
    private Color selectedColor = Color.white, unselectedColor =  Color.gray5;
    
    
    private void Start()
    {
        conversationUI = FindObjectOfType<ConversationUI>();
        OpenWindow(currentWindowOpen);
    }

    public void OpenWindowTrigger(int enumIndex)
    {
        // 0 for ChatBot
        // 1 for Learning Activity
        // 2 for Learning Path
        // 3 for Learner Profile
        // 4 for Notebook
        
        OpenWindow((WindowType)enumIndex);
    }
    
    private void OpenWindow(WindowType windowType)
    {
        //WindowType windowType = ;
        // windows to put off
        ChatBotWindow.SetActive(false);
        LearningActivityWindow.SetActive(false);
        LearningPathWindow.SetActive(false);
        LearnerProfileWindow.SetActive(false);
        NotebookWindow.SetActive(false);
        LearningPathExtras.SetActive(false);
        
        
        // button to highlight
        ChatBotButton.image.color = unselectedColor;
        LearningActivityButton.image.color = unselectedColor;
        LearningPathButton.image.color = unselectedColor;
        LearningProfileButton.image.color = unselectedColor;
        NotebookButton.image.color = unselectedColor;

        if (windowType != WindowType.LearningActivity)
        {
            // Close the webview
            WebViewObject g = FindAnyObjectByType<WebViewObject>();
            if(g)
                Destroy(g.gameObject);
        }
        
        
        switch (windowType)
        {
            case WindowType.LearningActivity:
                LearningActivityWindow.SetActive(true);
                conversationUI.SwitchCamera(true);
                LearningActivityButton.image.color = selectedColor;
                break;
            case WindowType.LearningPath:
                LearningPathWindow.SetActive(true);
                LearningPathExtras.SetActive(true);
                conversationUI.SwitchCamera(false);
                LearningPathButton.image.color = selectedColor;
                break;
            case WindowType.Chatbot:
                conversationUI.SwitchCamera(true);
                ChatBotWindow.SetActive(true);
                ChatBotButton.image.color = selectedColor;
                break;
            case WindowType.LearningProfile:
                LearnerProfileWindow.SetActive(true);
                LearningProfileButton.image.color = selectedColor;
                break;
            case WindowType.Notebook:
                NotebookWindow.SetActive(true);
                NotebookButton.image.color = selectedColor;
                break;
            default:
                break;
        }
        currentWindowOpen = windowType;
    }
    
}
