using UnityEngine;

public class Cable : MonoBehaviour
{
    private cyclone.ParticleCable particleCable = new cyclone.ParticleCable();

    private cyclone.ParticleContactResolver contactResolver = new cyclone.ParticleContactResolver(1);
    
    public Transform object1;
    public Transform object2;

    private cyclone.Particle particle1 = new cyclone.Particle();
    private cyclone.Particle particle2 = new cyclone.Particle();

    private void Start()
    {
        particle1.InverseMass = 2.0f;
        particle1.Damping = 0.95f;
        particle1.SetVelocity(0.0f, 0.0f, 0.0f);
        particle1.SetAcceleration(0.0f, 0f, 0.0f);
        particle1.SetPosition(object1.transform.position.x, object1.transform.position.y, object1.transform.position.z);

        particle2.InverseMass = 2.0f;
        particle2.Damping = 0.95f;
        particle2.SetAcceleration(0.0f, 0f, 0.0f);
        particle2.SetPosition(object2.transform.position.x, object2.transform.position.y, object2.transform.position.z);

        particleCable.MaxLength = 3.0f;
        particleCable.Restitution = 1.0f;
        particleCable.particle = new cyclone.Particle[2];
        particleCable.particle[0] = particle1;
        particleCable.particle[1] = particle2;
    }

    private void FixedUpdate()
    {
        double duration = Time.deltaTime;
        
        cyclone.ParticleContact particleContact = new cyclone.ParticleContact();
        
        if (particleCable.AddContact(particleContact, 1) > 0)
        {
            cyclone.ParticleContact[] contacts = new cyclone.ParticleContact[1];
            contacts[0] = particleContact;
            contactResolver.ResolveContacts(contacts, 1, duration);
        }

        particle1.Integrate(duration);
        particle2.Integrate(duration);
        
        object1.transform.position = new Vector3((float)particle1.Position.x, (float)particle1.Position.y, (float)particle1.Position.z);
        object2.transform.position = new Vector3((float)particle2.Position.x, (float)particle2.Position.y, (float)particle2.Position.z);
    }

    void OnGUI()
    {
        KeyCode key = Event.current.keyCode;

        switch (key)
        {
            case KeyCode.W: particle1.AddForce(new cyclone.Vector3(0f, 1f, 0f)); break;
            case KeyCode.S: particle1.AddForce(new cyclone.Vector3(0f, -1f, 0f)); break;
            case KeyCode.A: particle1.AddForce(new cyclone.Vector3(-1f, 0f, 0f)); break;
            case KeyCode.D: particle1.AddForce(new cyclone.Vector3(1f, 0f, 0f)); break;
        }
    }
}