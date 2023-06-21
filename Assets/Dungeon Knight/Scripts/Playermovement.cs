using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Playermovement : MonoBehaviour
{

    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            anim.enabled = true;
            anim.SetTrigger("PForwardAnim" );
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.enabled = true;
            anim.SetTrigger("PBackwardAnim");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.enabled = true;
            anim.SetTrigger("PLeftAnim");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.enabled = true;
            anim.SetTrigger("PRightAnim");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
