using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Level2SpeechManager : MonoBehaviour
{
    public AudioResource Speech1;
    public AudioResource KeyReact;
    public AudioResource BreadReact;
    public AudioResource BreadBetter;
    public float volume = 1f;

    private bool breadChosen = false;
    private bool choiceMade = false;

    private bool speechTriggered = false;
    private bool awaitingSpeechEnd = true;

    public bool ignore = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ignore)
        {
            return;
        }

        if (breadChosen && awaitingSpeechEnd)
        {
            if (!GameObject.Find("Speech").GetComponent<AudioSource>().isPlaying)
            {
                SpeakBreadSpeech();
                awaitingSpeechEnd = false;
            }
        }
    }

    public void MakeChoice(string name)
    {
        if (ignore)
        {
            return;
        }

        if (!choiceMade)
        {
            if (name == "pane")
            {
                breadChosen = true;
                SpeakBreadBetter();
            }
            else
            {
                SpeakKeySpeech();
            }

            awaitingSpeechEnd = true;
            choiceMade = true;
        }
        else if (name == "pane")
        {
            if (!GameObject.Find("Speech").GetComponent<AudioSource>().isPlaying)
            {
                SpeakBreadSpeech();
            }
        }
    }

    public void SpeakSpeech1()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = Speech1;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    public void SpeakKeySpeech()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = KeyReact;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    public void SpeakBreadSpeech()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = BreadReact;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    public void SpeakBreadBetter()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = BreadBetter;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!speechTriggered)
            {
                GameObject.Find("SpeechDirector").GetComponent<Level2SpeechManager>().SpeakSpeech1();
                speechTriggered = true;
            }
        }
    }
}
