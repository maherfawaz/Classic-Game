using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health = 28;
    public int maxHealth = 28;
    
    public float knockbackForce;
    public float knockbackCounter;
    public float knockbackTotalTime;
    public bool knockFromRight;
    public Rigidbody2D playerRB;
    public GameObject player;

    public bool invincible = false;
    private float invincibleDone = 0;
    public float invincibleDuration = 0.5f;
    public SpriteRenderer sRend;

    void Update() {
        if (health == 0) {
            SceneManager.LoadScene("Map Parse Scene");
        }
        if (invincible && Time.time > invincibleDone) invincible = false;
        sRend.color = invincible ? Color.red : Color.white;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (invincible) return;

        if (coll.gameObject.CompareTag("Enemy") || coll.gameObject.CompareTag("Carrot")) {
            health -= 1;
            
            if (coll.transform.position.x >= player.transform.position.x) {
                knockFromRight = true;
            }

            if(coll.transform.position.x < player.transform.position.x) {
                knockFromRight = false;
            }

            if (knockFromRight == true) {
                playerRB.velocity = new Vector2(-knockbackForce, knockbackForce);
            }

            if (knockFromRight == false) {
                playerRB.velocity = new Vector2(knockbackForce, knockbackForce);
            }

            knockbackCounter -= Time.deltaTime;
            knockbackCounter = knockbackTotalTime;

            invincible = true;
            invincibleDone = Time.time + invincibleDuration;
        }
    }
}
