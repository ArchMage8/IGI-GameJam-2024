using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDisabler : MonoBehaviour
{

    private GameObject winHandler;

    private void Start()
    {
        Debug.Log("Problem?");
        winHandler = WinHandler.instance.gameObject;
        winHandler.SetActive(false);
    }
}
