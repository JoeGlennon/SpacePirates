using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Particle prefab on Enenmy Ship")]
    [SerializeField] GameObject m_DeathFX;

    float m_DestroyDelay = .5f;


    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
       Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        m_DeathFX.SetActive(true);
        Invoke("DestroyShip", m_DestroyDelay);
    }

    void DestroyShip()
    {
        Destroy(gameObject);
    }

}
