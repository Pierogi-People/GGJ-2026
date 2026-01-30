using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    #region "Variables"
    private Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(-(Input.GetAxis("Mouse Y") * MouseSensitivity), Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
    }
}
