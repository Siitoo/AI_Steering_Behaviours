﻿using UnityEngine;
using System.Collections;

public class SteeringEvade : MonoBehaviour
{

    public float max_prediction = 2.0F;

    Move move;
    SteeringArrive arrive;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();
    }

    // Update is called once per frame
    void Update()
    {
        Steer(move.target.transform.position, move.target.GetComponent<Move>().movement);
    }

    public void Steer(Vector3 target, Vector3 velocity)
    {
        // TODO 6: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Arrive

        float distance = Vector3.Distance(target,transform.position);
        float ahead = distance / max_prediction;

        Vector3 future_position = -target + velocity * ahead;

        arrive.Steer(future_position);

    }
}