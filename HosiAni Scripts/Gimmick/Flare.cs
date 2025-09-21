using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flare : MonoBehaviour
{
    public GameObject Star;

    Rigidbody2D rb;

    public float speed;

    public float radius;

    float movex;
    float movey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movex = radius * Mathf.Sin(Time.time * speed) + Star.transform.position.x;
        movey = radius * Mathf.Cos(Time.time * speed) + Star.transform.position.y;

        rb.MovePosition(new Vector3(movex, movey, transform.position.z));

        transform.up = Star.transform.position - transform.position;
    }
}
