using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChAnimation : MonoBehaviour
{
    [SerializeField] private string idleClip, walkNClip, walkSClip, walkWClip, walkEClip;
    [SerializeField] private ChMovement chMovement;
    [SerializeField] private Animator animator;
    void Start()
    {
        chMovement = GetComponent<ChMovement>();        
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameContext.Instance.input.forward > 0)
        {
            animator.Play(walkNClip, 0);
        }
        else if(GameContext.Instance.input.forward < 0)
        {
            animator.Play(walkSClip, 0);
        }
        else if(GameContext.Instance.input.lateral > 0)
        {
            animator.Play(walkEClip, 0);
        }
        else if(GameContext.Instance.input.lateral < 0)
        {
            animator.Play(walkWClip, 0);
        }else{
            animator.Play(idleClip, 0);
        }
    }
}
