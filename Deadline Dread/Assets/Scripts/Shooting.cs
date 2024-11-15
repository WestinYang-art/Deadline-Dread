using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform1;
    public Transform bulletTransform2;
    public Transform bulletTransform3;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float rotZ;
    private Vector3 rotation;
    public float negDegrees;
    public float posDegrees;
    public float tNegDegrees;
    public float tPosDegrees;
    public float proj1Degree;
    public float proj2Degree;
    public float proj3Degree;
    private System.Random rFactor = new System.Random();
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        rotation = mousePos - transform.position;

        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        degCalc();

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            shootCalc();
            GameObject bullet1 = new GameObject();
            GameObject bullet2 = new GameObject();
            GameObject bullet3 = new GameObject();
            bullet1.AddComponent<BulletScript>();
            bullet2.AddComponent<BulletScript>();
            bullet3.AddComponent<BulletScript>();
            bullet1.GetComponent<BulletScript>().Initialize(proj1Degree, gameObject.transform, 5, sprite);
            bullet2.GetComponent<BulletScript>().Initialize(proj2Degree, gameObject.transform, 5, sprite);
            bullet3.GetComponent<BulletScript>().Initialize(proj3Degree, gameObject.transform, 5, sprite);

            /*transform.rotation = Quaternion.Euler(0, 0, proj1Degree);
            Instantiate(bullet, bulletTransform1.position, Quaternion.identity);
            transform.rotation = Quaternion.Euler(0, 0, proj2Degree);
            Instantiate(bullet, bulletTransform2.position, Quaternion.identity);
            transform.rotation = Quaternion.Euler(0, 0, proj3Degree);
            Instantiate(bullet, bulletTransform3.position, Quaternion.identity);
            transform.rotation = Quaternion.Euler(0, 0, rotZ);*/
        }
    }

    private void FixedUpdate()
    {

    }

    private void degCalc()
    {
        negDegrees = rotZ - 35;

        posDegrees = rotZ + 35;

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
        proj1Degree = rFactor.Next(0, 70);
        proj2Degree = rFactor.Next(0, 70);
        proj3Degree = rFactor.Next(0, 70);
        if (proj1Degree + tNegDegrees > 180)
        {
            proj1Degree = 0 - (180 + (180 - (proj1Degree + tNegDegrees)));
        }
        else
        {
            proj1Degree = tNegDegrees + proj1Degree;
        }
        if (proj2Degree + tNegDegrees > 180)
        {
            proj2Degree = 0 - (180 + (180 - (proj2Degree + tNegDegrees)));
        }
        else
        {
            proj2Degree = tNegDegrees + proj2Degree;
        }
        if (proj3Degree + tNegDegrees > 180)
        {
            proj3Degree = 0 - (180 + (180 - (proj2Degree + tNegDegrees)));
        }
        else
        {
            proj3Degree = tNegDegrees + proj3Degree;
        }
    }

    public float getProj1Degree()
    {
        return proj1Degree;
    }
    public float getProj2Degree()
    {
        return proj2Degree;
    }
    public float getProj3Degree()
    {
        return proj3Degree;
    }
}
