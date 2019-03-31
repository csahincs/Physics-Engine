using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 startingAcceleration;
    public Vector3 acceleration;
    public float damping;
    
    private cyclone.Particle particle = new cyclone.Particle();
    
    private void Start()
    {
        particle.InverseMass = 2.0f;
        particle.SetPosition(transform.position.x, transform.position.y, transform.position.z);
        particle.SetVelocity(velocity.x, velocity.y, velocity.z);
        particle.SetAcceleration(startingAcceleration.x, startingAcceleration.y, startingAcceleration.z);
        particle.Damping = damping;

        SetObjectPosition(particle.Position);
    }
    
    private void Update()
    {
        particle.SetAcceleration(acceleration.x, acceleration.y, acceleration.z);
        particle.Integrate(Time.deltaTime);
        SetObjectPosition(particle.Position);
    }
    
    private void SetObjectPosition(cyclone.Vector3 position)
    {
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);
    }
}
