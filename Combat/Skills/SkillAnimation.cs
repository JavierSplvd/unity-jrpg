using UnityEngine;
using UnityEngine.UI;

public class SkillAnimation : MonoBehaviour
{
    private Animator animator;
    private Image image;
    private string unitId;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();

        image.enabled = false;
    }

    public void Play(SkillAnimationName name)
    {
        image.enabled = true;
        Debug.Log(name.ToString());
        animator.Play(name.ToString(), -1, 0f);
    }

    public Image GetImage() => image;
    public string GetUnitId() => unitId;
    public void SetUnitId(string unitId) => this.unitId = unitId;
}
