using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Rigidbody body;
    private bool CanMove = false;
    private float maxGuideLength = 6;

    public GameObject guide;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CanMove)
        {
            // draw guide
            Ray ray = cam.


            // receive mouse click
            if (Input.GetMouseButtonDown(0))
            {
                body.AddForce(new Vector3(horizontalMovement, 0, verticalMovement) * Speed, ForceMode.Impulse);
                CanMove = false;

            }
        }
    }
}
