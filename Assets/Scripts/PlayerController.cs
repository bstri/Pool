using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float minPower;
    public float maxPower;
    private float powerSlope;
    private float powerIntercept;

    private Rigidbody body;
    public bool CanMove = false;
    public float maxGuideLength = 12;
    public float minGuideLength = 1;

    private LineRenderer line;
    public GameObject Guide;
    public Camera cam;
    public GameObject cueGhost;

    private bool debounce = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        line = Guide.GetComponent<LineRenderer>();
        line.positionCount = 2;

        powerSlope = (maxPower - minPower) / (maxGuideLength - minGuideLength);
        powerIntercept = minPower - minGuideLength * powerSlope;
    }

    private void Update()
    {
        if (CanMove && !debounce)
        {
            // draw guide
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Vector3 guideVector = new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z);
            float guideLen = Math.Min(guideVector.magnitude, maxGuideLength);

            if (guideLen < minGuideLength)
            {
                line.enabled = false;
                return;
            }
            Vector3 normalGuide = guideVector.normalized;

            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + normalGuide*guideLen);

            // draw ghost cue
            RaycastHit cueHit;
            Physics.SphereCast(transform.position, .5f, normalGuide, out cueHit, 100, ~LayerMask.GetMask(new string[] { "Plane", "Ignore Raycast" }));
            cueGhost.SetActive(true);
            cueGhost.transform.position = transform.position + normalGuide * cueHit.distance;

            // receive mouse click
            if (Input.GetMouseButtonDown(0))
            {
                body.AddForce(normalGuide * (guideLen*powerSlope + powerIntercept), ForceMode.Impulse);
                debounce = true;
            }
        } else
        {
            line.enabled = false;
            cueGhost.SetActive(false);
            if(!CanMove)
            {
                debounce = false;
            }
        } 
    }
}
