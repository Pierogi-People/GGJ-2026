using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerManager : MonoBehaviour
{
    private GameObject maskPanel;
    private GameObject handPanel;

    public float handDuration;
    private bool handActive;
    private float handTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskPanel = GameObject.Find("MaskPanel");
        maskPanel.SetActive(false);
        handPanel = GameObject.Find("HandPanel");
        handPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                EnterWater();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                ExitWater();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                ToggleMask();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!handActive)
                {
                    ActivateHand();
                }
            }
        }

        if (handActive)
        {
            handTimer -= Time.deltaTime;
            if (handTimer < 0)
            {
                handPanel.SetActive(false);
                handActive = false;
            }
        }
    }

    void EnterWater()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<WaterMovement>().enabled = true;
    }

    void ExitWater()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<WaterMovement>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
    }

    void ToggleMask()
    {
        maskPanel.SetActive(!maskPanel.activeSelf);
    }

    void ActivateHand()
    {
        handPanel.SetActive(true);
        handActive = true;
        handTimer = handDuration;
    }
}
