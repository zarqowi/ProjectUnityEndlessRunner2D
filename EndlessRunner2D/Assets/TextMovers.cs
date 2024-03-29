﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMovers : MonoBehaviour
{ 
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    void Start()
    {

        platformWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y);
            
        }
    } 
}
