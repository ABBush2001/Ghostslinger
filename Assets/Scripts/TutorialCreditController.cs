using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialCreditController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI tutorialText;
    [SerializeField] TextMeshProUGUI creditText;

    [SerializeField] AudioSource buttonSound;

    public void openTutorial()
    {
        buttonSound.Play();
        panel.SetActive(true);
        tutorialText.enabled = true;
        creditText.enabled = false;
    }
    public void closeTutorial()
    {
        buttonSound.Play();
        panel.SetActive(false);
    }

    public void openCredits()
    {
        buttonSound.Play();
        panel.SetActive(true);
        creditText.enabled = true;
        tutorialText.enabled = false;
    }
    public void closeCredits()
    {
        buttonSound.Play();
        panel.SetActive(false);
    }
}
