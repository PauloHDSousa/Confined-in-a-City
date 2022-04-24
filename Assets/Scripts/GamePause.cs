using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{

    [SerializeField]
    GameObject PauseCanvas;

    [SerializeField]
    GameObject TutorialMessages;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip onClickedSound;
    [SerializeField]
    AudioClip onPausedSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsGameOver)
        {
            if (GameManager.Instance.isPaused)
            {
                ResumeGame();
            }
            else
            {
                GameManager.Instance.isPaused = true;
                audioSource.PlayOneShot(onPausedSound);
                audioSource.volume = 0.1f;
                PauseCanvas.SetActive(true);
                if (TutorialMessages != null)
                    TutorialMessages.SetActive(false);
                Time.timeScale = 0;
            }
        }

    }

    public void ResumeGame()
    {
        GameManager.Instance.isPaused = false;
        audioSource.PlayOneShot(onClickedSound);
        audioSource.volume = 0.3f;
        PauseCanvas.SetActive(false);
        if (TutorialMessages != null)
            TutorialMessages.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        audioSource.PlayOneShot(onClickedSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        audioSource.PlayOneShot(onClickedSound);
        SceneManager.LoadScene("Menu");
    }
}
