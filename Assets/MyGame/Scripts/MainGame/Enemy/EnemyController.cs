using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float waitTime = 2f;
    public float range = 10f;

    protected Vector3 targetPosition;
    protected bool isMoving = false;

    protected void Start() {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine() {
        while (true) {
            // Choose a random position
            targetPosition = GetRandomPosition();

            // Move toward the target
            yield return StartCoroutine(MoveToTarget());

            // Wait at the position
            yield return new WaitForSeconds(waitTime);
        }
    }

    Vector3 GetRandomPosition() {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection.z = 0f; // Keep movement on XY plane
        return transform.position + randomDirection;
    }

    IEnumerator MoveToTarget() {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
}
