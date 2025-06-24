using System;
using UnityEngine;
using UnityEngine.UI;   

public class LearnerProfileOption : MonoBehaviour
{
    Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => SetInteractability(false));
    }

    
    public void SetInteractability(bool interactability)
    {
        btn.interactable = interactability;
    }
}
