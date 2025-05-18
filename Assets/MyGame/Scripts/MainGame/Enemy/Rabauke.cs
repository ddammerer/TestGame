using UnityEngine;

public class Rabauke : MonoBehaviour {
    Transform target;
    public float speed = 5f;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (target == null) return;

        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Destroy(collision.gameObject);
        }
    }
}
