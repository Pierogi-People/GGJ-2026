using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Turns the light on
        myLight.enabled = true;

        // Turns the light off
        myLight.enabled = false;
    }

    // Update is called once per frame
    public Light myLight;
    public float interval = 1;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            timer -= interval;
        }
    }
}
