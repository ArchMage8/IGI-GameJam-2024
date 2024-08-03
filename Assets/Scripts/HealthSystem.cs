using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int Health = 100;
    public TMP_Text HealthText;

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        UpdateText();
    }

    public void DealDamage(int Damage)
    {
        Health = Health - Damage;
    }

    public void UpdateText()
    {
        HealthText.text = Health.ToString();
       
    }
}
