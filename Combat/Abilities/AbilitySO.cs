using UnityEngine;

public abstract class AbilitySO : ScriptableObject {
    public string abilityName = "";
    public Sprite icon;
    public AudioClip abilitySound;
    public float manaCost;
    public float power;
    public bool selectTarget = false;

    public abstract void Initialize(GameObject obj);
    public abstract void Execute();
}