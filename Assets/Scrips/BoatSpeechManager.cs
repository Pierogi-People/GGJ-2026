using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class BoatSpeechManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float volume = 1f;

    public AudioResource speech;
    public AudioResource speech2;
    private float speech1Delay = 95f;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpeakSpeech2();
        }
    }

    public void SpeakSpeech1()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

    public void SpeakSpeech2()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech2;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }

}
