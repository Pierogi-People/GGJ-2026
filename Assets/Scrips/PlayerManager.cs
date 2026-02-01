using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject handPanel;
    private GameObject leftHandPanel;

    public float handDuration;
    private bool handActive;
    private float handTimer;

    public float timeBeforeFadeIn = 1f;

    private bool fadeTriggered = false;
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
