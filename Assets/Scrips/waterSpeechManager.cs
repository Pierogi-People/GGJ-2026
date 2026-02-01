using UnityEngine;
using UnityEngine.Audio;

public class waterSpeechManager : MonoBehaviour
{
    public float volume = 1f;

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

    }

    public void SpeakSpeech1()
    {
        GameObject.Find("Speech").GetComponent<AudioSource>().resource = speech1;
        GameObject.Find("Speech").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("Speech").GetComponent<AudioSource>().Play();
    }
    public void SpeakSpeech2()
    {
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
