using UnityEngine;

public class CamTracker : MonoBehaviour {
    [SerializeField] Transform camPos;
    private Transform playerPos;
    private Vector3 shakeOffset = Vector3.zero;

    private void Start() {
        if (camPos == null && Camera.main != null) {
            camPos = Camera.main.transform;
        }
    }

    private void LateUpdate() {
        if (playerPos == null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                playerPos = player.transform;
            } else {
                return;
            }
        }

        if (camPos == null) return;

        Vector3 camPosition = camPos.position;
        camPosition.y = playerPos.position.y +5f;
        camPos.position = camPosition + shakeOffset;
    }

    public void ApplyShakeOffset(Vector3 offset) {
        shakeOffset = offset;
    }

    public void ResetShakeOffset() {
        shakeOffset = Vector3.zero;
    }
}
