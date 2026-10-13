using System.Collections;
using UnityEngine;

/// <summary>
/// Quản lý từng đợt Gà thông minh:
/// Cứ hết gà trên màn hình là tự động chuyển sang Wave tiếp theo!
/// </summary>
public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [Header("Prefab")]
    public GameObject asteroidPrefab;

    [Header("Wave Info")]
    public int currentWave = 1;
    private float screenWidth;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Camera cam = Camera.main;
        if (cam != null)
        {
            screenWidth = cam.orthographicSize * cam.aspect;
        }

        // Bắt đầu chuỗi các đợt gà liên hoàn
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            // Số gà tăng dần theo từng Wave (Wave 1: 5 con, Wave 2: 7 con, Wave 3: 9 con...)
            int totalChickens = 3 + (currentWave * 2);

            // Sinh từng con gà rơi xuống
            for (int i = 0; i < totalChickens; i++)
            {
                SpawnSingleChicken();
                yield return new WaitForSeconds(1.2f);
            }

            // Chờ cho đến khi trên màn hình KHÔNG CÒN CON GÀ NÀO
            while (FindObjectsOfType<Asteroid>().Length > 0)
            {
                yield return new WaitForSeconds(0.5f);
            }

            // Nghỉ 2 giây mừng chiến thắng rồi lên Wave mới!
            yield return new WaitForSeconds(2f);
            currentWave++;
        }
    }

    private void SpawnSingleChicken()
    {
        if (asteroidPrefab == null) return;

        float randomX = Random.Range(-screenWidth + 0.8f, screenWidth - 0.8f);
        Vector3 spawnPos = new Vector3(randomX, 6f, 0);

        GameObject chicken = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        Asteroid ast = chicken.GetComponent<Asteroid>();
        if (ast != null)
        {
            // Máu của gà tăng theo Wave (Wave 1: 1 máu, Wave 2: 2 máu...)
            ast.maxHealth = currentWave;
        }
    }
}