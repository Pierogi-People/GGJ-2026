using UnityEngine;

public class onClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray (origin: Camera.main.transform.position, direction: Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 500f))
            {
                Debug.Log("Hit " + hit.transform.name);
                if (hit.transform.tag == "Puzzle")
                {
                    hit.transform.rotation *= Quaternion.Euler(0, 0, 90f);
                }
                if (hit.transform.tag == "Breadkey")
                {
                    Debug.Log("register");
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}