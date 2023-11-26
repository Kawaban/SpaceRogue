using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EntityData")]
public class EntityData : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxShield;
    [SerializeField] private float shieldRegeneration;
    [SerializeField] private int score;

    public float MaxHealth { get => maxHealth; }
    public float MaxShield { get => maxShield; }
    public float ShieldRegeneration { get => shieldRegeneration;  }
    public int Score { get => score;  }
}
