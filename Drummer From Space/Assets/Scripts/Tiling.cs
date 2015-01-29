﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    public int offsetX = 2;                  // offset so we get no errors

    //used to check if instatiation is needed
    public bool hasARightBuddy = false;     
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;       //used if the object is not tilable


    private float spriteWidth = 0f;         // the width of our element
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

	// Use this for initialization
	void Start () {
        SpriteRenderer  sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {

        //does it still need buddies? If not, do nothing
        if (hasALeftBuddy == false || hasARightBuddy == false) 
        {
            //calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
             
            //Calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;
            
            // check if we can see the edge of the element and then calling MakeNewBuddy if we can;
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
	}
    
    void MakeNewBuddy(int rightOrLeft)
    {

        //calculate position of new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        // instantiate new buddy and store in a variable
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        //if not tilable, reverse x size to get rid of seam
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
            
        }

        newBuddy.parent = myTransform.parent;

        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }

}
