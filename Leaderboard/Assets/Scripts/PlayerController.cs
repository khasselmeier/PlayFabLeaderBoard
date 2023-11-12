using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rig;

    private float startTime;
    private float timeTaken;

    private int collectabledPicked;
    public int maxCollectables = 10;

    private bool isPlaying;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (!isPlaying)
        //return;

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);
    }

    public void Begin()
    {
        startTime = Time.time;
        isPlaying = true;
    }

    void End()
    {
        timeTaken = Time.time - startTime;
        isPlaying = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            collectabledPicked++;
            Destroy(other.gameObject);

            if (collectabledPicked == maxCollectables)
                End();
        }
    }
}
