﻿using UnityEngine;
using System.Collections;

public class SteeringSeek : MonoBehaviour {

	Move move;
    private float acceleration = 0.0f;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()

        Vector3 distance = move.target.transform.position - transform.position;
        distance.y = 0;
        distance.Normalize();

        distance *= move.max_mov_acceleration;
        move.AccelerateMovement(distance);


       
    }
}