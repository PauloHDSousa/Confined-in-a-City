using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    GameObject GameOverCanvas;

    [SerializeField]
    TMP_Text txtRecord;

    public bool IsGameOver = false;
    public int currentWave = 0;
    public int enemiesperWave = 5;
    public int currentEnemies = 0;
    public int enemiesKilled = 0;
    public int totalEnemiesKilled = 0;

    public bool isPaused = false;

    public bool soundEnabled = true;

    [SerializeField]
    AudioSource audioSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    private void Start()
    {
        GoToNextWave();
    }

    public void GameOver()
    {
        audioSource.volume = 0.1f;
        Invoke("ShowGameOver", 1f);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        txtRecord.SetText("YOU DESTROYED " + totalEnemiesKilled + " ROBOTS");
        GameOverCanvas.SetActive(true);
    }

    public void GoToNextWave()
    {
        var bullets = GameObject.FindObjectsOfType<EnemyBullet>();
        foreach (var bullet in bullets)
            Destroy(bullet.gameObject);

        currentWave++;
        currentEnemies = 0;
        enemiesKilled = 0;
        enemiesperWave = currentWave * enemiesperWave;
    }
}
