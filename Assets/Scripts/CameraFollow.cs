using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        //Go to the game objects find the one with the 
        //tag player and take its "transform" property
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player)
            return; //it will keeps all lines & exist fc

        // store the prime position of the camera to a temp variable
        tempPos = transform.position;  

        //Now we need to update its position following the player
        //change the temp.x
        tempPos.x = player.position.x;

        //assign temp value to the camera position
        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        else if(tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
