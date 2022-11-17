using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbot : MonoBehaviour
{   
    public int health = 5;
    
    public Transform player;
    public float distance = 7;

    public ProjectileBehavior projectilePrefab;
    public Transform launchOffset;

    private Rigidbody2D myBody;

    [SerializeField]
    private float minJumpX, maxJumpX, minJumpY, maxJumpY;

    private float jumpTimer;

    private bool canJump;

    public bool invincible;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpTimer = Time.time;
    }

    private void Update()
    {
        HandleJumping();

        if (health == 0) {
            Destroy(gameObject);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            canJump = false;
            myBody.velocity = new Vector2(Random.Range(minJumpX, maxJumpX), Random.Range(minJumpY, maxJumpY));
            Invoke("Shoot", 1.2f);
        }
    }

    void Shoot() {
        Instantiate(projectilePrefab, launchOffset.position, launchOffset.rotation);
    }

    void HandleJumping()
    {
        if (Time.time > jumpTimer)
        {
            jumpTimer = Time.time;
            Jump();
        }

        if (myBody.velocity.magnitude == 0 && (Vector3.Distance(transform.position, player.position) < distance)) {
            canJump = true;
        }

        if (Vector3.Distance(transform.position, player.position) < distance) {
            invincible = false;
        } else invincible = true;
    }

    //When the enemy hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincible) return;
        if (collision.gameObject.CompareTag("Carrot")) return;
        if (collision.gameObject.GetComponent<ProjectileBehavior>())
        {
            health -= 1;
        }
    }
}
