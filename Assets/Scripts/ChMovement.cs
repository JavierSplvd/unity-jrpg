using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rigidbody {get{return rb;}}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = GameContext.Instance.input.forward * Vector2.up + GameContext.Instance.input.lateral * Vector2.right;
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.velocity = movement * Time.fixedDeltaTime * moveSpeed;
    }

}
