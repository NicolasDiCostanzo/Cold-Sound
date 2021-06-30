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
    public Animator anim;

    float smooth = 5.0f;
    public float tiltAngle = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 1, 0);
       // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.down * Time.fixedDeltaTime * tiltAngle);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.fixedDeltaTime * tiltAngle);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                rb.AddForce(transform.forward * m_Speed, ForceMode.Force);
                anim.SetBool("IsWalking", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(transform.forward * -m_Speed, ForceMode.Force);
                anim.SetBool("IsWalking", true);
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("IsWalking", false);
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dead zone")
        {
            SetIsAlive(false);
            EndGameCanvasHandler GameOverCanvas = FindObjectOfType<EndGameCanvasHandler>();
            GameOverCanvas.Loose(1);
        }
    }

    public static void SetIsAlive(bool a_isAlive)
    {
        isAlive = a_isAlive;

        if (!isAlive) GameManager.Lose();
    }

}
