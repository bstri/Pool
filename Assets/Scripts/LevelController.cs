using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int numBalls;
    public int numMovesRemaining;

    PhysicsThreshold physicsController;

    // Start is called before the first frame update
    void Start()
    {
        numBalls = GameObject.FindGameObjectsWithTag("Ball").Length;

        physicsController = GetComponent<PhysicsThreshold>();
        if(physicsController == null)
        {
            print("physics controller not found!");
        }
    }

    public void BallSunk()
    {
        numBalls--;
    }

    public void CueSunk()
    {
        LevelFailed();
    }

    public void ShootCue()
    {
        numMovesRemaining--;
        physicsController.StartPhysicsCheck();
    }

    public void LevelFailed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // if loaded asynchronously, scratching on a winning shot will immediately go to the next level
    }

    public void ShotFinished()
    {
        if (numBalls == 0)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        } else if(numMovesRemaining == 0)
        {
            LevelFailed();
        }
    }
}
