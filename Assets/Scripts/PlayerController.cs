using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    private Rigidbody body;
    private bool CanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // FixedUpdate runs once before each tick of the physics system.
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            CanMove = true;
        }
        else if (CanMove)
        {
            CanMove = false;
            body.AddForce(new Vector3(horizontalMovement, 0, verticalMovement)*Speed, ForceMode.Impulse);
        }
        else
            return;
    }
}
