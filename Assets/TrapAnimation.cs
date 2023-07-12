using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    public Animator anim;
    public Playermovement playerMovement;
    public int trapDmg;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isActive", false);
        }
    }

    public void playerDmg()
    {
        playerMovement.hp = playerMovement.hp - trapDmg;
    }

    // Update is called once per frame
    //    void Update()
    //    {

    //    }
}
