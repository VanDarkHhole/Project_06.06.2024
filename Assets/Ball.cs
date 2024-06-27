using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{   
    public Rigidbody2D rigidbody2D;
    public float Speed = 6f;
    public UiManager UiManager;

    public int Scoreright;
    public int Scoreleft;

    public static event Action BallReset;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }

    private void SendBallInRandomDirection()
    {


        BallReset?.Invoke();


        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = false;


        Vector2 newBallVector = new Vector2();
        newBallVector.x = Random.Range(-1f, 1f);

        newBallVector.y = Random.Range(-1f, 1f);

        rigidbody2D.velocity = newBallVector * Speed;

        rigidbody2D.velocity = newBallVector.normalized * Speed;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SendBallInRandomDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() == null)
            return;

        collision.gameObject.GetComponent<Movement>().speed *= 1.1f;
        rigidbody2D.velocity *= 1.1f;
    }



    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            Debug.Log("Player left +1");
            Scoreleft++;
            UiManager.SetScoreleftText(Scoreleft.ToString());
        }
        else
        {
            Debug.Log("Player Right +1");
            Scoreright++;
            UiManager.SetScorerightText(Scoreright.ToString());
        }

        SendBallInRandomDirection();
    }
}
