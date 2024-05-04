using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelOpening : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI openingText;
    [SerializeField] GameObject panel;

    private bool animFinished;

    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(opening());
    }


    public bool getAnimFinished()
    {
        return animFinished;
    }
    public void setAnimFinished(bool value)
    {
        animFinished = value;
    }

    IEnumerator opening()
    {
        animFinished = false;
        yield return new WaitForSeconds(5);
        openingText.text = "Level Starting In 5...";
        yield return new WaitForSeconds(1);
        openingText.text = "Level Starting In 4...";
        yield return new WaitForSeconds(1);
        openingText.text = "Level Starting In 3...";
        yield return new WaitForSeconds(1);
        openingText.text = "Level Starting In 2...";
        yield return new WaitForSeconds(1);
        openingText.text = "Level Starting In 1...";
        yield return new WaitForSeconds(1);
        openingText.text = "Level Starting In 0...";
        yield return new WaitForSeconds(1);

        openingText.text = "";
        panel.SetActive(false);
        animFinished = true;
    }
}
