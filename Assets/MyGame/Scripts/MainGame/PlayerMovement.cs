using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed = 5f;
    public int playerHealth = 3; // Player health

    void Update() {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
