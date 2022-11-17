using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batton : MonoBehaviour
{
    [Header("Inscribed")]
    [Tooltip("The speed at which the Batton moves")]
    [SerializeField]
    float speed = 1f;
    
    public int health = 2;
    
    public Transform player;
    public float distance = 10;

    public bool invincible;

    void Update() {
        if (health == 0) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            invincible = false;
            transform.LookAt(player);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else invincible = true;
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
