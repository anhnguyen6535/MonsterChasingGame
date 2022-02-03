using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    
    // 1st fc to be called
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Fixed Update is called after Update is done
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
