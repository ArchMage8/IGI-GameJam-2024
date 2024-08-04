using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    private void Awake()
    {
        LoseHandler.instance.CallStart();
    }
}
