using UnityEngine;
using UnityEngine.SceneManagement;

public class BunkerEntrance : MonoBehaviour
{
    private bool playerInside;
    private bool awaitingFade;
    private GameObject blackScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInside = false;
        awaitingFade = false;
        blackScreen = GameObject.Find("Black");
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.GetComponent<AudioSource>().Play();
                awaitingFade = true;
                blackScreen.GetComponent<FadeToBlack>().fadeOut();
            }
        }
        
        if (awaitingFade)
        {
            if (blackScreen.GetComponent<FadeToBlack>().completedFade)
            {
                SceneManager.LoadScene("Puzzle_1");
                awaitingFade = false;
            }
        }
    }

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
