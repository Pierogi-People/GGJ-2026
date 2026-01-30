using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region "Variables"
    private Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float sprintMultiplier;
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
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
    }
}
