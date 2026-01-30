using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    #region "Variables"
    private Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    private float vert;
    private float hori;
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (Input.GetAxis("Vertical") == 0)
        {
            vert = Input.GetAxis("Vertical") * MoveSpeed;
        }
        else
        {
           
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            hori = Input.GetAxis("Horizontal") * MoveSpeed;
        }
        else
        {

        }


            Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(-(Input.GetAxis("Mouse Y") * MouseSensitivity), Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * vert) + (transform.right * hori));
    }
}
