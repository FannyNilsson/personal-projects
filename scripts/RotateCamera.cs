using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDir
{
    noSwipe = 0,
    swipeLeft = 1,
    swipeRight = 2
}

public class RotateCamera : MonoBehaviour {

    private Vector3 touchPos;
    private float swipeResX = 50.0f;
    public bool flipped;

    public GameObject camera;
    public GameObject tower;
    public GameObject player;


    public SwipeDir Direction;

	// Use this for initialization
	void Start ()
    {
        flipped = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if nothing happens we reset the swipe to noSwipe
        Direction = SwipeDir.noSwipe;

        //check if left-click is pressed
        if(Input.GetMouseButtonDown(0))
        {
            //save the position where pressed started
            touchPos = Input.mousePosition;
        }

        //check if left-click is released
        if(Input.GetMouseButtonUp(0))
        {
            //check the distance of the swipe (as well as direction)
            Vector2 deltaSwipe = touchPos - Input.mousePosition;
            //check that the swipe is greater than the resistance (resistance is used to minimize acidental swiping)
            if(Mathf.Abs(deltaSwipe.x) > swipeResX)
            {
                if (deltaSwipe.x < 0)
                {
                    Direction = SwipeDir.swipeRight;
                }
                else if (deltaSwipe.x > 0)
                {
                    Direction = SwipeDir.swipeLeft;
                }
            }
        }
        //now we check the direction and move the camera accordingly
        if(Direction == SwipeDir.swipeLeft)
        {
            //camera.transform.RotateAround(tower.transform.position, Vector3.up, -90);
            player.transform.RotateAround(tower.transform.localPosition, Vector3.up, -90);
            flipped = !flipped;

        }
        if (Direction == SwipeDir.swipeRight)
        {
            //camera.transform.RotateAround(tower.transform.position, Vector3.up, 90);
            player.transform.RotateAround(tower.transform.localPosition, Vector3.up, 90);
            flipped = !flipped;
        }
    }
}
