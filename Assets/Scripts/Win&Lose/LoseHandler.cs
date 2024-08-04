using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHandler : MonoBehaviour
{
    [HideInInspector] public static LoseHandler instance { get; private set; }
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }

    public void CallEnding()
    {
        animator.SetTrigger("EndOfScene");
    }

    public void CallStart()
    {
        animator.SetTrigger("StartOfScene");
    }
}
