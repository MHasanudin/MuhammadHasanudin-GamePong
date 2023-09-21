using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Kecepatan paddle")]
    public int speed;

    [Header("Tombol untuk paddle")]
    public KeyCode UpKey;
    public KeyCode DownKey;

    private Rigidbody2D rb2D;

    private void Update()
    {
        rb2D = GetComponent<Rigidbody2D>();
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        //Input Key
        if (Input.GetKey(UpKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(DownKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Kecepatan Paddle : " + movement);
        rb2D.velocity = movement;
    }
}
