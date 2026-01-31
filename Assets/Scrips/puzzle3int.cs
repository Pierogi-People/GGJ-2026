using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngineInternal;

public class puzzle3int : MonoBehaviour
{
    public bool completed;
    
  

    // Update is called once per frame
    void Update()
    {
        GameObject btn = GameObject.FindGameObjectWithTag("code_4");
        var btnColour = btn.GetComponent<Renderer>();
        bool completed = gameObject.GetComponent<Puzzle3Manager>().Clear;
        if (completed == true)
        {
            btnColour.material.SetColor("_BaseColor", Color.green);
        }
    }
}
