using UnityEngine;
using UnityEngine.Audio;

public class waterSpeechManager : MonoBehaviour
{
    public float volume = 1f;

    private float speech1Delay = 4f;
    private float speech3Delay = 2f;

    private bool speech2Active = false;
    private bool awaitingSpeech3 = false;
    public bool speechFinished = false;
    public bool awaitingEndOfSpeech = false;

    public AudioResource speech1;
    public AudioResource speech2;
    public AudioResource speech3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speech1Delay > 0)
        {
            speech1Delay -= Time.deltaTime;
            if (speech1Delay < 0)
            {
                SpeakSpeech1();
            }
        }
        else if (speech2Active)
        {
            if (!GameObject.Find("Speech").GetComponent<AudioSource>().isPlaying)
            {
                speech2Active = false;
                awaitingSpeech3 = true;
            }
        }
        else if (awaitingSpeech3)
        {
            if (speech3Delay > 0)
            {
                speech3Delay -= Time.deltaTime;
                if (speech3Delay < 0)
                {
                    SpeakSpeech3();
                    awaitingEndOfSpeech = true;
                    awaitingSpeech3 = false;
                }
            }
        }
        else if (awaitingEndOfSpeech)
        {
            if (!GameObject.Find("Speech").GetComponent<AudioSource>().isPlaying)
            {
                awaitingEndOfSpeech = false;
                speechFinished = true;
            }
        }
    }

    public void SpeakSpeech1()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech1;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }
    public void SpeakSpeech2()
    {
        speech2Active = true;
        awaitingSpeech3 = true;

        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech2;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }
    public void SpeakSpeech3()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech3;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }
}
