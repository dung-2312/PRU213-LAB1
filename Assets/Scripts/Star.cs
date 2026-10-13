using UnityEngine;

/// <summary>
/// Đùi gà: Tưng nảy vọt lên trên rồi rơi từ từ bồng bềnh, nhặt vào phát ra âm thanh ting ting ăn điểm.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Star : MonoBehaviour
{
    [Header("Scoring")]
    [SerializeField] private int points = 10;
    [SerializeField] private float rotateSpeed = 120f;

    [Header("Audio")]
    public AudioClip pickupSound; // File âm thanh nhặt đùi gà

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Rơi chậm và êm ái
        rb.gravityScale = 0.35f;
        rb.drag = 0.8f;

        // Tưng vọt lên trên vừa tầm mắt
        float randomX = Random.Range(-1.2f, 1.2f);
        rb.velocity = new Vector2(randomX, 3.8f);

        Destroy(gameObject, 8f);
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Phát âm thanh nhặt đùi gà ting ting
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main != null ? Camera.main.transform.position : transform.position);
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(points);
            }

            Destroy(gameObject);
        }
    }
}