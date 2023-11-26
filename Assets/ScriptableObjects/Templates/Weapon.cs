using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Boolean canTurn;
    [SerializeField] private int series;
    [SerializeField] private float fireDelay;
    [SerializeField] private float bulletForce;
    [SerializeField] private Sprite bulletImage;
    [SerializeField] private Sound shotSound;

    public float Damage { get => damage; }
    public float AttackCooldown { get => attackCooldown;  }
    public bool CanTurn { get => canTurn;  }
    public int Series { get => series;  }
    public float FireDelay { get => fireDelay;  }
    public float BulletForce { get => bulletForce; }
    public Sprite BulletImage { get => bulletImage;  }
    public Sound ShotSound { get => shotSound; }
}
