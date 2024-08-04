using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceDevice : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject interactUI;
    public GameObject lightWarning;
    public GameObject heavyWarning;

    [Space(30)]
    [Header("Time Delays")]
    public float firstThreshold;
    public float secondThreshold;
    public float StartDelay;

    [Space(20)]
    [Header("Ship Interact")]
    public HealthSystem shipHealth;
    public int Damage;
    public float DamageDelay = 1f;

    private float timer;
    private bool playerInRange;

    private float TempFirst;
    private float TempSecond;
    private bool DamageBool = false;
    private Coroutine callCoroutine;


    private void Awake()
    {
        interactUI.SetActive(false);
        lightWarning.SetActive(false);
        heavyWarning.SetActive(false);

        TempFirst = firstThreshold + StartDelay;
        TempSecond = secondThreshold + StartDelay;
    }  

    private void Update()
    {
        if (DamageBool)
        {
            if (callCoroutine == null)
            {
                callCoroutine = StartCoroutine(DoDamage());
            }
        }
        else
        {
            if (callCoroutine != null)
            {
                StopCoroutine(callCoroutine);
                callCoroutine = null;
            }
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {

            Debug.Log("Repair");
            AudioManager.Instance.PlaySFX("Fix");
            
            timer = 0;
            lightWarning.SetActive(false);
            heavyWarning.SetActive(false);

            DamageBool = false;

            if(TempFirst > firstThreshold || TempSecond > secondThreshold)
            {
                TempFirst = firstThreshold;
                TempSecond = secondThreshold;
            }
        }

        timer += Time.deltaTime;

        if (timer >= TempSecond)
        {

            // if (heavyWarning==false)
            // {
            //     AudioManager.Instance.PlaySFX("HullLow");
            // }

            heavyWarning.SetActive(true);
            lightWarning.SetActive(false);

            DamageBool = true;
            
        }
        else if (timer >= TempFirst)
        {
            // if (lightWarning==false)
            // {
            //     AudioManager.Instance.PlaySFX("HullNeedRepair");
            // }

            lightWarning.SetActive(true);
            heavyWarning.SetActive(false);
        }
        else
        {
            lightWarning.SetActive(false);
            heavyWarning.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            playerInRange = true;
            
            AudioManager.Instance.PlaySFX("Chirp");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            playerInRange = false;
        }
    }            

    private IEnumerator DoDamage()
    {
        while (true)
        {
            shipHealth.DealDamage(Damage);
            AudioManager.Instance.PlaySFX("HullBeep");
            yield return new WaitForSeconds(DamageDelay);
        }
    }
}
