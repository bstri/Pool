using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The distance between the camera and the player object.
    private Vector3 offset;
    private GameObject player;

    // Start is called before the first frame update.
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update but before rendering the frame.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
