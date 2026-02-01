using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public float fadeRate;

    private bool fadingOut = false;
    private bool fadingIn = false;
    public float alpha = 1f;
    public bool completedFade = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            alpha -= (fadeRate * Time.deltaTime) / 5;
            if (alpha < 0.0f)
            {
                alpha = 0.0f;
                fadingIn = false;
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
