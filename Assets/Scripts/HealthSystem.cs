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

    private GameObject loseHandler;

    private void Start()
    {
        UpdateText();
        loseHandler = LoseHandler.instance.gameObject;
        loseHandler.SetActive(false);
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
        if (Health > 0)
        {
            HealthText.text = Health.ToString();
        }

        else if(Health <= 0)
        {
                HealthText.text = 0.ToString();
        }
       
    }

    private IEnumerator loadLoseScene()
    {
        loseHandler.SetActive(true);
        LoseHandler.instance.CallEnding();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(loseScene);
    }
}
