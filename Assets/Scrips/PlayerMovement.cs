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
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
        Cam = Camera.main;
        currentTilt = 0f;
    }

    void Update()
    {
        float multi = 1;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            multi = sprintMultiplier;
        }

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
    }
}
