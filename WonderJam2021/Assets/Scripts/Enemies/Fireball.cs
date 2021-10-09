using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // linked to the rigid body of the fireball
    public Rigidbody2D rb;
    public float speed = 5f;

    private Vector2 direction; // left or right

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
        rb.velocity = transform.right * direction.x * speed;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }
}