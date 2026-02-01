using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private GameObject handPanel;
    private GameObject leftHandPanel;

    public float handDuration;
    private bool handActive;
    private float handTimer;

    public float timeBeforeFadeIn = 1f;

    private bool fadeTriggered = false;

    public float boatAmbVolume = 1f;
    public AudioResource boatAmbience;
    public float seaAmbVolume = 1f;
    public AudioResource seaAmbience;
    public float bunkerAmbVolume = 1f;
    public AudioResource bunkerAmbience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handPanel = GameObject.Find("HandPanel");
        handPanel.SetActive(false);
        leftHandPanel = GameObject.Find("LeftHandPanel");
        leftHandPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        switch (SceneManager.GetActiveScene().name)
        {
            case "above_ocean":
                GameObject.Find("Ambience").GetComponent<AudioSource>().resource = boatAmbience;
                GameObject.Find("Ambience").GetComponent<AudioSource>().volume = boatAmbVolume;
                break;
            case "Swimming Scene":
                GameObject.Find("Ambience").GetComponent<AudioSource>().resource = seaAmbience;
                GameObject.Find("Ambience").GetComponent<AudioSource>().volume = seaAmbVolume;
                break;
            default:
                GameObject.Find("Ambience").GetComponent<AudioSource>().resource = bunkerAmbience;
                GameObject.Find("Ambience").GetComponent<AudioSource>().volume = bunkerAmbVolume;
                break;
        }
        GameObject.Find("Ambience").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!handActive)
            {
                ActivateLeftHand();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (!handActive)
            {
                ActivateHand();
            }
        }

        if (!fadeTriggered)
        {
            timeBeforeFadeIn -= Time.deltaTime;

            if (timeBeforeFadeIn < 0)
            {
                GameObject.Find("Black").GetComponent<FadeToBlack>().fadeIn();
                fadeTriggered = true;
            }
        }

        if (handActive)
        {
            handTimer -= Time.deltaTime;
            if (handTimer < 0)
            {
                handPanel.SetActive(false);
                leftHandPanel.SetActive(false);
                handActive = false;
            }
        }
    }

    void ActivateLeftHand()
    {
        leftHandPanel.SetActive(true);
        handActive = true;
        handTimer = handDuration;
    }

    void ActivateHand()
    {
        handPanel.SetActive(true);
        handActive = true;
        handTimer = handDuration;
    }
}
