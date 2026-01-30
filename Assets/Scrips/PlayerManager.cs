using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                EnterWater();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                ExitWater();
            }
        }
    }

    void EnterWater()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<WaterMovement>().enabled = true;
    }

    void ExitWater()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<WaterMovement>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
    }
}
