using UnityEngine;
using NUnit.Framework;

public class Vector3Tests : MonoBehaviour
{
    [Test]
    public void Test1()
    {
        cyclone.Vector3 v1 = new cyclone.Vector3(1.0f, 0f, 0f);

        double length = v1.Magnitude;

        Assert.AreEqual(1, length);
    }

    [Test]
    public void Test2()
    {
        cyclone.Vector3 v1 = new cyclone.Vector3(1.0f, 2.0f, 2.0f);
        cyclone.Vector3 v2 = new cyclone.Vector3(1.0f / 3, 2.0f / 3, 2.0f / 3);


        v1.Normalize();

        Assert.AreEqual(v1, v2);
    }

    [Test]
    public void Test3()
    {
        cyclone.Vector3 v1 = new cyclone.Vector3(1.0f, 2.0f, 2.0f);
        cyclone.Vector3 v2 = new cyclone.Vector3(-1.0f, -2.0f, -2.0f);

        v1.Invert();
        v1.Print();
        Assert.AreEqual(v1, v2);

    }

    [Test]
    public void Test4()
    {
        cyclone.Vector3 v1 = new cyclone.Vector3(1.0f, 2.0f, 2.0f);
        cyclone.Vector3 v2 = new cyclone.Vector3(2.0f, 2.0f, -2.0f);

        double dotProduct = v1.ScalarProduct(v2);

        Assert.AreEqual(dotProduct, 2.0f);
    }
}
