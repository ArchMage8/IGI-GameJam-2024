using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int Health = 100;
    public TMP_Text HealthText;
    public int loseScene;

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        UpdateText();

        if (Health <= 0)
        {
            
            StartCoroutine(loadLoseScene());
        }
    }

    public void DealDamage(int Damage)
    {
        Health = Health - Damage;
    }

    public void UpdateText()
    {
        HealthText.text = Health.ToString();
       
    }

    private IEnumerator loadLoseScene()
    {
        LoseHandler.instance.CallEnding();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(loseScene);
    }
}
