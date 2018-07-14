using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            //collision.GetComponent<Collider>().transform.SetParent(transform);
        }
    }
}
