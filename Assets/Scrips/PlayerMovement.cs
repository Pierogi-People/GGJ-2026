using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region "Variables"
    private Rigidbody Rigid;
    private Camera Cam;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float sprintMultiplier;
    public float upperCameraBounds;
    public float lowerCameraBounds;
    private float currentTilt;
    public float tiltSpeed;
    private GameObject maskPanel;
    public bool maskEnabledDefault = false;
    public bool canUseMask = true;
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
        Cam = Camera.main;
        currentTilt = 0f;

        maskPanel = GameObject.Find("MaskPanel");
        maskPanel.SetActive(maskEnabledDefault);
        if (maskPanel.activeSelf)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    void Update()
    {
        float multi = Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1;

        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * (MoveSpeed * multi)) + (transform.right * Input.GetAxis("Horizontal") * (MoveSpeed * multi)));

        currentTilt -= (Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime * tiltSpeed);
        if (currentTilt > upperCameraBounds)
        {
            currentTilt = upperCameraBounds;
        }
        else if (currentTilt < lowerCameraBounds)
        {
            currentTilt = lowerCameraBounds;
        }
        Cam.transform.localRotation = new Quaternion(currentTilt, 0, 0, 1);

        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMask();
        }
    }

    void ToggleMask()
    {
        if (!canUseMask)
        {
            return;
        }

        maskPanel.SetActive(!maskPanel.activeSelf);

        if (maskPanel.activeSelf)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
