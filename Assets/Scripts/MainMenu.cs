using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    AudioClip onClickedSound;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    TMP_Text tmpSound;

    private void Start()
    {
        if (AudioListener.volume == 0)
            tmpSound.SetText("ENABLE SOUND");
        else
            tmpSound.SetText("DISABLE SOUND");
    }

    public void PlayGame()
    {
       
        audioSource.PlayOneShot(onClickedSound);
        SceneManager.LoadScene("Game");
    }

    public void HowToPlay()
    {
        audioSource.PlayOneShot(onClickedSound);
        SceneManager.LoadScene("HowToPlay");
    }

    public void DisableSound()
    {
        if (AudioListener.volume == 0)
        {
            tmpSound.SetText("DISABLE SOUND");
            AudioListener.volume = 1;
        }
        else
        {
            tmpSound.SetText("ENABLE SOUND");
            AudioListener.volume = 0;
        }
    }

    public void Quit()
    {
        audioSource.PlayOneShot(onClickedSound);
        Application.Quit();
    }
}
