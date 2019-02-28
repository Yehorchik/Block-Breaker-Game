using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;

    }

  
    void Update()
    {
        if (!hasStarted)
        {
            LockBalltoPaddle();
            ShootBallonMouseClick();
        }
        //Vector2 v = GetComponent<Rigidbody2D>().velocity;
        //v = v.normalized;
        //v *= 15;
        //GetComponent<Rigidbody2D>().velocity = v;
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void ShootBallonMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
