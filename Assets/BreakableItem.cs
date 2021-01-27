using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableItem : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakIt()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        float randomVelocityX = Random.Range(5f, 10f);
        float randomVelocityY = Random.Range(5f, 10f);
        rb.velocity = new Vector2(randomVelocityX, randomVelocityY);
        rb.AddTorque(Random.Range(-40f, 40f));
    }
}
