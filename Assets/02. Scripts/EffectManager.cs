using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager m_Instance;

    public static EffectManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType<EffectManager>();

            return m_Instance;
        }
    }

    public enum EffectType
    {
        COMMON,
        FLESH
    }

    public ParticleSystem commonHitEffect;
    public ParticleSystem fleshHitEffect;

    public void PlayHitEffect(Vector3 pos, Vector3 normal, Transform parent = null, 
        EffectType effectType = EffectType.COMMON)
    {
        var targetEffect = commonHitEffect;

        if (effectType == EffectType.FLESH)
            targetEffect = fleshHitEffect;

        var effect = Instantiate(targetEffect, pos, Quaternion.LookRotation(normal));

        if (parent != null)
            effect.transform.SetParent(parent);

        effect.Play();
    }
}
