using UnityEngine;
using static SkillTarget;

public abstract class SkillSO : ScriptableObject {
    public string skillName = "";
    public Sprite icon;
    public AudioClip skillSound;
    public float manaCost;
    public float power;
    [Tooltip("True if should use magic stats.")]
    public bool isMagical = false;
    public SkillTarget targeting = SINGLE_OPPONENT;
    [Tooltip("True if this skill targets unit of the opposite controller.")]
    public bool offensive = true;

    public abstract void Initialize(CommandParams commandParams);
    public abstract void Execute();
}