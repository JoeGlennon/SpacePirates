using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SplashScreen : MonoBehaviour
{

    [SerializeField] float m_LoadDelay = 5f;
    

    private void Awake()
    {

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", m_LoadDelay);
    }

    private void LoadGame()
    {

        SceneManager.LoadScene(1);
    }

}
