using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shotCounter : MonoBehaviour
{
    LevelController level;
    Text shotsLeft;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelController>();
        shotsLeft = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        shotsLeft.text = level.numMovesRemaining.ToString();
    }
}
