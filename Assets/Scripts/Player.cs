using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //    //flag to check if the user has tapped / clicked. 
    //    //Set to true on click. Reset to false on reaching destination
    //    private bool flag = false;
    //    //destination point
    //    private Vector3 endPoint;
    //    //alter this to change the speed of the movement of player / gameobject
    //    public float duration = 50.0f;
    //    //vertical position of the gameobject
    //    private float yAxis;

    //    void Start()
    //    {
    //        //save the y axis value of gameobject
    //        yAxis = gameObject.transform.position.y;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //        //check if the screen is touched / clicked   
    //        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
    //        {
    //            //declare a variable of RaycastHit struct
    //            RaycastHit hit;
    //            //Create a Ray on the tapped / clicked position
    //            Ray ray;
    //            //for touch
    //            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

    //            //Check if the ray hits any collider
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                //set a flag to indicate to move the gameobject
    //                flag = true;
    //                //save the click / tap position
    //                endPoint = hit.point;
    //                //as we do not want to change the y axis value based on touch position, reset it to original y axis value
    //                endPoint.y = yAxis;
    //                Debug.Log(endPoint);
    //            }

    //        }
    //        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
    //        if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
    //        { //&& !(V3Equal(transform.position, endPoint))){
    //          //move the gameobject to the desired position
    //            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
    //        }
    //        //set the movement indicator flag to false if the endPoint and current gameobject position are equal
    //        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
    //        {
    //            flag = false;
    //            Debug.Log("I am here");
    //        }

    //    }
    //}

    enum GestureType { None, Tap, Drag };

    GestureType currentGesture = GestureType.None;

    public float speed = 0.1F;
    private Vector3 touchedPos;
    private float timeTouched;
    private bool hasMoved;
    private float distanceToSelectedObject;
    public float perspectiveZoomSpeed = 0.5f;
    private float startingDistanceBetweenTouches;
    private float startScale;
    private bool character;
    private Player currentlySelectedObject;

    public GameObject playerMove;
    float Movespeed = 10f;
    private Rigidbody2D characterBody;
    private float ScreenWidth;
    private Player nullSelectedObject;

    // Use this for initialization
    void Start()
    {

        currentlySelectedObject = nullSelectedObject;
       // characterBody = playerMove.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeTouched += Time.deltaTime;

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                // Debug.Log("Touching at: " + touch.position);
                Ray r = Camera.main.ScreenPointToRay(touch.position);
                // Debug.DrawRay(r.origin, 100 * r.direction);


                RaycastHit hit = new RaycastHit();

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        timeTouched = 0f;
                        hasMoved = true;

                        if (Physics.Raycast(r, out hit))
                        {
                            Player latestPlayer = hit.collider.gameObject.GetComponent<Player>();

                            if (latestPlayer)
                            {
                                distanceToSelectedObject = Vector3.Distance(Camera.main.transform.position, latestPlayer.transform.position);
                            }
                        }


                        break;
                    case TouchPhase.Moved:


                        switch (currentGesture)
                        {

                            case GestureType.None:
                                //Need to determine gesture here

                                //Is it a drag
                                if ((Input.touchCount == 1) && (timeTouched >= 0.5f))
                                {

                                    if ((currentlySelectedObject))
                                    {
                                        currentGesture = GestureType.Drag;


                                    }

                                }
                                break;
                            case GestureType.Drag:

                                if (currentlySelectedObject)
                                {
                                    r = Camera.main.ScreenPointToRay(touch.position);

                                    currentlySelectedObject.transform.position = r.origin + distanceToSelectedObject * r.direction;

                                }


                                break;
                        }

                        print("Moved");
                        hasMoved = false;

                        break;

                    case TouchPhase.Ended:
                        if ((timeTouched < 0.15f) && hasMoved)

                        {

                            if (Physics.Raycast(r, out hit))
                            {
                                Player latestPlayer = hit.collider.gameObject.GetComponent<Player>();

                                if (latestPlayer)
                                {
                                    if (currentlySelectedObject != latestPlayer)
                                    {
                                         //if (currentlySelectedObject) currentlySelectedObject.playerMove();

                                    }

                                    currentlySelectedObject = latestPlayer;


                                }
                                print("hit");
                            }
                            else
                            {

                                //print("here");
                                if (currentlySelectedObject)
                                {
                                    currentlySelectedObject = null;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}

