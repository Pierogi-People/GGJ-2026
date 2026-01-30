using UnityEngine;

public class RotatingSquare : MonoBehaviour
{
    Vector3 rot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        print(rot);
    }
}
