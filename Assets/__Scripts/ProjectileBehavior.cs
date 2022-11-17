using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    public float speed = 4.5f;

    void Update() {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Bullet")) {
            Destroy(coll.gameObject);
        } else Destroy(gameObject); ;
    }
}
