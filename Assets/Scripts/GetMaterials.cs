using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaterials : MonoBehaviour
{
    [HideInInspector] public int CollectedSteel = 0;
    [HideInInspector] public int CollectedElectronic = 0;
    [HideInInspector] public int CollectedPlastic = 0;

    public int TargetSteel = 0;
    public int TargetElectronic = 0;
    public int TargetPlastic = 0;

    private GameObject CurrDebris;
    private DebrisAttributes debrisAttributes;

    public GameObject UpgradeButton;

    private void Awake()
    {
        UpgradeButton.SetActive(false);
    }

    private void Update()
    {
        if (TargetSteel == CollectedSteel && TargetPlastic == CollectedPlastic && TargetElectronic == CollectedElectronic)
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

   
}
