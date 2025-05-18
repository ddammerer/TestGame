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
            HandlePlayerHit(collision);
        }
    }

    private void Start() {
        Invoke("DestroyBullet", 3f); 
    }

    protected virtual void HandleEnemyHit(Collider2D enemy) {
        enemy.GetComponent<ManageEnemy>().EnemyHealth -= 1; // Decrease enemy health
        if(enemy.GetComponent<ManageEnemy>().EnemyHealth <= 0) {
            Destroy(enemy.gameObject); // Destroy the enemy if health is 0
        }
    }

    private void HandleObstacleHit(Collider2D obstacle) {
        Destroy(gameObject); // Destroy the bullet
    }

    protected virtual void HandlePlayerHit(Collider2D player) {
        return;
    }

    private void DestroyBullet() {
        Destroy(gameObject); // Destroy the bullet
    }
}
