using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    [SerializeField] private GameObject eventSystem;
    [SerializeField] GameObject damagePanel;
    [SerializeField] AudioSource playerDamageSound;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            playerDamageSound.Play();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            StartCoroutine(damageDisplay());
        }
        else if(collision.gameObject.tag == "HatchetGhost")
        {
            playerDamageSound.Play();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            StartCoroutine(damageDisplay());
        }
        else if(collision.gameObject.tag == "DevilGhost")
        {
            playerDamageSound.Play();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            StartCoroutine(damageDisplay());
        }
    }

    IEnumerator damageDisplay()
    {
        damagePanel.SetActive(true);
        yield return new WaitForSeconds(1);
        damagePanel.SetActive(false);
    }
}
