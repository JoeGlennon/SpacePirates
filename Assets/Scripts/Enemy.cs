using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject m_DeathFX;
    [SerializeField] Transform m_Parent;

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
        GameObject fx = Instantiate(m_DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = m_Parent;
        Destroy(gameObject);
    }
}
