using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletHolder;
    [SerializeField] Animator playerAnim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerAnim.GetBool("HasWeapon"))
        {
            playerAnim.SetTrigger("Fired");
            Shoot();
        }    
    }

    void Shoot()
    {
        // Raycast from camera to mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Calculate direction to shoot
            Vector3 direction = hit.point - transform.position;
            direction.y = 0; // Ignore vertical component

            // Spawn bullet and set its direction
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody>().velocity = direction.normalized * 10;
        }
    }
}
