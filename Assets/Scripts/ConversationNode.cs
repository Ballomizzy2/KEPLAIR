using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversationNode", menuName = "KEPLAIR/Conversation Node")]
public class ConversationNode : ScriptableObject
{
    public string nodeId;
    public string speaker;
    [TextArea(3, 10)]
    public string messageText;
    public List<ConversationOption> options;
    public List<ConversationUI.ResourceLink> resources;

    public bool isLearnerProfileActivator = false, isLearningPathShowing = true;
}
