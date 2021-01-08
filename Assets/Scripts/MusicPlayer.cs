using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {

        DontDestroyOnLoad(this);
    }

}
