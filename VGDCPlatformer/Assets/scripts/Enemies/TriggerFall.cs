using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hi");
            Rigidbody2D rb= gameObject.GetComponentInChildren<Rigidbody2D>();
            rb.isKinematic = false;
            Destroy(gameObject, 2f);
        }
    }
}
