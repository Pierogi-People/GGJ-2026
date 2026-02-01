using UnityEngine;
using UnityEngine.Audio;

public class Level3SpeechManager : MonoBehaviour
{
    public AudioResource Speech1;
    public AudioResource Speech2;

    public float speech1Delay = 2f;
    public bool awaitingSpeech1End = false;

    public float volume = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

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
                awaitingSpeech1End = true;
            }
        }
        else if (awaitingSpeech1End)
        {
            if (!GameObject.Find("Speech").GetComponent<AudioSource>().isPlaying)
            {
                awaitingSpeech1End = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }

    private void SpeakSpeech1()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = Speech1;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    public void SpeakSpeech2()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = Speech2;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }
}
