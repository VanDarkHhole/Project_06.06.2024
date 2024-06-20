using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    public Rigidbody2D rigidbody2D;
    public float Speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }

    private void SendBallInRandomDirection()
    {
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



    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            Debug.Log("Player left +1");
        }
        else
        {
            Debug.Log("Player Right +1");
        }

        SendBallInRandomDirection();
    }
}
