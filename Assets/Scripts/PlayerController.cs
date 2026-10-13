using UnityEngine;

/// <summary>
/// Điều khiển tàu vũ trụ phong cách Chicken Invaders:
/// Di chuyển phím mũi tên/WASD, giữ Space bắn 2 nòng liên thanh kèm âm thanh chíu chíu.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6.5f; // Tốc độ đầm tay

    [Header("Shooting")]
    public GameObject laserPrefab;
    [SerializeField] private float fireRate = 0.15f;
    private float nextFireTime = 0f;

    [Header("Audio")]
    public AudioClip shootSound; // File âm thanh tiếng bắn laser

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        // Tính giới hạn màn hình
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            float vertExtent = mainCam.orthographicSize;
            float horzExtent = vertExtent * mainCam.aspect;
            minX = -horzExtent + 0.6f;
            maxX = horzExtent - 0.6f;
            minY = -vertExtent + 0.6f;
            maxY = vertExtent - 0.6f;
        }
    }

    private void Update()
    {
        // 1. Nhận phím di chuyển
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(h, v).normalized;

        // 2. Giữ phím Space để xả đạn liên tục
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootDualLasers();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;

        // Giữ tàu trong màn hình
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void ShootDualLasers()
    {
        if (laserPrefab == null) return;

        // Bắn 2 tia đạn từ 2 bên cánh tàu
        Vector3 leftWing = transform.position + new Vector3(-0.25f, 0.4f, 0);
        Vector3 rightWing = transform.position + new Vector3(0.25f, 0.4f, 0);

        Instantiate(laserPrefab, leftWing, Quaternion.identity);
        Instantiate(laserPrefab, rightWing, Quaternion.identity);

        // Phát âm thanh bắn đạn
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main != null ? Camera.main.transform.position : transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Va chạm thiên thạch / gà -> Game Over
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}