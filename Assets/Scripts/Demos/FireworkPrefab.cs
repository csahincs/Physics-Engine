using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkPrefab : MonoBehaviour
{
    public Firework fw;

    // Start is called before the first frame update
    public void Initialize(Firework fw)
    {
        this.fw = fw;
        SetObjectPosition(this.fw.Position);
    }

    private void FixedUpdate()
    {
        fw.Integrate(Time.deltaTime);
        SetObjectPosition(fw.Position);
    }

    private void SetObjectPosition(cyclone.Vector3 position)
    {
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);
    }
}
