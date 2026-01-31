using Unity.Mathematics;
using UnityEngine;

public class BoatRocking : MonoBehaviour
{

    private Quaternion startRotation;
    public float rockingSpeedMultiplier;
    public Vector3 rockingDirection;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.rotation;
    }



    // Update is called once per frame
    void Update()
    {
        float newAngle = Mathf.Sin(Time.time * rockingSpeedMultiplier);
        transform.rotation = startRotation * Quaternion.AngleAxis(newAngle, rockingDirection);
    }
}
