using UnityEngine;
using UnityEngine.Rendering;

public class BombVolume : MonoBehaviour
{
    public bool playerInside;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }
}
