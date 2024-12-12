using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Sprite[] visuals2;
    //private float time = 0;
    private Foam_Launcher launcher;
    //private float bombDelay = 0;
    private int codeR;
    private bool boundary = false;
    public const int coinID = 0;
    public const int bombID = 1;
    public const int ammoID = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (collided())
        {
            switch (codeR)
            {
                case coinID:
                    coinCollision();
                    break;

                case bombID:
                    bombCollision();
                    break;

                case ammoID:
                    ammoCollision();
                    break;
            }
        }
    }

    public void initialize(int code, float x, float y, Sprite[] visuals, Foam_Launcher fLauncher)
    {
        visuals2 = visuals;
        launcher = fLauncher;
        codeR = code;
        spawnCheckerCreator(x, y);
    }

    public void spawnCheckerCreator(float x, float y)
    {
        gameObject.transform.position = new Vector2(x, y);
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = visuals2[codeR];
        gameObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("collectible");
        gameObject.layer = LayerMask.NameToLayer("Collectible");
        gameObject.tag = "Collectible";
        Vector3 newScale = gameObject.transform.localScale;
        newScale *= .05f;
        gameObject.transform.localScale = newScale;
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        boundary = Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("mapLayer"));
        if (boundary == false)
        {
            Collectible_Generator.setDenied(true);
            Destroy(gameObject);
        }
        else
        {
            Collectible_Generator.setDenied(false);
        }
    }

    private bool collided()
    {
        return Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("Player"));
    }

    private void coinCollision()
    {
        Destroy(gameObject);
        SceneSwitchManager.addCoin(1);
    }

    private void bombCollision()
    {
        GameObject explosion = new GameObject();
        explosion.AddComponent<BulletScript>();
        explosion.GetComponent<BulletScript>().Initialize(0, gameObject.transform, 0, visuals2[3], 2);
        Destroy(gameObject);
    }

    private void ammoCollision()
    {
        Destroy(gameObject);
        launcher.activateGodTime();
    }
}
