using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fish;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.timeScale != 0)
                {


                    GameObject newFish = Instantiate(fish, touchPos, Quaternion.identity);
                    GameObject.Destroy(newFish, 5f);
                }

            }
        }
		
	}
}
