using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 16f;

    private void Start()
    {
        Destroy(gameObject, 2f); // Tự hủy sau 2 giây
    }

    private void Update()
    {
        // Đạn bay thẳng vút lên trên
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            // Báo cho Thiên thạch biết là nó bị bắn trúng (để rơi ra sao)
            Asteroid asteroid = other.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                asteroid.TakeDamage();
            }
            else
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject); // Hủy viên đạn
        }
    }
}