using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foam_Launcher : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    public bool canFire;
    private float bulletTimer;
    private float fireTimer;
    public float timeBetweenFiring;
    public float deathTimer;
    public float force;
    private float rotZ;
    private Vector3 rotation;
    public float cone;
    private float negDegrees;
    private float posDegrees;
    private float tNegDegrees;
    private float tPosDegrees;
    private float projDegree;
    public float bulletCount;
    public int maxAmmo;
    public int ammoCount;
    public float ammoRegen;
    private int statMaxAmmo;
    private float statAmmoRegen;
    private System.Random rFactor = new System.Random();
    public Sprite sprite;
    public bool fireMode;
    public float godTime;
    public bool buffDelay;
    public float buffTime;

    // Start is called before the first frame update
    void Start()
    {
        this.timeBetweenFiring = 1 / SceneSwitchManager.getFireLvl();
        this.cone = SceneSwitchManager.getFanLvl() * 7;
        this.bulletCount = SceneSwitchManager.getFanLvl() * 2;
        this.maxAmmo = SceneSwitchManager.getMaxALvl() * 5;
        this.ammoRegen = SceneSwitchManager.getMaxALvl();
        statAmmoRegen = ammoRegen;
        statMaxAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        rotation = mousePos - transform.position;

        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        degCalc();

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (buffDelay == true)
        {
            godTime += Time.deltaTime;
            ammoRegen = .01f;
            maxAmmo = 999;
        }
        if (buffDelay == true && godTime >= buffTime)
        {
            ammoRegen = statAmmoRegen;
            maxAmmo = statMaxAmmo;
            if (ammoCount >= maxAmmo)
            {
                ammoCount = maxAmmo;
            }
            godTime = 0;
            buffDelay = false;
        }
        
        if (!canFire && ammoCount > 0)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > timeBetweenFiring || ammoCount == 1)
            {
                canFire = true;
                fireTimer = 0;
            }
        }

        bulletTimer += Time.deltaTime;
        if (bulletTimer > ammoRegen)
        {
            bulletTimer = 0;
            if (ammoCount < maxAmmo)
            {
                ammoCount += 1;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            ammoCount -= 1;
            for (int i = 0; i < bulletCount; i++)
            {
                shootCalc();
                GameObject bullet = new GameObject();
                bullet.AddComponent<BulletScript>();
                bullet.GetComponent<BulletScript>().Initialize(projDegree, gameObject.transform, force, sprite, deathTimer);
            }
            canFire = false;
        }
    }

    private void FixedUpdate()
    {

    }

    private void degCalc()
    {
        negDegrees = rotZ - cone;

        posDegrees = rotZ + cone;

        if (negDegrees > 180)
        {
            tNegDegrees = 0 - (180 + (180 - negDegrees));
        }
        else
        {
            tNegDegrees = negDegrees;
        }

        if (posDegrees > 180)
        {
            tPosDegrees = 0 - (180 + (180 - posDegrees));
        }
        else
        {
            tPosDegrees = posDegrees;
        }
    }

    private void shootCalc()
    {
        projDegree = rFactor.Next(0, (int)cone * 2);
        if (projDegree + tNegDegrees > 180)
        {
            projDegree = 0 - (180 + (180 - (projDegree + tNegDegrees)));
        }
        else
        {
            projDegree = tNegDegrees + projDegree;
        }
    }

    public float getProjDegree()
    {
        return projDegree;
    }

    public void setProjDegree(float projDegree)
    {
        this.projDegree = projDegree;
    }

    public float getTimeBetweenFiring()
    {
        return timeBetweenFiring;
    }

    public void setTimeBetweenFiring(float timeBetweenFiring)
    {
        this.timeBetweenFiring = timeBetweenFiring;
    }

    public float getAmmoRegen()
    {
        return ammoRegen;
    }

    public void setAmmoRegen(float ammoRegen)
    {
        this.ammoRegen = ammoRegen;
    }

    public float getCone()
    {
        return cone;
    }

    public void setCone(float cone)
    {
        this.cone = cone;
    }

    public float getBulletCount()
    {
        return bulletCount;
    }

    public void setBulletCount(float bulletCount)
    {
        this.bulletCount = bulletCount;
    }

    public int getMaxAmmo()
    {
        return maxAmmo;
    }

    public void setMaxAmmo(int maxAmmo)
    {
        this.maxAmmo = maxAmmo;
    }

    public void activateGodTime()
    {
        buffDelay = true;
        godTime = 0;
    }
}
