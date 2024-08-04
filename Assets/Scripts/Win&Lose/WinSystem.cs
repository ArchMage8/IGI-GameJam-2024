using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    private void Start()
    {
        WinHandler.instance.CallStart();
    }
}
