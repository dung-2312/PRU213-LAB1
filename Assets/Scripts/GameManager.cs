using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Quản lý điểm số, trạng thái game và chuyển đổi Scene.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Data")]
    public int currentScore = 0;

    private void Awake()
    {
        // Singleton pattern: Chỉ giữ lại 1 GameManager duy nhất
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Không bị hủy khi chuyển Scene
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void StartGame()
    {
        currentScore = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}