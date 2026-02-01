using UnityEngine;
using UnityEngine.SceneManagement;

public class BunkerEntrance : MonoBehaviour
{
    private bool playerInside;
    private bool awaitingFade;
    private GameObject blackScreen;

    private bool speechTriggered = false;

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
            if (Input.GetKeyDown(KeyCode.F) && GameObject.Find("SpeechManager").GetComponent<waterSpeechManager>().speechFinished)
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

            if (!speechTriggered)
            {
                GameObject.Find("SpeechManager").GetComponent<waterSpeechManager>().SpeakSpeech2();
                speechTriggered = true;
            }
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
