using UnityEngine;

public class onClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                    Debug.Log("register");
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}