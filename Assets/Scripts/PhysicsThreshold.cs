using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsThreshold : MonoBehaviour
{
    List<Rigidbody> rigidBodies;
    public PlayerController controller;

    public float speedThreshold = .1F;
    //public float spinThreshold = 5;

    private LevelController level;

    private bool doCheck = false;
    private bool motionStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelController>();

        rigidBodies = new List<Rigidbody>(GameObject.FindObjectsOfType<Rigidbody>());
    }

    public void StartPhysicsCheck()
    {
        doCheck = true;
        motionStarted = false;
    }

    void FixedUpdate()
    {
        if (!doCheck)
            return;

        bool stillMoving = false;
        for(int i = rigidBodies.Count - 1; i >= 0; i--)
        {
            var rb = rigidBodies[i];
            if (rb == null)
            {
                rigidBodies.Remove(rb);
                continue;
            }

            if(rb.velocity.magnitude < speedThreshold)
            {
                rb.velocity = new Vector3();
            } else
            {
                stillMoving = true;
            }
        }

        if (!stillMoving && motionStarted)
        {
            controller.CanMove = true;
            doCheck = false;
            level.ShotFinished();
        } else
        {
            motionStarted = true;
            controller.CanMove = false;
        }
    }
}
