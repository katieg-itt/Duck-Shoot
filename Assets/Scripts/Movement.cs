using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //variables
    public float moveSpeed = 0.5f;
    
    private Rigidbody2D characterBody;
    int catShoot;


    // Use this for initialization
    void Start()
    {

        characterBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector2.Lerp(transform.position, new Vector2 (touchedPos.x,transform.position.y), Time.deltaTime);
            }else
                 if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) // Tap
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Physics2D.OverlapPoint(touchPos))
                {
                    //game object has been tapped
                    catShoot++;
                }
                print("fire");
            }
        }
    }
}
