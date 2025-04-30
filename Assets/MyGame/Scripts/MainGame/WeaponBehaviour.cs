using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private float bulletForce = 3f;

    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        // Rotate the weapon towards the mouse
        RotateWeaponToMouse(direction);
    }

    private void HandleShooting() {
        if (Input.GetMouseButtonDown(0)) {
            ShootAtMouse();
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z); // Set z to distance from camera
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    private void RotateWeaponToMouse(Vector3 direction) {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ShootAtMouse() {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector2 direction = (mouseWorldPos - bulletSpawnPos.position).normalized;

        // Instantiate and shoot the bullet
        FireBullet(direction);
    }

    private void FireBullet(Vector2 direction) {
        Quaternion bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletRotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
