using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public cyclone.Particle shot;
    
    public void Initialize(cyclone.Particle shot)
    {
        this.shot = shot;
        SetObjectPosition(this.shot.Position);
    }

    private void FixedUpdate()
    {
        shot.Integrate(Time.deltaTime);
        SetObjectPosition(shot.Position);
    }

    private void SetObjectPosition(cyclone.Vector3 position)
    {
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);
    }
}
