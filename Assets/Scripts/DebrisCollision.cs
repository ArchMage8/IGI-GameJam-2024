using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisCollision : MonoBehaviour
{
    public int Damage = 0;
    private HealthSystem shipHealth;

    private void Start()
    {
        shipHealth = GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Debris"))
        {
            Debug.Log("Debris Hit");
            shipHealth.DealDamage(Damage);
            StartCoroutine(DestroyDebris(collision.gameObject));

            if (DamageEffect.instance != null)
            {
                DamageEffect.instance.CamShake();
            }
            else
            {
                Debug.LogError("We be missing the camera shake script");
            }
        }
    }

    private IEnumerator DestroyDebris(GameObject Debris)
    {

        yield return new WaitForSeconds(0f);
        Destroy(Debris);
    }


}

