using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversationGraph", menuName = "KEPLAIR/Conversation Graph")]
public class ConversationGraph : ScriptableObject
{
    public List<ConversationNode> allNodes;

    private Dictionary<string, ConversationNode> nodeMap;

    public void Initialize()
    {
        nodeMap = new Dictionary<string, ConversationNode>();
        foreach (var node in allNodes)
        {
            if (!nodeMap.ContainsKey(node.nodeId))
                nodeMap[node.nodeId] = node;
        }
    }

    public ConversationNode GetNodeById(string id)
    {
        if (nodeMap == null)
            Initialize();

        return nodeMap.TryGetValue(id, out var node) ? node : null;
    }
}
