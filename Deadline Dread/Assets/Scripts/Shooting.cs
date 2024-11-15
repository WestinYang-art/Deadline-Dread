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
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            shootCalc();
            bulletTransform1.transform.rotation = Quaternion.Euler(0, 0, proj1Degree);
            Instantiate(bullet, bulletTransform1.position, bulletTransform1.transform.rotation);
            bulletTransform2.transform.rotation = Quaternion.Euler(0, 0, proj2Degree);
            Instantiate(bullet, bulletTransform2.position, bulletTransform2.transform.rotation);
            bulletTransform3.transform.rotation = Quaternion.Euler(0, 0, proj3Degree);
            Instantiate(bullet, bulletTransform3.position, bulletTransform3.transform.rotation);
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
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
}
