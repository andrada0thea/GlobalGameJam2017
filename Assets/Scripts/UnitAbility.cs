﻿using UnityEngine;
using System.Collections;

public class UnitAbility: MonoBehaviour {

    string m_abilityName;
    float m_cooldown;
    float m_cooldownTimer;
    float m_abilitySpeed;
    float m_abilityDamage;
    float m_abilitySize;
    int m_abilityDurability;

    public void SetUnitAbility(string abilityName, float cooldown, float speed, float damage, float size, int durability)
    {
        m_abilityName = abilityName;
        m_cooldown = cooldown;
        m_cooldownTimer = 0.0f;
        m_abilitySpeed = speed;
        m_abilityDamage = damage;
        m_abilitySize = size;
        m_abilityDurability = durability;
    }

    public void UpdateCooldown(float deltaTime)
    {
        if(m_cooldownTimer <= 0)
        {
            m_cooldownTimer = 0.0f;
        }
        else
        {
            m_cooldownTimer -= deltaTime;
        }
    }

    public string GetAbilityName()
    {
        return m_abilityName;
    }

    public float GetCurrentCooldown()
    {
        return m_cooldownTimer;
    }

    public float GetMaxCooldown()
    {
        return m_cooldown;
    }

    public void UseAbility()
    {
        GameObject ability = PhotonNetwork.Instantiate("AbilityParticle", gameObject.transform.position + gameObject.transform.forward, gameObject.transform.rotation, 0);
        ability.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * m_abilitySpeed;
        ability.transform.localScale *= m_abilitySize;
    }
}
