using System;
using TMPro;
using UnityEngine;

public class LearnerProfileManager : MonoBehaviour
{
    int selectedProfile = 0;
    
    [SerializeField]TextMeshProUGUI profileCount;
    [SerializeField]ConversationUI conversationUI;

    public void OnPreferenceSelected()
    {
        if (selectedProfile < 3)
            selectedProfile++;
    }

    private void Update()
    {
        if (selectedProfile >= 3)
        {
            conversationUI.ChangeNode("13"); // node for after player profile
            this.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        profileCount.text = selectedProfile.ToString() + "/3 selected";
    }
}
