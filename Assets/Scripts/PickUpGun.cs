using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject playerHand;

    public GameObject eventSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && eventSystem.GetComponent<LevelOpening>().getAnimFinished())
        {
            playerAnim.SetBool("HasWeapon", true);

            //place weapon into player's hand
            gun.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
