using System;
using UnityEngine;

public class KeplairCharacterController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Speak()
    {
        animator.ResetTrigger("Talk");
        animator.SetTrigger(("Talk"));
    }
}
