using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float rotation;
    private Transform position;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        /*mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Initialize(float rotation, Transform position)
    {

    }

    public void Initialize(float rotation, Transform position, float force, Sprite sprite)
    {
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);

        gameObject.tag = "Bullet";
        this.force = force;
        this.position = position;
        this.rotation = rotation;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        float x = position.position.x;
        float y = position.position.y;
        gameObject.GetComponent<Rigidbody2D>().transform.position = new Vector3(x, y, 0);
        movement = Quaternion.Euler(0, 0, (rotation - 90)) * Vector2.up * force;
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }
}
