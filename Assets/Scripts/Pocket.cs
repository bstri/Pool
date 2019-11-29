using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    private LevelController level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            level.BallSunk();
        } else if(other.gameObject.tag == "Player")
        {
            level.CueSunk();
        }

        // todo some sort of disappearing animation would be cool
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
