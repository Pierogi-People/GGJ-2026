using UnityEngine;

public class onClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 500f))
            {
                hit.transform.rotation *= Quaternion.Euler(0, 0, 90f);
            }
        }
    }
}