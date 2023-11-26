using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioCollection")]
public class AudioCollection : ScriptableObject
{
    public Sound[] sounds;
}
