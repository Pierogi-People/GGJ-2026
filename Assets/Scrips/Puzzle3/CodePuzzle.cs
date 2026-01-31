using System;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    public Boolean Check1;
    public int Count;
    public Material CodeMaterial;
    public Texture Code0;
    public Texture Code1;
    public Texture Code2;
    public Texture Code3;
    public Texture Code4;
    public Texture Code5;
    public Texture Code6;
    public Texture Code7;
    public Texture Code8;
    public Texture Code9;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 0)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code0;
        }
        if (Count == 1)
        {
            Check1 = true;
            CodeMaterial.mainTexture = Code1;
        }
        if (Count == 2)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code2;
        }
        if (Count == 3)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code3;
        }
        if (Count == 4)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code4;
        }
        if (Count == 5)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code5;
        }
        if (Count == 6)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code6;
        }
        if (Count == 7)
        {
            Check1 = true;
            CodeMaterial.mainTexture = Code7;
        }
        if (Count == 8)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code8;
        }
        if (Count == 9)
        {
            Check1 = false;
            CodeMaterial.mainTexture = Code9;

        }

        if (Count > 9)
        {
            Count = 0;
        }
    }
}
