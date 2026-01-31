using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeToBlack : MonoBehaviour
{
    public float fadeRate;

    private bool fadingOut;
    private bool fadingIn;
    private float alpha;
    public bool completedFade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadingIn = false;
        fadingOut = false;
        completedFade = false;
        alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            alpha -= fadeRate * Time.deltaTime;
            if (alpha < 0.0f)
            {
                alpha = 0.0f;
                fadingIn = false;
                completedFade = true;
            }
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, alpha);
        }
        else if (fadingOut)
        {
            alpha += fadeRate * Time.deltaTime;

            if (alpha > 1.0f)
            {
                alpha = 1.0f;
                fadingOut = false;
                completedFade = true;
            }
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, alpha);
        }
    }

    public void fadeOut()
    {
        alpha = 0.0f;
        fadingOut = true;
    }

    public void fadeIn()
    {
        alpha = 1.0f;
        fadingIn = true;
    }
}
