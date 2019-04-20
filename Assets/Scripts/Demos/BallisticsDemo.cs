using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallisticsDemo : MonoBehaviour
{
    enum Weapon
    {
        PISTOL, ARTILLERY, FIREBALL, LASER
    };

    public Bullet bullet;
    public TMPro.TextMeshProUGUI currentWeapon;

    private Weapon currentShotType = Weapon.PISTOL;


    // Start is called before the first frame update
    void Start()
    {
        currentWeapon.text = currentShotType.ToString();
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.C)
        {
            string[] PieceTypeNames = Enum.GetNames(typeof(Weapon));

            bool currentWeaponFound = false;
            for (int i = 0; i < PieceTypeNames.Length; i++)
            {
                if (currentWeaponFound)
                {
                    Enum.TryParse(PieceTypeNames[i], out currentShotType);
                    break;
                }
                else
                {
                    if (PieceTypeNames[i] == currentShotType.ToString())
                    {
                        currentWeaponFound = true;
                        if (i == PieceTypeNames.Length - 1)
                            i = -1;
                    }
                }
            }
            currentWeapon.text = currentShotType.ToString();


        }

        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.S)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        cyclone.Particle shot = new cyclone.Particle();
        switch(currentShotType)
        {
            case Weapon.PISTOL:
                shot.SetMass(2.0f);
                shot.SetVelocity(0.0f, 0.0f, 35.0f);
                shot.SetAcceleration(0.0f, -1.0f, 0.0f);
                shot.SetDamping(0.99f);
                break;
            case Weapon.ARTILLERY:
                shot.SetMass(200.0f);
                shot.SetVelocity(0.0f, 30.0f, 40.0f);
                shot.SetAcceleration(0.0f, -20.0f, 0.0f);
                shot.SetDamping(0.99f);
                break;
            case Weapon.FIREBALL:
                shot.SetMass(1.0f);
                shot.SetVelocity(0.0f, 0.0f, 10.0f);
                shot.SetAcceleration(0.0f, -0.6f, 0.0f);
                shot.SetDamping(0.9f);
                break;
            case Weapon.LASER:
                shot.SetMass(0.1f);
                shot.SetVelocity(0.0f, 0.0f, 100.0f);
                shot.SetAcceleration(0.0f, 0.0f, 0.0f);
                shot.SetDamping(0.99f);
                break;
        }

        Bullet newBullet = Instantiate(bullet);
        newBullet.Initialize(shot);
    }
}
