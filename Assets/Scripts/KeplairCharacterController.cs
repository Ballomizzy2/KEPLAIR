using System;
using UnityEngine;

public class KeplairCharacterController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject learnerCharacter;
    private Quaternion initialRotation;

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
