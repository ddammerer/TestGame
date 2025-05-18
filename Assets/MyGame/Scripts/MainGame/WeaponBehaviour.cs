using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private float bulletForce = 3f;
    [SerializeField] private float fireRate = 2f; // Seconds between shots

    private Camera mainCamera;
    private Animator camAnimator;
    private float shootTimer;

    private void Awake() {
        mainCamera = Camera.main;
        camAnimator = mainCamera.GetComponent<Animator>();
    }

    private void Update() {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming() {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        RotateWeaponToMouse(direction);
    }

    private void HandleShooting() {
        shootTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0)) {
            if (shootTimer <= 0f) {
                ShootAtMouse();
                shootTimer = fireRate;
            }
            // Enable recoil animation while firing
            camAnimator.SetBool("IsFiring", true);
        } else {
            // Stop recoil animation immediately when mouse released
            camAnimator.SetBool("IsFiring", false);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z);
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    private void RotateWeaponToMouse(Vector3 direction) {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void ShootAtMouse() {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector2 direction = (mouseWorldPos - bulletSpawnPos.position).normalized;

        FireBullet(direction);
    }

    private void FireBullet(Vector2 direction) {
        Quaternion bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletRotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
