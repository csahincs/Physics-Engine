using UnityEngine;
using cyclone;
using System.Collections.Generic;

public class FireworkDemo : MonoBehaviour
{
    private const int ruleCount = 9;

    public List<Firework> fireworks = new List<Firework>();
    public FireworkRule[] rules = new FireworkRule[ruleCount];
    private int nextFirework;

    public FireworkPrefab fireworkGO;


    public void Start()
    {
        InitFireworkRules();
        nextFirework = 0;
    }

    public void InitFireworkRules()
    {
        rules[0].init(2);
        rules[0].SetParameters(1,
                               0.5f, 1.4f,
                               new cyclone.Vector3(-5, 25, -5),
                               new cyclone.Vector3(5, 28, 5),
                               0.1f);

        rules[0].payloads[0].set(3, 5);
        rules[0].payloads[1].set(5, 5);

        rules[1].init(1);
        rules[1].SetParameters(
            2, // type
            0.5f, 1.0f, // age range
            new cyclone.Vector3(-5, 10, -5), // min velocity
            new cyclone.Vector3(5, 20, 5), // max velocity
            0.8 // damping
            );
        rules[1].payloads[0].set(4, 2);

        rules[2].init(0);
        rules[2].SetParameters(
            3, // type
            0.5f, 1.5f, // age range
            new cyclone.Vector3(-5, -5, -5), // min velocity
            new cyclone.Vector3(5, 5, 5), // max velocity
            0.1 // damping
            );

        rules[3].init(0);
        rules[3].SetParameters(
            4, // type
            0.25f, 0.5f, // age range
            new cyclone.Vector3(-20, 5, -5), // min velocity
            new cyclone.Vector3(20, 5, 5), // max velocity
            0.2 // damping
            );

        rules[4].init(1);
        rules[4].SetParameters(
            5, // type
            0.5f, 1.0f, // age range
            new cyclone.Vector3(-20, 2, -5), // min velocity
            new cyclone.Vector3(20, 18, 5), // max velocity
            0.01 // damping
            );
        rules[4].payloads[0].set(3, 5);

        rules[5].init(0);
        rules[5].SetParameters(
            6, // type
            3, 5, // age range
            new cyclone.Vector3(-5, 5, -5), // min velocity
            new cyclone.Vector3(5, 10, 5), // max velocity
            0.95 // damping
            );

        rules[6].init(1);
        rules[6].SetParameters(
            7, // type
            4, 5, // age range
            new cyclone.Vector3(-5, 50, -5), // min velocity
            new cyclone.Vector3(5, 60, 5), // max velocity
            0.01 // damping
            );
        rules[6].payloads[0].set(8, 10);

        rules[7].init(0);
        rules[7].SetParameters(
            8, // type
            0.25f, 0.5f, // age range
            new cyclone.Vector3(-1, -1, -1), // min velocity
            new cyclone.Vector3(1, 1, 1), // max velocity
            0.01 // damping
            );

        rules[8].init(0);
        rules[8].SetParameters(
            9, // type
            3, 5, // age range
            new cyclone.Vector3(-15, 10, -5), // min velocity
            new cyclone.Vector3(15, 15, 5), // max velocity
            0.95 // damping
            );
    }


    public void Create(int type, Firework parent)
    {
        // Get the rule needed to create this firework
        FireworkRule rule = rules[(type - 1)];

        // Create the firework
        Firework fwInit = new Firework();
        fireworks.Add(fwInit);
        Firework fw = rule.Create(fireworks[nextFirework], parent);
        fireworks[nextFirework] = fw;

        // Increment the index for the next firework
        nextFirework = (nextFirework + 1);

        FireworkPrefab fwp = Instantiate(fireworkGO);
        fwp.Initialize(fw);
    }

    public void Create(int type, int number, Firework parent)
    {
        for (int i = 0; i < number; i++)
        {
            Create(type, parent);
        }
    }

    public void FixedUpdate()
    {
        for(int i = 0; i < fireworks.Count; i++)
        {
            if(fireworks[i].type > 0)
            {
                if(fireworks[i].Update(Time.deltaTime))
                {
                    FireworkRule rule = rules[fireworks[i].type - 1];

                    fireworks[i].type = 0;

                    for(int j = 0; j < rule.payloadCount; j++)
                    {
                        FireworkRule.Payload payload = rule.payloads[j];
                        Create(payload.type, payload.count, fireworks[i]);
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        KeyCode key = Event.current.keyCode;

        switch (key)
        {
            case KeyCode.Alpha1: Create(1, 1, null); break;
            case KeyCode.Alpha2: Create(2, 1, null); break;
            case KeyCode.Alpha3: Create(3, 1, null); break;
            case KeyCode.Alpha4: Create(4, 1, null); break;
            case KeyCode.Alpha5: Create(5, 1, null); break;
            case KeyCode.Alpha6: Create(6, 1, null); break;
            case KeyCode.Alpha7: Create(7, 1, null); break;
            case KeyCode.Alpha8: Create(8, 1, null); break;
            case KeyCode.Alpha9: Create(9, 1, null); break;
        }
    }


}
