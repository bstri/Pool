using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsThreshold : MonoBehaviour
{
    List<Rigidbody> rigidBodies;

    public float speedThreshold = .1F;
    //public float spinThreshold = 5;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodies = new List<Rigidbody>(GameObject.FindObjectsOfType<Rigidbody>());
    }

    void FixedUpdate()
    {
        foreach(var rb in rigidBodies)
        {
            if(rb.velocity.magnitude < speedThreshold)
            {
                rb.velocity = new Vector3();
            }
        }
    }
}
