using System;

namespace cyclone
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;
        private double pad;


        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        void Invert()
        {
            x = -x;
            y = -y;
            z = -z;
        }


        float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        float SquareMagnitude()
        {
            return x * x + y * y + z * z;
        }

        void Normalize()
        {
            float length = Magnitude();

            x = x / length;
            y = y / length;
            z = z / length;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x / d, a.y / d, a.z / d);
        }

        public static Vector3 ScalarProduct(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }


    }
}