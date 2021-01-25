using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float movementSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-movementSpeed, 0) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        
    }
}
