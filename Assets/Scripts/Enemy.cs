using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject m_DeathFX;
    [SerializeField] Transform m_Parent;

    [SerializeField] int m_PointsPerHit = 10;
    [SerializeField] int m_HitPoints = 10;

    ScoreBoard m_ScoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        m_ScoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
       Collider boxCollider = gameObject.AddComponent<BoxCollider>();
       boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHits();

        if (m_HitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHits()
    {
        m_HitPoints--;
        m_ScoreBoard.ScoreHit(m_PointsPerHit);
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(m_DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = m_Parent;
        Destroy(gameObject);
    }
}
