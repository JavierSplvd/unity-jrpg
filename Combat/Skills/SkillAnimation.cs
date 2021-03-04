using UnityEngine;
using UnityEngine.UI;

public class SkillAnimation
{
    private Animator animator;
    private Image image;

    public SkillAnimation(Animator animator, Image image)
    {
        this.animator = animator;
        this.image = image;

        image.enabled = false;
    }

    public void Play(SkillAnimationName name)
    {
        image.enabled = false;
        animator.Play(name.ToString());
    }

    public Image GetImage() => image;
}
