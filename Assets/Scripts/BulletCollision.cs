using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] AudioSource ghostDeathSound;

    private void Start()
    {
        ghostDeathSound = GameObject.Find("GhostHitSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            ghostDeathSound.Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
