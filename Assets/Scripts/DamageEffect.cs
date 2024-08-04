using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [HideInInspector]public static DamageEffect instance;
    private Animator cameraShaker;

    private void Awake()
    {
        instance = this;
        cameraShaker = GetComponent<Animator>();
    }

    public void CamShake()
    {
        cameraShaker.SetTrigger("Shake");
    }
}
