using UnityEngine;
using static SkillTarget;

public abstract class SkillSO : ScriptableObject {
    public string skillName = "";
    public Sprite icon;
    public AudioClip skillSound;
    public SkillAnimationName animationName;
    public float manaCost;
    public float power;
    public Element element = Element.NORMAL;
    [Tooltip("True if should use magic stats.")]
    public bool isMagical = false;
    public SkillTarget targeting = SINGLE_OPPONENT;

    public abstract void Initialize(CommandParams commandParams);
    public abstract void Execute();
}