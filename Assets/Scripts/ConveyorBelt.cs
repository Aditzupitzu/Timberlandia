using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += Vector3.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
