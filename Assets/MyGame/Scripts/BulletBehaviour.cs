using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            // Handle enemy hit
            HandleEnemyHit(collision);
        } else if (collision.CompareTag("Wall")) {
            // Handle obstacle hit
            HandleObstacleHit(collision);
        } else if (collision.CompareTag("Player")) {
            return;
        }
    }

    private void Start() {
        Invoke("DestroyBullet", 3f); 
    }

    private void HandleEnemyHit(Collider2D enemy) {
        // Implement enemy hit logic here
        Destroy(enemy.gameObject); // Example: destroy the enemy
        Destroy(gameObject); // Destroy the bullet
    }

    private void HandleObstacleHit(Collider2D obstacle) {
        Destroy(gameObject); // Destroy the bullet
    }

    private void DestroyBullet() {
        Destroy(gameObject); // Destroy the bullet
    }
}
