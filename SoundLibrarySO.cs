using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrarySO", menuName = "Sounds/SoundLibrarySO", order = 0)]
public class SoundLibrarySO : ScriptableObject
{
    public AudioClip BUTTON_CLICK;
    public AudioClip ATTACK;
    public AudioClip DEFENSE;
}
