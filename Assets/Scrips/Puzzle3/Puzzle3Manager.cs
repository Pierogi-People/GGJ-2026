using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Puzzle3Manager : MonoBehaviour
{
    
    public Boolean Clear;
    public bool Check1;
    public bool Check2;
    public bool Check3;
    public bool Check4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check1 = GameObject.FindGameObjectWithTag("code_0").GetComponent<CodePuzzle>().Check1;
        Check2 = GameObject.FindGameObjectWithTag("code_1").GetComponent<CodePuzzle2>().Check2;
        Check3 = GameObject.FindGameObjectWithTag("code_2").GetComponent<CodePuzzle3>().Check3;
        Check4 = GameObject.FindGameObjectWithTag("code_3").GetComponent<CodePuzzle4>().Check4;

        if (Check1 == true && Check2 == true && Check3 == true && Check4 == true)
        {
            Clear = true;
        }
        else Clear = false;
    }

    void Press()
    {
        if (Clear == true)
        {
            //open door
        }
        else
        {
            //play voice line about it being the wrong code
        }
    }
}
