using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public List<Sprite> healthBars;
    public PlayerHealth playerHealth;
    public Image healthBar;

    void Update() {
        if (playerHealth.health == 28) {
            healthBar.sprite = healthBars[0];
        }

        if (playerHealth.health == 27) {
            healthBar.sprite = healthBars[1];
        }

        if (playerHealth.health == 26) {
            healthBar.sprite = healthBars[2];
        }

        if (playerHealth.health == 25) {
            healthBar.sprite = healthBars[3];
        }

        if (playerHealth.health == 24) {
            healthBar.sprite = healthBars[4];
        }

        if (playerHealth.health == 23) {
            healthBar.sprite = healthBars[5];
        }

        if (playerHealth.health == 22) {
            healthBar.sprite = healthBars[6];
        }

        if (playerHealth.health == 21) {
            healthBar.sprite = healthBars[7];
        }

        if (playerHealth.health == 20) {
            healthBar.sprite = healthBars[8];
        }

        if (playerHealth.health == 19) {
            healthBar.sprite = healthBars[9];
        }

        if (playerHealth.health == 18) {
            healthBar.sprite = healthBars[10];
        }

        if (playerHealth.health == 17) {
            healthBar.sprite = healthBars[11];
        }

        if (playerHealth.health == 16) {
            healthBar.sprite = healthBars[12];
        }

        if (playerHealth.health == 15) {
            healthBar.sprite = healthBars[13];
        }

        if (playerHealth.health == 14) {
            healthBar.sprite = healthBars[14];
        }

        if (playerHealth.health == 13) {
            healthBar.sprite = healthBars[15];
        }

        if (playerHealth.health == 12) {
            healthBar.sprite = healthBars[16];
        }

        if (playerHealth.health == 11) {
            healthBar.sprite = healthBars[17];
        }

        if (playerHealth.health == 10) {
            healthBar.sprite = healthBars[18];
        }

        if (playerHealth.health == 9) {
            healthBar.sprite = healthBars[19];
        }

        if (playerHealth.health == 8) {
            healthBar.sprite = healthBars[20];
        }

        if (playerHealth.health == 7) {
            healthBar.sprite = healthBars[21];
        }

        if (playerHealth.health == 6) {
            healthBar.sprite = healthBars[22];
        }

        if (playerHealth.health == 5) {
            healthBar.sprite = healthBars[23];
        }

        if (playerHealth.health == 4) {
            healthBar.sprite = healthBars[24];
        }

        if (playerHealth.health == 3) {
            healthBar.sprite = healthBars[25];
        }

        if (playerHealth.health == 2) {
            healthBar.sprite = healthBars[26];
        }

        if (playerHealth.health == 1) {
            healthBar.sprite = healthBars[27];
        }

        if (playerHealth.health == 0) {
            healthBar.sprite = healthBars[28];
        }
    }
}
