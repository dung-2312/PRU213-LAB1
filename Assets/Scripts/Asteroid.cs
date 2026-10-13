using System.Collections;
using UnityEngine;

/// <summary>
/// Con gà: Lắc lư ziczac, chớp đỏ khi trúng đạn, khi chết phát tiếng nổ bùm và rớt đùi gà.
/// </summary>
public class Asteroid : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 1;
    private int currentHealth;

    [Header("Movement")]
    [SerializeField] private float fallSpeed = 2.2f;
    [SerializeField] private float swayFrequency = 2f;
    [SerializeField] private float swayWidth = 1.2f;

    [Header("Drop Item")]
    public GameObject starPrefab;

    [Header("Visual & Audio Effects")]
    public GameObject explosionPrefab; // Prefab hiệu ứng nổ
    public AudioClip explosionSound;   // Âm thanh tiếng nổ tung

    private float startX;
    private float timeOffset;
    private SpriteRenderer sr;

    private void Start()
    {
        currentHealth = maxHealth;
        startX = transform.position.x;
        timeOffset = Random.Range(0f, 10f);
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 1. Rơi xuống và lắc lư
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        float newX = startX + Mathf.Sin((Time.time + timeOffset) * swayFrequency) * swayWidth;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // 2. Nếu rơi quá mép dưới màn hình -> Tự hủy ngay lập tức
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;

        if (sr != null)
        {
            StartCoroutine(FlashRed());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (sr != null) sr.color = Color.white;
    }

    private void Die()
    {
        // 1. Phát âm thanh nổ tung
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main != null ? Camera.main.transform.position : transform.position);
        }

        // 2. Kích hoạt hiệu ứng tia lửa nổ
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // 3. Rơi ra đùi gà
        if (starPrefab != null)
        {
            Instantiate(starPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}