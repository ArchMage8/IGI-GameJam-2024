using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    private void Start()
    {
        LoseHandler.instance.CallStart();
    }
}
