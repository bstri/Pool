using UnityEngine;
using System.Collections;

public class camtest : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mouse);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}