﻿using UnityEngine;
using System.Collections;

public class Parrallaxing : MonoBehaviour {

    public Transform[] backgrounds;         // Array (list0 of all the back and foregrounds to be parallaxed.
    private float[] parallaxScales;         // The proportion of the cameras movement to move the backgrounds by.
    public float smoothing = 1f;            // How smooth the parallax is going to be. Make sure to set > 0.

    private Transform cam;                  // Reference to main cameras transform. 
    private Vector3 previousCamPos;         // Store position of the camera in the previous frame. 

    // Is called before Start(). Great for references.
    void Awake()
    {
        // set up the camera reference
        cam = Camera.main.transform;
    }

	// Use this for initialization
	void Start () {
        // The previous frame had the current frame's camera position
        previousCamPos = cam.position;
	    
        // Assigning corresponding parallax scales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // The parallax is the opposit of the camear movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Set a target x position which is th current position plus the parallax.
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            
            // fad between current position and the targe position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
	}
}
