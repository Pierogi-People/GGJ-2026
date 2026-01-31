using System;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour
{
    public GameObject[] puzzles;
    bool completed = false;
    bool TileRotationCorrect()
    {
        foreach (GameObject puzzle in puzzles)
        {
            float zRotation = puzzle.transform.eulerAngles.z;
            zRotation = Mathf.DeltaAngle(zRotation,0f);

            if (Mathf.Abs(zRotation) > 1f)
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        if (!completed  && TileRotationCorrect())
        {
            completed = true;
            Debug.Log("Puzzle Completed!");
        }
    }
}
