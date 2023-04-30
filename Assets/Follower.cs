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

    private void Start()
    {
        currentSpeed = MaxSpeed;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        AddSteeringForce();

        var speed = CalculateMaxSpeed(MaxSpeed);
        LimitSpeed(speed);
    }
    private float CalculateMaxSpeed(float speed)
    {
        float distance = Vector3.Distance(Target.transform.position, this.transform.position);
        return speed;
    }
    private void LimitSpeed(float speed)
    {
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    private void AddSteeringForce()
    {
        Vector3 Direction = Target.transform.position - transform.position;
        Direction = Direction.normalized;
        rb.velocity += Direction * SteeringSpeed;
    }
}
