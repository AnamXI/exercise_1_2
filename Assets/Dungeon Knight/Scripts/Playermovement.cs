using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using TMPro;
using System.Reflection;
using TMPro.Examples;

public class Playermovement : MonoBehaviour
{

    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public int coinCounter;
    public int hp;
    public TextMeshProUGUI hptxt_value, cointxt_value;
    public float speedpowervalue = 6;
    public int speedDuration = 4;

    private float basemovespeed;
    

    // Start is called before the first frame update
    void Start()
    {
        hp = 400;
        coinCounter = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = 6;
        basemovespeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        hptxt_value.text = hp.ToString();
        cointxt_value.text = coinCounter.ToString();
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("HpUp"))
        {
            hp = hp + 60;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("SpedUp"))
        {
            moveSpeed += speedpowervalue;
            Destroy(collision.gameObject);
            StartCoroutine(returnToBaseSpeed());
        }
    }

    IEnumerator returnToBaseSpeed()
    {
        yield return new WaitForSeconds(speedDuration);
        moveSpeed = basemovespeed;
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

// LONG METHOD OF ANIMATION PER DIRECTION

//if (Input.GetKeyDown(KeyCode.S))
//{

//    anim.enabled = true;
//    anim.SetTrigger("PForwardAnim" );
//}

//if (Input.GetKeyUp(KeyCode.S))
//{
//    anim.enabled = false;
//}

//if (Input.GetKeyDown(KeyCode.W))
//{
//    anim.enabled = true;
//    anim.SetTrigger("PBackwardAnim");
//}

//if (Input.GetKeyUp(KeyCode.W))
//{
//    anim.enabled = false;
//}

//if (Input.GetKeyDown(KeyCode.A))
//{
//    anim.enabled = true;
//    anim.SetTrigger("PLeftAnim");
//}

//if (Input.GetKeyUp(KeyCode.A))
//{
//    anim.enabled = false;
//}

//if (Input.GetKeyDown(KeyCode.D))
//{
//    anim.enabled = true;
//    anim.SetTrigger("PRightAnim");
//}

//if (Input.GetKeyUp(KeyCode.D))
//{
//    anim.enabled = false;
//}
