using UnityEngine;

public abstract class SkillSO : ScriptableObject {
    public string skillName = "";
    public Sprite icon;
    public AudioClip skillSound;
    public float manaCost;
    public float power;
    public bool selectTarget = false;

    public abstract void Initialize(GameObject obj);
    public abstract void Execute();
}