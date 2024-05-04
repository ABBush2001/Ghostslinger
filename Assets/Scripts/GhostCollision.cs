using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    [SerializeField] private GameObject eventSystem;
    [SerializeField] GameObject damagePanel;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            StartCoroutine(damageDisplay());
        }
        else if(collision.gameObject.tag == "HatchetGhost")
        {
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            StartCoroutine(damageDisplay());
        }
        else if(collision.gameObject.tag == "DevilGhost")
        {
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
