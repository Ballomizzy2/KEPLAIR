using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationUI : MonoBehaviour
{
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI messageText;
    public Transform optionsContainer;
    public GameObject optionButtonPrefab;
    public ConversationGraph conversationGraph;
    public ConversationLog conversationLog;

    public GameObject leanerActivityWindow;
    public GameObject learnerResourceButton;

    public GameObject learnerProfileWindow;
    
    public KeplairCharacterController keplairCharacterController;

    public GameObject mainCamera, pathCamera;
    public GameObject learningPath;
    
    private ConversationNode currentNode;

    void Start()
    {
        conversationGraph.Initialize();
        currentNode = conversationGraph.GetNodeById("0"); // Start
        DisplayCurrentNode();
        leanerActivityWindow.SetActive(false);
    }

    void DisplayCurrentNode()
    {
        keplairCharacterController.Speak();
        speakerText.text = currentNode.speaker;
        messageText.text = currentNode.messageText;
        ClearOptions();

        foreach (var option in currentNode.options)
        {
            var btn = Instantiate(optionButtonPrefab, optionsContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = option.optionText;
            //btn.GetComponent<RectTransform>().ForceUpdateRectTransforms();
            btn.GetComponent<Button>().onClick.AddListener(() => OnOptionSelected(option));
        }
        
        foreach (var resource in currentNode.resources)
        {
            leanerActivityWindow.SetActive(true);
            var btn = Instantiate(learnerResourceButton, leanerActivityWindow.transform);
            btn.GetComponent<LearningResourceButton>().SetLink(resource.GetTitle(),  resource.GetLink());
        }
        
        if(currentNode.isLearnerProfileActivator)
            learnerProfileWindow.SetActive(true);
        
        learningPath.SetActive(currentNode.isLearningPathShowing);
    }

    void OnOptionSelected(ConversationOption option)
    {
        // handle logs
        // Store Log(currentNode.text, option.text)
        conversationLog.StoreLog(currentNode.messageText, option.optionText);
        var next = conversationGraph.GetNodeById(option.nextNodeId);
        if (next != null)
        {
            currentNode = next;
            DisplayCurrentNode();
        }
    }

    void ClearOptions()
    {
        foreach (Transform child in optionsContainer)
            Destroy(child.gameObject);
    }

    public void ChangeNode(string nodeID)
    {
        currentNode = conversationGraph.GetNodeById(nodeID);
        DisplayCurrentNode();
    }

    public void ShowLearnerProfileWindow()
    {
        learnerProfileWindow.SetActive(true);
    }
    public void CloseLearnerActivityWindow()
    {
        leanerActivityWindow.SetActive(false);
        for (int i = 1; i < leanerActivityWindow.transform.childCount; i++)
        {
            Destroy(leanerActivityWindow.transform.GetChild(i).gameObject);
        }
        /*currentNode = conversationGraph.GetNodeById("5"); //use this for feedback
        DisplayCurrentNode();*/
    }

    public void SwitchCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);
        pathCamera.SetActive(!pathCamera.activeSelf);
    }
    
    [System.Serializable]
    public class ResourceLink
    { 
        public string link;
        public string title;

        public ResourceLink(string link, string title)
        {
            this.link = link;
            this.title = title;
        }

        public string GetLink()
        {
            return link;
        }

        public string GetTitle()
        {
            return title;
        }
    }
    
}
