using UnityEngine;

public class QTEScript : MonoBehaviour
{
    private char[] qteChars = { 'F', 'E', 'T', 'T', 'Y', 'W', 'A', 'P', 'F', 'E', 'T', 'T', 'Y', 'W', 'A', 'P' };
    private KeyCode[] qteInputs = { KeyCode.F, KeyCode.E, KeyCode.T, KeyCode.T, KeyCode.Y, KeyCode.W, KeyCode.A, KeyCode.P, KeyCode.F, KeyCode.E, KeyCode.T, KeyCode.T, KeyCode.Y, KeyCode.W, KeyCode.A, KeyCode.P };

    public float timePerEvent;
    private float timer;
    private float maxQTEs;
    private float completedQTEs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
