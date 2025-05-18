using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPojectiles : BulletBehaviour {
    protected override void HandleEnemyHit(Collider2D enemy) {
        return;
    }

    protected override void HandlePlayerHit(Collider2D player) {
        player.GetComponent<PlayerMovement>().playerHealth -= 1; // Decrease player health
        if(player.GetComponent<PlayerMovement>().playerHealth <= 0) {
            Destroy(player.gameObject); // Destroy the player if health is 0
        }
    }
}

