using System.Collections;
using UnityEngine;

public class WasserBall : MonoBehaviour {
    public GameObject prefab;
    public float spawnInterval = 4f;
    public float spawnDistance = 2f;
    public float launchForce = 0.1f;

    private void Start() {
        StartCoroutine(SpawnCoroutine());
    }

    void SpawnPrefabs() {
        if (prefab == null) return;

        SpawnWithRotationAndForce(Vector3.up, Quaternion.Euler(0, 0, 90));
        SpawnWithRotationAndForce(Vector3.down, Quaternion.Euler(0, 0, 270));
        SpawnWithRotationAndForce(Vector3.left, Quaternion.Euler(0, 0, 180));
        SpawnWithRotationAndForce(Vector3.right, Quaternion.identity);
    }

    void SpawnWithRotationAndForce(Vector3 direction, Quaternion rotation) {
        Vector3 spawnPos = transform.position + direction * spawnDistance;
        GameObject instance = Instantiate(prefab, spawnPos, rotation);

        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        Vector2 forceDir = instance.transform.right;
        rb.AddForce(forceDir * launchForce, ForceMode2D.Impulse);

    }

    IEnumerator SpawnCoroutine() {
        while (true) {
            SpawnPrefabs();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
