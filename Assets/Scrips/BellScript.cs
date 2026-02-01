using UnityEngine;

public class BellScript : MonoBehaviour
{
    private float bellTimer = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bellTimer -= Time.deltaTime;
        if (bellTimer < 0 )
        {
            gameObject.GetComponent<AudioSource>().Play();
            bellTimer = 27f;
        }
    }
}
