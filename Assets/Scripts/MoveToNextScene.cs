using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextScene : MonoBehaviour
{
    public GameObject levelManager;
    public GameObject virtualCamera;
    public GameObject mainCamera;

    public GameObject player;

    [SerializeField] AudioSource buttonSound;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    public void LoadNextScene()
    {
        StartCoroutine(FadeOutToNextScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void ReloadScene()
    {
        StartCoroutine(FadeOutToNextScene(SceneManager.GetActiveScene().buildIndex));
    }
    public void GoToMainMenu()
    {
        StartCoroutine(FadeOutToNextScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator FadeOutToNextScene(int buildIndexNum)
    {
        buttonSound.Play();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 1f;
            player.GetComponent<CapsuleCollider>().isTrigger = true;
            virtualCamera.GetComponent<CameraFadeOut>().fadeOut = true;
            Debug.Log("Fade out started!");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(buildIndexNum);
        }
        else
        {
            mainCamera.GetComponent<CameraFadeOut>().fadeOut = true;
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(buildIndexNum);
        }
    }
}
