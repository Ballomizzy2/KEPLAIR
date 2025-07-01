using System;
using UnityEngine;

public class WindowSwitchingManager : MonoBehaviour
{
    [System.Serializable]
    public enum WindowType
    {
        Chatbot, LearningActivity, LearningPath
    }

    private WindowType currentWindowOpen;
    
    private ConversationUI conversationUI;
    
    [SerializeField]
    private GameObject ChatBotWindow,  LearningActivityWindow, LearningPathWindow;

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
        OpenWindow((WindowType)enumIndex);
    }
    
    private void OpenWindow(WindowType windowType)
    {
        //WindowType windowType = ;
        
        ChatBotWindow.SetActive(false);
        LearningActivityWindow.SetActive(false);
        LearningPathWindow.SetActive(false);

        switch (windowType)
        {
            case WindowType.LearningActivity:
                LearningActivityWindow.SetActive(true);
                conversationUI.SwitchCamera(true);
                break;
            case WindowType.LearningPath:
                LearningPathWindow.SetActive(true);
                break;
            case WindowType.Chatbot:
                conversationUI.SwitchCamera(true);
                ChatBotWindow.SetActive(true);
                break;
            default:
                break;
        }
        currentWindowOpen = windowType;
    }
    
}
