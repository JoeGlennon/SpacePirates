using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Particle prefab on Player Ship")]
    [SerializeField] GameObject m_DeathFX;

    [Tooltip("In  Seconds")]
    [SerializeField] float m_LoadDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath"); // freezes movement controls
        m_DeathFX.SetActive(true);
        Invoke("ReloadLevel", m_LoadDelay);

    }

    private void ReloadLevel() //string referenced 
    {
        SceneManager.LoadScene(1);
    }
}
