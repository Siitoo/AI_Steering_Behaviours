using UnityEngine;
using System.Collections;

public class SteeringVelocityMatching : MonoBehaviour {

	public float time_to_target = 0.25f;

	Move move;
	Move target_move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		target_move = move.target.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target_move)
		{
            // TODO 5: First come up with your ideal velocity
            // then accelerate to it.

            // float x = target_move.transform.position.x - move.transform.position.x;

            Vector3 ideal_velocity = target_move.movement - move.movement + (target_move.movement * target_move.max_mov_velocity * time_to_target);
            float g = target_move.movement.magnitude;

            ideal_velocity . z = g;
            ideal_velocity.y = 0;
            ideal_velocity.x = 0;
         
            move.AccelerateMovement(ideal_velocity);
        }
	}
}
