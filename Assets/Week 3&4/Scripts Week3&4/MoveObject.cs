using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    Rigidbody rb;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        //if (velocity.sqrMagnitude != 0)
        //{
           
        //    Quaternion forwardRotation = Quaternion.LookRotation(velocity);
        //    rb.MoveRotation(forwardRotation);

        //}
        


    }
}
