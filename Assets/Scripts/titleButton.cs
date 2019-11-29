using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
