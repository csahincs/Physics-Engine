using cyclone;
using System;

public class Firework : Particle
{
    public int type;
    public double age;

    public bool Update(double duration)
    {
        Integrate(duration);

        age -= duration;
        return (age < 0);

    }
}

public struct FireworkRule
{
    public int type;

    public double minAge;
    public double maxAge;

    public Vector3 minVelocity;
    public Vector3 maxVelocity;

    public double damping;

    public int payloadCount;
    public Payload[] payloads;

    public struct Payload
    {
        public int type;
        public int count;

        public void set(int type, int count)
        {
            this.type = type;
            this.count = count;
        }
    }
    public void init(int payloadCount)
    {
        this.payloadCount = payloadCount;
        payloads = new Payload[payloadCount];
    }

    public double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public Vector3 GetRandomVector(Vector3 minimum, Vector3 maximum)
    {
        Random randomX = new Random();
        Random randomY = new Random();
        Random randomZ = new Random();


        double x = randomX.NextDouble() * (maximum.x - minimum.x) + minimum.x;
        double y = randomX.NextDouble() * (maximum.y - minimum.y) + minimum.y;
        double z = randomX.NextDouble() * (maximum.z - minimum.z) + minimum.z;

        return new Vector3(x, y, z);
    }

    public Firework Create(Firework firework, Firework fireworkParent)
    {
        double r = GetRandomNumber(minAge, maxAge);
        firework.type = type;
        firework.age = r;
        firework.Velocity = new Vector3(0f, 0f, 0f);
        if (fireworkParent != null)
        {
            Vector3 parentPosition = fireworkParent.GetPosition();
            firework.SetPosition(parentPosition.x, parentPosition.y, parentPosition.z);
            firework.Velocity = fireworkParent.Velocity;
        }

        firework.Velocity += GetRandomVector(minVelocity, maxVelocity);
        firework.SetMass(1);
        firework.SetDamping(damping);
        firework.SetAcceleration(0f, -9.5f, 0f);
        firework.ClearAccumulator();

        return firework;
    }

    public void SetParameters(int type, double minAge, double maxAge, Vector3 minVelocity, Vector3 maxVelocity, double damping)
    {
        this.type = type;
        this.minAge = minAge;
        this.maxAge = maxAge;
        this.minVelocity = minVelocity;
        this.maxVelocity = maxVelocity;
        this.damping = damping;
    }



}




