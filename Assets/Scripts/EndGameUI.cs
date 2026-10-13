using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void Start()
    {
        // Hiển thị điểm số đạt được từ GameManager
        if (finalScoreText != null && GameManager.Instance != null)
        {
            finalScoreText.text = "FINAL SCORE: " + GameManager.Instance.currentScore;
        }
    }

    public void OnPlayAgainClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame(); // Chơi lại Gameplay
        }
    }

    public void OnMainMenuClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadMainMenu(); // Về Menu chính
        }
    }

    public void OnQuitClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.QuitGame(); // Thoát game
        }
    }
}