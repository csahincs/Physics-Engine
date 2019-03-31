﻿using System;
using cyclone;

namespace Cyclone
{
    public class Particle
    {
        public double Damping { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        protected Vector3 ForceAccum { get; set; }
        public Vector3 Acceleration { get; set; }
        public double InverseMass { get; set; }
        
        public Particle()
        {
            Position = new Vector3();
            Velocity = new Vector3();
            ForceAccum = new Vector3();
            Acceleration = new Vector3();
        }
        
        public bool HasFiniteMass()
        {
            return InverseMass >= 0.0;
        }
        
        public void SetVelocity(double x, double y, double z)
        {
            Velocity.x = x;
            Velocity.y = y;
            Velocity.z = z;
        }

        public void SetPosition(double x, double y, double z)
        {
            Position.x = x;
            Position.y = y;
            Position.z = z;
        }
        
        public void SetAcceleration(double x, double y, double z)
        {
            Acceleration.x = x;
            Acceleration.y = y;
            Acceleration.z = z;
        }
        
        public Vector3 GetPosition()
        {
            return new Vector3(Position.x, Position.y, Position.z);
        }
        
        public Vector3 GetVelocity()
        {
            return new Vector3(Velocity.x, Velocity.y, Velocity.z);
        }
        
        public Vector3 GetAcceleration()
        {
            return new Vector3(Acceleration.x, Acceleration.y, Acceleration.z);
        }
        
        public void Integrate(double duration)
        {
            // We don't integrate things with zero mass.
            if (InverseMass <= 0.0f)
            {
                return;
            }

            // Make sure duration is positive.
            if (duration <= 0.0)
            {
                throw new ArgumentOutOfRangeException("duration", "must be greater than 0");
            }

            // Update linear position.
            Position.AddScaledVector(Velocity, duration);

            // Work out the acceleration from the force.
            Vector3 resultingAcc = GetAcceleration();
            resultingAcc.AddScaledVector(ForceAccum, InverseMass);

            // Update linear velocity from the acceleration.
            Velocity.AddScaledVector(resultingAcc, duration);

            // Impose drag.
            Velocity *= System.Math.Pow(Damping, duration);

            // Clear the forces.
            ClearAccumulator();
        }
        
        public void AddForce(Vector3 force)
        {
            ForceAccum += force;
        }
        
        private void ClearAccumulator()
        {
            ForceAccum.Clear();
        }
    }
}
