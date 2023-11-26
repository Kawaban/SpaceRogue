using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Build")]
public class Build : ScriptableObject
{
    [SerializeField] private EntityData entityData;
    [SerializeField] private Weapon weapon;
    [SerializeField] private MovementData movementData;

    public EntityData EntityData { get => entityData; }
    public Weapon Weapon { get => weapon; }
    public MovementData MovementData { get => movementData;  }
}
