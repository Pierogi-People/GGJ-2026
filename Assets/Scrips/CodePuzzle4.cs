using System;
using UnityEngine;

public class CodePuzzle4 : MonoBehaviour
{
    public Boolean Check4;
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
            Check4 = false;
            CodeMaterial.mainTexture = Code0;
        }
        if (Count == 1)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code1;
        }
        if (Count == 2)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code2;
        }
        if (Count == 3)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code3;
        }
        if (Count == 4)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code4;
        }
        if (Count == 5)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code5;
        }
        if (Count == 6)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code6;
        }
        if (Count == 7)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code7;
        }
        if (Count == 8)
        {
            Check4 = true;
            CodeMaterial.mainTexture = Code8;
        }
        if (Count == 9)
        {
            Check4 = false;
            CodeMaterial.mainTexture = Code9;

        }

        if (Count > 9)
        {
            Count = 0;
        }
    }
}
