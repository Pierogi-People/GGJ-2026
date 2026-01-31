using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleComplete : MonoBehaviour
{
    public GameObject[] puzzles;
    public bool completed = false;
    private bool playerInside = false;
    private GameObject blackScreen;
    private bool awaitingFade = false;

    private void Start()
    {
        blackScreen = GameObject.Find("Black");
    }

    bool TileRotationCorrect()
    {
        foreach (GameObject puzzle in puzzles)
        {
            float zRotation = puzzle.transform.eulerAngles.z;
            zRotation = Mathf.DeltaAngle(zRotation, 0f);

            if (Mathf.Abs(zRotation) > 1f)
            {
                
                return false;
            }
        }
        
        return true;
    }

    void Update()
    {
        if (!completed && TileRotationCorrect())
        {
            completed = true;
            Debug.Log("Puzzle Complete");
            
        }
        if(GameObject.Find("RotationPuzzle").GetComponent<PuzzleComplete>().completed)
        {
            GameObject.Find("ExitLight").GetComponent<Light>().color = Color.green;
        }

        if (playerInside && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hit Inside");
            if (GameObject.Find("RotationPuzzle").GetComponent<PuzzleComplete>().completed)
            {

                Debug.Log("Puzzle complete");
                awaitingFade = true;
                blackScreen.GetComponent<FadeToBlack>().fadeOut();
            }
        }

        if (awaitingFade)
        {
            if (blackScreen.GetComponent<FadeToBlack>().completedFade)
            {
                SceneManager.LoadScene("Puzzle_2");
                awaitingFade = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }
}
