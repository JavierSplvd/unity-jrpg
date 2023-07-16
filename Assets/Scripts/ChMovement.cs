using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rigidbody {get{return rb;}}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        if(GameContext.Instance.input.forward != 0)
        {
            movement += Vector2.up * GameContext.Instance.input.forward;
        }
        else if(GameContext.Instance.input.lateral != 0)
        {
            movement += Vector2.right * GameContext.Instance.input.lateral;
        }
        // This is framerate independent. 0.02 is the fixedDeltaTime
        rb.velocity = movement * Time.fixedDeltaTime * moveSpeed / 0.02f;
    }

}
