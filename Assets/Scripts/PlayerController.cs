using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    float speed = 8.0f;
    private int left_boundary;
    private int right_boundary;
    private float screenWidth;
    private int top_boundary;
    private int bottom_boundary;

    void Start()
    {

        // orthographicSize is like the half of the height of the screen(screen possition is like from y=-4 till y=4 so the orthographicSize = 4)
        // the Camera.main.aspect is the aspect ratio of the scree which is width/height
        // so the actual width would be Camera.main.orthographicSize*Camera.main.aspect === height * width/height
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        right_boundary = (int)Math.Floor(screenWidth);
        left_boundary = - right_boundary;
        top_boundary = (int)Camera.main.orthographicSize;
        bottom_boundary = - top_boundary;

        
    }

    // Update is called once per frame
    void Update()
    {
        float userInputHorizontal = Input.GetAxis("Horizontal");
        float userInputVertical = Input.GetAxis("Vertical");

            if(gameObject.transform.position.x + userInputHorizontal < right_boundary && gameObject.transform.position.x + userInputHorizontal > left_boundary)
            {

                Vector3 translatePlayer= new(userInputHorizontal ,0 ,0);
                transform.Translate(this.speed * Time.deltaTime * translatePlayer);
            }

        if (gameObject.transform.position.y + userInputVertical < top_boundary && gameObject.transform.position.y + userInputVertical > bottom_boundary)
        {

            Vector3 translatePlayer = new(0 ,userInputVertical ,0);
            transform.Translate(this.speed * Time.deltaTime * translatePlayer);
        }




    }
}
