using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [HideInInspector] public static WinHandler instance { get; private set; }
    private Animator animator; 

    private void Start()
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
