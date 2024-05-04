using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    [SerializeField] private GameObject eventSystem;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ghost")
        {
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
        }
        else if(collision.gameObject.tag == "HatchetGhost")
        {
            eventSystem.GetComponent<PlayerHealthManager>().damage();
        }
        else if(collision.gameObject.tag == "DevilGhost")
        {
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
            eventSystem.GetComponent<PlayerHealthManager>().damage();
        }
    }
}
