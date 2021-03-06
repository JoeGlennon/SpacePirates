﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In Meters/sec")] [SerializeField] float m_Xspeed = 10f;
    [Tooltip("In Meters")] [SerializeField] float m_Xrange = 3f;
    [Tooltip("In Meters/sec")] [SerializeField] float m_Yspeed = 10f;
    [Tooltip("In Meters")] [SerializeField] float m_Yrange = 3f;
    [SerializeField] GameObject[] m_Guns;

    [Header("Screen-position")]
    [SerializeField] float m_PsoitionPitchFactor = -10f;
    [SerializeField] float m_PsoitionYawFactor = 10f;

    [Header("Control-throw")]
    [SerializeField] float m_ControlPitchFactor = -15f;
    [SerializeField] float m_ControlRollFactor = -30f;

    float m_Xthrow;
    float m_Ythrow;

    bool m_IsAlive = true;
   
    // Update is called once per frame
    void Update()
    {
        if (m_IsAlive)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessShooting();
        }
    }

    private void ProcessShooting()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in m_Guns)
        {
            var emittor = gun.GetComponent<ParticleSystem>().emission;
            emittor.enabled = isActive;
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * m_PsoitionPitchFactor;
        float pitchDueToControl = m_Ythrow * m_ControlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * m_PsoitionYawFactor;
;       float roll = m_Xthrow * m_ControlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        m_Xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        m_Ythrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = m_Xthrow * m_Xspeed * Time.deltaTime;
        float yOffset = m_Ythrow * m_Yspeed * Time.deltaTime;

        float rawXPosition = transform.localPosition.x + xOffset;
        float xPosition = Mathf.Clamp(rawXPosition, -m_Xrange, m_Xrange);

        float rawYPosition = transform.localPosition.y + yOffset;
        float yPosition = Mathf.Clamp(rawYPosition, -m_Yrange, m_Yrange);

        transform.localPosition = new Vector3(xPosition, yPosition, transform.localPosition.z);
    }

    private void OnPlayerDeath() //called via string reference
    {
        m_IsAlive = false;
    }
}

