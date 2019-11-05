using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsThreshold : MonoBehaviour
{
    List<Rigidbody> rigidBodies;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodies = new List<Rigidbody>(GameObject.FindObjectsOfType<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
