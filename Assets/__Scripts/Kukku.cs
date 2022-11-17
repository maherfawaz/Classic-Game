using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kukku : MonoBehaviour
{   
    public int health = 5;
    
    public Transform player;
    public float distance = 7;

    public float speed;

    private Rigidbody2D myBody;

    [SerializeField]
    private float jumpForceX, jumpForceY;

    public bool invincible;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health == 0) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        if (Vector3.Distance(transform.position, player.position) < distance) {
            invincible = false;
            Vector2 velocity = myBody.velocity;
            velocity.x = speed;
            myBody.velocity = velocity;
        } else invincible = true;
    }

    void Jump()
    {
        myBody.velocity = new Vector2(jumpForceX, jumpForceY);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("JumpPoint")) {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (invincible) return;
        if (coll.gameObject.GetComponent<ProjectileBehavior>())
        {
            health -= 1;
        }
    }
}
