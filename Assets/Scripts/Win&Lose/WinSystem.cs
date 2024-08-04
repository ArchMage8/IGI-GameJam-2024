using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    private void Awake()
    {
        WinHandler.instance.CallStart();
    }
}
