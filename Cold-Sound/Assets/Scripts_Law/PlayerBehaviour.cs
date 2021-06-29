using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static bool isAlive;
    Rigidbody rb;
    public float m_Speed = 20f;
    public float m_torque = 0.1f;
    Vector3 m_EulerAngleVelocity;

    float smooth = 5.0f;
    float tiltAngle = 40f;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "IceWall")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dead zone") SetIsAlive(false);
    }

    public static void SetIsAlive(bool a_isAlive)
    {
        isAlive = a_isAlive;

        if (!isAlive) GameManager.Lose();
    }
}
