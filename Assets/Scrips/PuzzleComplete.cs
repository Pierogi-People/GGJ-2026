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
    public GameObject breadKey;

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
        if (!completed)
        {
            if (SceneManager.GetActiveScene().name == "Puzzle_1") { 
                if (TileRotationCorrect())
                {
                    completed = true;
                    Debug.Log("Puzzle Complete");
                }
            }
            if (SceneManager.GetActiveScene().name == "Puzzle_2")
            {
                if (GameObject.Find("BreadKey") == null)
                {
                    completed = true;
                    Debug.Log("bread Complete");
                }
            }
            
        }
        if(SceneManager.GetActiveScene().name == "Puzzle_1")
        {
            if (GameObject.Find("RotationPuzzle").GetComponent<PuzzleComplete>().completed)
            {
                GameObject.Find("ExitLight").GetComponent<Light>().color = Color.green;
            }
        }else if (SceneManager.GetActiveScene().name == "Puzzle_2")
        {
            if (GameObject.Find("BreadKey") == null)
            {
                GameObject.Find("ExitLight").GetComponent<Light>().color = Color.green;
                Debug.Log("bread Complete");
            }
        }


            if (playerInside && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Hit Inside");

                if(SceneManager.GetActiveScene().name == "Puzzle_1")
            {
                if (GameObject.Find("RotationPuzzle").GetComponent<PuzzleComplete>().completed)
                {
                    Debug.Log("Puzzle complete");
                    awaitingFade = true;
                    blackScreen.GetComponent<FadeToBlack>().fadeOut();
                }
            }
                if (SceneManager.GetActiveScene().name == "Puzzle_2")
                {
                    if (GameObject.Find("BreadKey") == null)
                    {
                        Debug.Log("Puzzle complete");
                        awaitingFade = true;
                        blackScreen.GetComponent<FadeToBlack>().fadeOut();

                    }

                }
            }

        if (awaitingFade)
        {
            if (blackScreen.GetComponent<FadeToBlack>().completedFade)
            {
                if (GameObject.Find("RotationPuzzle"))
                {
                    SceneManager.LoadScene("Puzzle_2");
                }
                if (SceneManager.GetActiveScene().name == "Puzzle_2")
                {
                    SceneManager.LoadScene("Puzzle_3");
                }
                
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
