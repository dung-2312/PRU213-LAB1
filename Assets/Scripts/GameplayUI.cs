using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if (scoreText != null && GameManager.Instance != null && Spawner.Instance != null)
        {
            scoreText.text = $"SCORE: {GameManager.Instance.currentScore}   |   WAVE: {Spawner.Instance.currentWave}";
        }
    }
}