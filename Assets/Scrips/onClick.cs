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
                    hit.transform.gameObject.GetComponentInParent<AudioSource>().Play();
                }
                if (hit.transform.tag == "Breadkey")
                {
                    GameObject.Find("Eating").GetComponent<AudioSource>().Play();
                    hit.transform.gameObject.SetActive(false);
                }

                if(hit.transform.tag == "code_0")
                {
                    if (GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
                    {
                        return;
                    }
                    hit.transform.gameObject.GetComponent<CodePuzzle>().Count += 1;
                }
                if(hit.transform.tag == "code_1")
                {
                    if (GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
                    {
                        return;
                    }
                    hit.transform.gameObject.GetComponent<CodePuzzle2>().Count += 1;
                }
                if(hit.transform.tag == "code_2")
                {
                    if (GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
                    {
                        return;
                    }
                    hit.transform.gameObject.GetComponent<CodePuzzle3>().Count += 1;
                }
                if(hit.transform.tag == "code_3")
                {
                    if (GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
                    {
                        return;
                    }
                    hit.transform.gameObject.GetComponent<CodePuzzle4>().Count += 1;
                }
                if(hit.transform.tag == "Button")
                {
                    if (GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
                    {
                        return;
                    }
                    hit.transform.gameObject.GetComponent<Puzzle3Manager>().hitButton();
                }
            }
        }
    }
}