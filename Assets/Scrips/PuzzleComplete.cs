using System;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour
{
    public GameObject[] puzzles = new GameObject[9];
    void Start()
    {
        print(puzzles.Length);
    }

    void Update()
    {
    }
}
