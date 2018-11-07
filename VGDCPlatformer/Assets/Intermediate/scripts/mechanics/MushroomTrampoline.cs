using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTrampoline : MonoBehaviour {

    public float jumpPower;
    public Animator jumpAnim;

    private void Start()
    {
        jumpAnim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(JumpAnimation());
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            CharacterController2D cc = collision.gameObject.GetComponent<CharacterController2D>();

            rb.velocity = new Vector2(0, jumpPower);
            
        }
    }
    IEnumerator JumpAnimation()
    {
        jumpAnim.SetBool("PlayerJumped", true);
        yield return new WaitForSeconds(.1f);
        jumpAnim.SetBool("PlayerJumped", false);
    }
}
