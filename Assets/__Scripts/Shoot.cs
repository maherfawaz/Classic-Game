using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour {
    public ProjectileBehavior projectilePrefab;
    public Transform launchOffset;
    public float direction;
    public float shoot;
    public Animator anim;

    public void OnMovement(InputAction.CallbackContext context) {
        direction = context.ReadValue<float>();
    }

    public void OnFire(InputAction.CallbackContext context) {
        shoot = context.ReadValue<float>();
    }

    void Update() {
        Quaternion y;
        y = launchOffset.localRotation;
        if (direction > 0) {
            y.y = 0;
            launchOffset.localRotation = y;
        } else if (direction < 0) {
            y.y = 180;
            launchOffset.localRotation = y;
        }

        if (shoot > 0 && StairMaster.ON_STAIRS == false) {
            anim.Play("Shoot");
            Instantiate(projectilePrefab, launchOffset.position, launchOffset.rotation);
            shoot = 0;
        }
    }
}
