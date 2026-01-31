using UnityEngine;
using UnityEngineInternal;

public class onClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray (origin: Camera.main.transform.position, direction: Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 500f))
            {
                if (hit.transform.tag == "Puzzle")
                {
                    hit.transform.rotation *= Quaternion.Euler(0, 0, 90f);
                }
                if (hit.transform.tag == "Breadkey")
                {
                    hit.transform.gameObject.SetActive(false);
                }
                if(hit.transform.tag == "code_0")
                {
                    hit.transform.gameObject.GetComponent<CodePuzzle>().Count += 1;
                }
                if(hit.transform.tag == "code_1")
                {
                    hit.transform.gameObject.GetComponent<CodePuzzle2>().Count += 1;
                }
                if(hit.transform.tag == "code_2")
                {
                    hit.transform.gameObject.GetComponent<CodePuzzle3>().Count += 1;
                }
                if(hit.transform.tag == "code_3")
                {
                    hit.transform.gameObject.GetComponent<CodePuzzle4>().Count += 1;
                }
            }
        }
    }
}