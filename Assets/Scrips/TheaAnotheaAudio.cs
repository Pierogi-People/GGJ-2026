using System.Collections;
using UnityEngine;

public class TheaAnotheaAudio : MonoBehaviour
{


    // Thea call out
    // Light on 
    // Thea convo
    //QTE
    // Thea convo
    // Light on anothera
    // Anothera convo
    // Thea vanishes
    // Pre-Nuke Convo
    // Post-Nuke Convo

    public AudioClip theaCall;
    public AudioClip theaConvo;
    public AudioClip theaConvo2;
    public AudioClip anotheraConvo;
    public AudioClip prenukeConvo;
    public AudioClip postnukeConvo;

    public AudioSource playerAudio;
    public PlayerMovement playerMovement;
    public FadeToBlack FadeToBlack;

    public GameObject theaLight;
    public GameObject anotheaLight;
    public GameObject bombLight;
    public QTEScript QTE;
    public GameObject bombFlash;
    public GameObject nuke; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement.enabled = false;
        StartCoroutine(StartFinalSequence());
    }

    IEnumerator StartFinalSequence()
    {
        yield return StartCoroutine(WaitForFadeIn());
        
        Debug.Log("Faded In");

        yield return StartCoroutine(PlayAudioAndWait(theaCall));

        theaLight.SetActive(true);
        Debug.Log("tealight");

        yield return StartCoroutine(PlayAudioAndWait(theaConvo));

        bombLight.SetActive(true);
        playerMovement.enabled = true;
        Debug.Log("bomb-on");
        yield return StartCoroutine(WaitForDefuse());


        yield return StartCoroutine(PlayAudioAndWait(theaConvo2));
        anotheaLight.SetActive(true);
        yield return StartCoroutine(PlayAudioAndWait(anotheraConvo));
        theaLight.SetActive(false);
        yield return StartCoroutine(PlayAudioAndWait(prenukeConvo));
        yield return StartCoroutine(PlayAudioAndWait(postnukeConvo));


        yield return null;
    }
    IEnumerator PlayAudioAndWait(AudioClip audioClip)
    {
        playerAudio.clip = audioClip;
        playerAudio.Play();
        while (playerAudio.isPlaying)
        {
            yield return null;
        }

    }

    IEnumerator WaitForDefuse()
    {
        while(QTE.defused == false)
        {
            yield return null;        
        }
        bombFlash.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
    }

    IEnumerator WaitForFadeIn()
    {
        while (FadeToBlack.alpha < 0.1f)
        {
            Debug.Log(FadeToBlack.alpha);
            yield return null;
        }

        


    }

    // Update is called once per frame
    void Update()
    {

    }
}
