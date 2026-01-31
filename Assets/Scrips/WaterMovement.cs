using System.Runtime.CompilerServices;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    #region "Variables"
    private Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    private float vert;
    private float hori;
    public float driftDistance;
    #endregion

    private void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                horiDropoff();
            }
            else if (Input.GetKey(KeyCode.A)) {
                hori = -MoveSpeed;
            }
            else
            {
                hori = MoveSpeed;
            }
        }
        else
        {
            horiDropoff();
        }


        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                vertDropoff();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                vert = MoveSpeed;
            }
            else
            {
                vert = -MoveSpeed;
            }
        }
        else
        {
            vertDropoff();
        }



        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(-(Input.GetAxis("Mouse Y") * MouseSensitivity), Input.GetAxis("Mouse X") * MouseSensitivity, 0)));

        Rigid.MovePosition(Rigid.transform.position + (Rigid.transform.forward * vert) + (Rigid.transform.right * hori));
    }

    private void vertDropoff()
    {
        if (vert == 0)
        {
            return;
        }
        else if (vert < 0)
        {
            vert += driftDistance * Time.deltaTime;
            if (vert > 0)
            {
                vert = 0;
            }
        }
        else if (vert > 0)
        {
            vert -= driftDistance * Time.deltaTime;
            if (vert < 0)
            {
                vert = 0;
            }
        }
    }

    private void horiDropoff()
    {
        if (hori == 0)
        {
            return;
        }
        else if (hori < 0)
        {
            hori += driftDistance * Time.deltaTime;
            if (hori > 0)
            {
                hori = 0;
            }
        }
        else if (hori > 0)
        {
            hori -= driftDistance * Time.deltaTime;
            if (hori < 0)
            {
                hori = 0;
            }
        }
    }
}