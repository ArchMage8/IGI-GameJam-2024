using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Health = 100;
    private Coroutine damageCoroutine;
    private float damageInterval = 1.0f;

    public void DealDamage(int Damage)
    {
        Health = Health - Damage;
    }
}
