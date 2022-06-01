using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suricane : MonoBehaviour
{
    private float RotationSpeed;
    private Vector2 StartSpeed;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    public void SetForceAndRotation(Vector3 force, float rot)
    {
        RotationSpeed = rot;
        StartSpeed = force;
        rb.AddTorque(RotationSpeed);
        rb.AddForce(StartSpeed, ForceMode2D.Impulse);
    }

}
