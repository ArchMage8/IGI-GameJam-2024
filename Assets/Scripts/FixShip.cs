using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixShip : MonoBehaviour
{
    private bool canFix = true;
   
    private Color targetColor = new Color(0.435f, 0.435f, 0.435f); // 6F6F6F in RGB
    private SpriteRenderer spriteRenderer;

    [Header("System")]
    public float delay = 2f;
    public int healing = 0;
    public HealthSystem shipHealth;
    public GetMaterials materials;
    [Space(30)]

    [Header("MaterialCost")]
    public int SteelCost;
    public int ElectronicCost;
    public int PlasticCost;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canFix)
        {
            canFix = false;
            spriteRenderer.color = targetColor;
            StartCoroutine(ResetBoolAfterDelay());
            Fixing();
        }
    }

    private IEnumerator ResetBoolAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canFix = true;
    }

    private void Fixing()
    {
        AudioManager.Instance.PlaySFX("Fix");


        materials.CollectedSteel -= SteelCost;
        materials.CollectedPlastic -= PlasticCost;
        materials.CollectedElectronic -= ElectronicCost;

        if (shipHealth.Health < 100)
        {
            shipHealth.Health += healing;
        }
        else
        {
            shipHealth.Health = 100;
        }
    }
}
