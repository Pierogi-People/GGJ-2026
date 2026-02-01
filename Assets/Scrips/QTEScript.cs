using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class QTEScript : MonoBehaviour
{
    private string[] qteChars = { "F", "E", "T", "T", "Y", "W", "A", "P", "T", "R", "A", "P", "Q", "U", "E", "E", "N"};
    private KeyCode[] qteInputs = { KeyCode.F, KeyCode.E, KeyCode.T, KeyCode.T, KeyCode.Y, KeyCode.W, KeyCode.A, KeyCode.P, KeyCode.T, KeyCode.R, KeyCode.A, KeyCode.P, KeyCode.Q, KeyCode.U, KeyCode.E, KeyCode.E, KeyCode.N };

    public float timePerEvent = 1.5f;
    private float timer;
    private float maxQTEs;
    private int completedQTEs;

    private GameObject completedText;
    private GameObject promptText;
    private GameObject timerBar;

    private GameObject failurePanel;
    private GameObject QTEPanel;

    private GameObject canvas;

    private float colourFlashTimer;

    private bool initiated = false;
    private bool buffer = false;

    public AudioResource beep;
    public AudioResource blowUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxQTEs = qteChars.Length;
        timer = timePerEvent;

        completedText = GameObject.Find("Completed");
        promptText = GameObject.Find("QTEPrompt");
        timerBar = GameObject.Find("CountDownOuter");
        canvas = GameObject.Find("QTECanvas");

        failurePanel = GameObject.Find("FailurePanel");
        failurePanel.SetActive(false);

        QTEPanel = GameObject.Find("QTEWindow");

        canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !initiated)
        {
            StartQTESequence();
        }

        if (initiated)
        {
            timer -= Time.deltaTime;
            colourFlashTimer -= Time.deltaTime;

            if (colourFlashTimer < 0.75f)
            {
                Beep();
                colourFlashTimer = 1.5f;
                if (QTEPanel.GetComponent<Image>().color == Color.red)
                {
                    QTEPanel.GetComponent<Image>().color = Color.blue;
                }
                else
                {
                    QTEPanel.GetComponent<Image>().color = Color.red;
                }
            }

            if (timer < 0)
            {
                QTEFailed();
            }

            if (Input.GetKeyDown(qteInputs[completedQTEs]))
            {
                if (!buffer)
                {
                    buffer = true;
                    return;
                }

                completedQTEs++;
                timePerEvent -= 0.05f;

                if (completedQTEs >= maxQTEs)
                {
                    QTEWon();
                    return;
                }

                SetNextQTE();
            }

            float timerCompletion = timer / timePerEvent;
            timerBar.GetComponent<RectTransform>().localScale = new Vector3(timerCompletion, 1f, 1f);
        }
    }

    void StartQTESequence()
    {
        timePerEvent = 1.5f;
        buffer = false;
        colourFlashTimer = 1.5f;
        failurePanel.SetActive(false);
        completedQTEs = 0;
        QTEPanel.SetActive(true);
        canvas.GetComponent<Canvas>().enabled = true;
        Camera.main.GetComponentInParent<PlayerMovement>().enabled = false;
        initiated = true;
        SetNextQTE();
        QTEPanel.GetComponent<Image>().color = Color.red;
    }

    void SetNextQTE()
    {
        promptText.GetComponent<TextMeshProUGUI>().text = qteChars[completedQTEs];
        timer = timePerEvent;
        completedText.GetComponent<TextMeshProUGUI>().text = completedQTEs + "/" + maxQTEs;
    }

    void QTEFailed()
    {
        failurePanel.SetActive(true);
        QTEPanel.SetActive(false);
        initiated = false;
        gameObject.GetComponent<AudioSource>().resource = blowUp;
        gameObject.GetComponent<AudioSource>().Play();
    }

    void QTEWon()
    {
        initiated = false;
        canvas.GetComponent<Canvas>().enabled = false;
        Camera.main.GetComponentInParent<PlayerMovement>().enabled = true;
    }

    void Beep()
    {
        gameObject.GetComponent<AudioSource>().resource = beep;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
