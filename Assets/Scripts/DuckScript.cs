using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckScript : MonoBehaviour {

    public GameManager game;
    public int livesNumber;
    float flyingSpeed;
    float duckTopY =2.20f; // highest a duck should go
    float duckBottomY = 0f; // lowest a duck should go
    float duckStartX = -11.5f; // start position
    float duckEndX = 11.05f; // end position
    float maxSpeed = 8f;
    float minSpeed = 4f;
    

    // Use this for initialization
    void Start () {
        

        flyingSpeed = randomSpeed();
        

        
        this.transform.position = new Vector3(duckStartX, generateY());
	}    

    private float generateY()
    {
       float y = UnityEngine.Random.Range(duckBottomY, duckTopY);
       return y;
    }

    private float randomSpeed()
    {
        return UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x > duckEndX && livesNumber > 0)
        {
            if (livesNumber > 0)
            {
                livesNumber -= 1;
                generateCoordinates();
            }
        }
        else
        {
            //if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) // Tap
            //{
            //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    if (Physics2D.OverlapPoint(touchPos))
            //    {
            //        //game object has been tapped
            //        scoreNumber++;
            //        generateCoordinates();
            //    }
            //}
            this.transform.position = new Vector3(transform.position.x + flyingSpeed * Time.deltaTime, transform.position.y);
        }

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        this.generateCoordinates();
        game.scoreNumber++;
        generateCoordinates();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Fish")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Fish has hit Duck");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Duck")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Duck has been Hit");
        }
    }

    


    //Move the "duck" to the new coordiantess
    public void generateCoordinates()
    {
        flyingSpeed = randomSpeed();
        game.updateScore();
        
        this.transform.position = new Vector3(duckStartX, generateY());
    }
}
