using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/MovementData")]
public class MovementData : ScriptableObject
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float trustAcceleration;
    [SerializeField] private Sprite shield;
    [SerializeField] private float shieldTime;
    [SerializeField] private float scale;
    [SerializeField] private Sound shieldSound;
    [SerializeField] private Sound explosionSound;
    [SerializeField] private Sprite shipSprite;

    public float MaxSpeed { get => maxSpeed;  }
    public float RotationSpeed { get => rotationSpeed;  }
    public float TrustAcceleration { get => trustAcceleration;  }
    public Sprite Shield { get => shield;  }
    public float ShieldTime { get => shieldTime;  }
    public float Scale { get => scale;  }
    public Sound ExplosionSound { get => explosionSound;}
    public Sound ShieldSound { get => shieldSound; }
    public Sprite ShipSprite { get => shipSprite; }
}
