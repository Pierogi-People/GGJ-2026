using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterWater : MonoBehaviour
{
    private GameObject blackScreen;
    private bool awaitingFade = false;
    public GameObject mask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackScreen = GameObject.Find("Black");
    }

    // Update is called once per frame
    void Update()
    {
        if (awaitingFade)
        {
            if (blackScreen.GetComponent<FadeToBlack>().completedFade)
            {
                SceneManager.LoadScene("SwimmingScene");
                awaitingFade = false;
            }
        }

        if (Camera.main.GetComponentInParent<PlayerMovement>().enabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mask.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            awaitingFade = true;
            blackScreen.GetComponent<FadeToBlack>().fadeOut();
        }
    }
}
