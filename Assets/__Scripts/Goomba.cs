using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    [Header("Inscribed")]
    [Tooltip("The speed at which the Goomba moves")]
    [SerializeField]
    float speed = 1f;
    [Tooltip("The ground layer")]
    [SerializeField]
    LayerMask ground;

    [Header("Dynamic")]
    [SerializeField]
    int direction = 1;

    Rigidbody2D rb;
    BoxCollider2D col;

    //Run immediately
    private void Awake()
    {
        //Get component references
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    //Put physics updates in FixedUpdate
    void FixedUpdate()
    {
        //Move along ground
        Vector2 velocity = rb.velocity;
        velocity.x = speed * direction;
        rb.velocity = velocity;

        //Turn around
        bool shouldTurn = false;
        //Get the vector from the object's position to the edge of the box collider
        Vector2 toColliderEdge = new Vector2(col.size.x / 2 + col.offset.x + 0.1f, col.size.y / 2 + col.offset.y + 0.1f);
        //If about to walk off an edge (commented out because goombas are stupid)
        /*Vector2 origin = (Vector2)transform.position + new Vector2(toColliderEdge.x * direction, 0) + rb.velocity * Time.fixedDeltaTime; //Where the leading edge of the box collider will be next frame
        if (!Physics2D.Raycast(origin, Vector2.down, toColliderEdge.y, ground)) //Raycast downwards, looking for ground
            shouldTurn = true;*/
        //If about to run into a wall
        if (Physics2D.Raycast(transform.position, Vector2.right * direction, toColliderEdge.x, ground)) //Raycast forwards looking for ground
            shouldTurn = true;
        //Actually turn around
        if (shouldTurn)
            direction *= -1;
    }

    //When the enemy hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //If the player hit the object when above the center of the collider
            if (collision.gameObject.transform.position.y > transform.position.y + col.offset.y)
            {
                //Die
                Destroy(gameObject);
            }
            //If the player instead hit when below the center of the collider
            else
            {
                //Kill player
                Destroy(collision.gameObject);
            }
        }
    }
}
