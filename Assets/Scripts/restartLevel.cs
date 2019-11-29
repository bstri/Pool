using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartLevel : MonoBehaviour
{
    LevelController level;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelController>();
        GetComponent<Button>().onClick.AddListener(() => level.LevelFailed());
    }
}
