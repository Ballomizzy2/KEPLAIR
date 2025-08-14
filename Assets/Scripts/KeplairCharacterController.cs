using System;
using UnityEngine;

public class KeplairCharacterController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject learnerCharacter;
    private Quaternion initialRotation;
    
    private AudioSource audioSource;

    private Vector3 forward, right;
    private Vector3 initialPosition;
    
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
        animator = GetComponent<Animator>();

        forward = transform.forward;
        right = -transform.right;
        
        audioSource = GetComponent<AudioSource>();
    }

    public void Speak(AudioClip clip)
    {
        audioSource.Stop();
        animator.ResetTrigger("Talk");
        animator.SetTrigger(("Talk"));
        
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void Update()
    {
        
        // Get the current rotation
        float rotation = Time.time * rotationSpeed;

        // Apply rotation to the skybox's "_Rotation" shader property
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
        
        if (learnerCharacter.activeInHierarchy)
        {
            //transform.LookAt(learnerCharacter.transform);
            transform.forward = right;
        }
        else
        {
            //transform.rotation = initialRotation;
            transform.forward = forward;
            transform.position = initialPosition;
        }
    }
}
