using UnityEngine;
using UnityEngine.Video;

public class OpeningCameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 playerCameraPosition;
    private Quaternion playerCameraRotation;
    public Camera playerCamera;
    private VideoPlayer introVideo;
    private Vector3 startPosition;
    private bool startMoving;
    private float startTime;
    private float distance;
    private float startFov;
    private float endFov;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float mouseSensitivity; 
    public float transitionSpeed = 1f;


    void Start()
    {
        introVideo = GameObject.FindGameObjectWithTag("IntroVideo").gameObject.GetComponent<VideoPlayer>();
        startRotation = transform.rotation;
        endRotation = playerCamera.transform.rotation;
        startPosition = gameObject.GetComponent<Camera>().transform.position;
        startMoving = false;
        startFov = gameObject.GetComponent<Camera>().fieldOfView;
        endFov = playerCamera.fieldOfView;

        playerCamera.GetComponentInParent<PlayerMovement>().enabled = false;


        distance = Vector3.Distance(transform.position, playerCameraPosition);
    }

    // Update is called once per frame
    void Update()
    {
        introVideo.loopPointReached += moveCamera;
        if (startMoving) {
            float distanceCovered = (Time.time - startTime) * transitionSpeed;
            float fractionOfDistance = distanceCovered / distance;
            //Interpolate distance
            transform.position = Vector3.Lerp(startPosition, playerCameraPosition, fractionOfDistance);
            //Interpolate FOV
            gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(startFov, endFov, fractionOfDistance);
            //Interpolate rotation
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, fractionOfDistance);
            if (distanceCovered >= distance)
            {
                playerCamera.GetComponentInParent<PlayerMovement>().enabled = true;
                gameObject.SetActive(false);
            }
        }
        else
        {
            playerCameraPosition = playerCamera.transform.position;
        }

        
    }

    void moveCamera(UnityEngine.Video.VideoPlayer player)
    {
            startMoving = true;
            startTime = Time.time;
    }
}
    