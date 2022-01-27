using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float gravitationalForce;

    public SphereCollider sphereCollider1;

    Rigidbody rigidBody;

    Vector3 direction;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDirectionToTheBlackHole();

        SetGravity();
    }


    private void CalculateDirectionToTheBlackHole()
    {
        direction = (target.position - transform.position).normalized;
    }
    private void SetGravity()
    {
        rigidBody.AddForce(direction * gravitationalForce, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == gameObject.CompareTag("Player"))
        {
            gravitationalForce *= 1.2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == gameObject.CompareTag("Player"))
        {
            gravitationalForce /= 1.2f;
        }
    }
}
