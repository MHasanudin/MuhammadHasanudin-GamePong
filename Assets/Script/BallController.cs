using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Kecepatan Bola")]
    public Vector2 speed;

    public Vector2 resetPosition;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = speed;
    }

    public void BallReset()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }
}
