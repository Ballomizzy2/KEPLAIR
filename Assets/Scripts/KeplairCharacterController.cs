using System;
using UnityEngine;

public class KeplairCharacterController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject learnerCharacter;
    private Quaternion initialRotation;
    
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private void Start()
    {
        initialRotation = transform.rotation;
        animator = GetComponent<Animator>();
    }

    public void Speak()
    {
        animator.ResetTrigger("Talk");
        animator.SetTrigger(("Talk"));
    }

    private void Update()
    {
        
        // Get the current rotation
        float rotation = Time.time * rotationSpeed;

        // Apply rotation to the skybox's "_Rotation" shader property
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
        
        if (learnerCharacter.activeInHierarchy)
        {
            transform.LookAt(learnerCharacter.transform);
        }
        else
        {
            transform.rotation = initialRotation;
        }
    }
}
