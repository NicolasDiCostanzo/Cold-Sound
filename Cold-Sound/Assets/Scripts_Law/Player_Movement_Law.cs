using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Law : MonoBehaviour
{
    Rigidbody rb;
    public float m_Speed = 20f;
    public float m_torque = 0.1f;
    Vector3 m_EulerAngleVelocity;
    public static bool isAlive = true;

    float smooth = 5.0f;
    public float tiltAngle = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * tiltAngle);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * tiltAngle);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(transform.forward * m_Speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -m_Speed, ForceMode.Force);
        }  
    }
    private void FixedUpdate()
    {
        //Quaternion deltaRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //if(deltaRotation.eulerAngles.magnitude > 0)
        //{
        //    rb.AddTorque(-m_EulerAngleVelocity, ForceMode.Force);
        //}
        Debug.Log(rb.velocity.y);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       // if(collision.gameObject.tag == "IceWall")
       // {
       //     rb.constraints = RigidbodyConstraints.FreezeRotationY;
       //     rb.constraints = RigidbodyConstraints.None;
       //     rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
       // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dead zone") SetIsAlive(false);
    }

    public static void SetIsAlive(bool a_isAlive)
    {
        isAlive = a_isAlive;

        if (!isAlive) GameManager.Lose();
    }

}
