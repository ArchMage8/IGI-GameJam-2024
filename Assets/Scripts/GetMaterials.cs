using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMaterials : MonoBehaviour
{
    /*[HideInInspector]*/ public int CollectedSteel = 0;
    /*[HideInInspector]*/ public int CollectedElectronic = 0;
    /*[HideInInspector]*/ public int CollectedPlastic = 0;

    [Header("Target Values")]
    public int TargetSteel = 0;
    public int TargetElectronic = 0;
    public int TargetPlastic = 0;
    [Space(30)]

    private GameObject CurrDebris;
    private DebrisAttributes debrisAttributes;

    [Header("UI Stuffs")]
    public GameObject UpgradeButton;
    public TMP_Text SteelText;
    public TMP_Text ElectroText;
    public TMP_Text PlasticText;

    private void Awake()
    {
        UpgradeButton.SetActive(false);
        UpdateText();
    }

    private void Update()
    {
        UpdateText();

        if (CollectedSteel >= TargetSteel && CollectedPlastic >= TargetPlastic && CollectedElectronic >= TargetElectronic)
        {
            UpgradeButton.SetActive(true);
        }
    }

    public void ProcessMaterials(GameObject TargetDebris)
    {
        CurrDebris = TargetDebris;
        debrisAttributes = CurrDebris.GetComponent<DebrisAttributes>();
        accessMaterials();
        
        CurrDebris = null;
        Destroy(TargetDebris);
    }

    private void accessMaterials()
    {
        CollectedSteel += debrisAttributes.Steel;
        CollectedPlastic += debrisAttributes.Plastic;
        CollectedElectronic += debrisAttributes.Electronic;

    }

    public void UpdateText()
    {
        SteelText.text = CollectedSteel.ToString();
        ElectroText.text = CollectedElectronic.ToString();
        PlasticText.text = CollectedPlastic.ToString();
    }

}
