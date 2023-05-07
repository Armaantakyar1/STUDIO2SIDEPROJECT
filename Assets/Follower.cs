using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject Target;
    [SerializeField] float SteeringSpeed = 1f;
    [SerializeField] float MaxSpeed = 5f;
    private float currentSpeed;
    [SerializeField] float speed;

    private void Start()
    {
        currentSpeed = MaxSpeed;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        AddForce();
        CalculateMaxSpeed();
        LimitSpeed();
    }
    private float CalculateMaxSpeed()
    {
        float distance = Vector3.Distance(Target.transform.position, this.transform.position);
        return speed;
    }
    private void LimitSpeed()
    {
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    private void AddForce()
    {
        Vector3 Direction = Target.transform.position - transform.position;
        Direction = Direction.normalized;
        rb.velocity += Direction * SteeringSpeed;
    }
}
