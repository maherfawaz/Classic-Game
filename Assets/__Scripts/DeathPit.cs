using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPit : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.GetComponent<characterMovement>()) {
            SceneManager.LoadScene("Map Parse Scene");
        }
    }
}
