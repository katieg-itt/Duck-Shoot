//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FishScript : MonoBehaviour {

//    public GameObject fish;
//    int scoreNumber;
//    int livesNumber;
//    private GameObject scoreText;
//    private GameObject livesText;
//    private List<GameObject> flyingFish = new List<GameObject>();
//    float throwSpeed;
//    float fishTopY = 9.21f; // highest a fish should go
//    float fishBottomY = 5.27f; // lowest a fish should go
//    float fishStartY = -0.08f; // start position
//    float fishEndY = 00.17f; // end position
//    float maxSpeed = 0.2f;
//    float minSpeed = 0.1f;

//    // Use this for initialization
//    void Start() {
//        fish = GameObject.Find("fish");
//        scoreText = GameObject.Find("Score");
//        livesText = GameObject.Find("Lives");
//        throwSpeed = 0.5f;
//        livesNumber = 3;
//        scoreNumber = 0;

//        livesText.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + livesNumber;
//        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreNumber;

//        fish.transform.position = new Vector3(fishStartY, generateY());
//    }
//    private float generateY()
//    {
//        float y = UnityEngine.Random.Range(fishBottomY, fishTopY);
//        return y;
//    }

//    private void moveFish()
//    {

//    }

//    private void shootFish()
//    {
//        // clone a fish

//        GameObject newFish = Instantiate(fish);
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if(Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

//            if (touch.phase == TouchPhase.Began)
//                Instantiate(fish, touchPos, Quaternion.identity);
//        }

//        if (fish.transform.position.x > fishEndY && livesNumber > 0)
//        {
//            if (livesNumber > 0)
//            {
//                livesNumber -= 1;
//               generateCoordinates();
//            }
//            else
//            {
//                Destroy(GameObject.Find("fish"));
//                gameOver();
//            }
//        }
//        else
//        {
//            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) // Tap
//            {
//                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//                if (Physics2D.OverlapPoint(touchPos))
//                {
//                    //game object has been tapped
//                    scoreNumber++;
//                    generateCoordinates();
//                    shootFish();
//                }
//            }
//            fish.transform.position = new Vector3(fish.transform.position.x + throwSpeed, fish.transform.position.y);
//        }
//    }


//    private void gameOver()
//    {
//        // Application.LoadLevel("GameOver");
//    }
//    //Move the "fish" to the new coordiantess
//    void generateCoordinates()
//    {
//        //Update the score display
//        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreNumber;
//        livesText.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + livesNumber;
//        fish.transform.position = new Vector3(fishStartY, generateY());
//    }
//}
