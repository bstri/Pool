using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketBall : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Ball")
            rb.AddForce(collision.relativeVelocity.normalized*10, ForceMode.Impulse);
    }
}
