using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Vertical") * moveSpeed * -1, 0, Input.GetAxisRaw("Horizontal") * moveSpeed);
        rb.velocity = movement;
        //transform.rotation = Quaternion.LookRotation(movement);

        if (Input.anyKey)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        //animation
        if(movement.x > 0 || movement.x < 0 || movement.z > 0 || movement.z < 0)
        {
            anim.SetFloat("Speed", 1);
            Debug.Log("Running");
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }
}
