using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionToFinalRoom : MonoBehaviour
{
    private bool playerInside;
    private GameObject blackScreen;
    private bool awaitingFade = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackScreen = GameObject.Find("Black");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && GameObject.FindGameObjectWithTag("Button").GetComponent<Puzzle3Manager>().Completed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                awaitingFade = true;
                blackScreen.GetComponent<FadeToBlack>().fadeOut();
                gameObject.GetComponent<AudioSource>().Play();
            }
        }

        if (awaitingFade)
        {
            if (blackScreen.GetComponent<FadeToBlack>().completedFade)
            {
                SceneManager.LoadScene("Final Room");
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
