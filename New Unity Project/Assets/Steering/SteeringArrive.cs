using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

	Move move;

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
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Create a vector to calculate our ideal velocity
        // then calculate the acceleration needed to match that velocity
        // before sending it to move.AccelerateMovement() clamp it to 
        // move.max_mov_acceleration

        /* Vector3 distance = move.target.transform.position - transform.position;
         distance.y = 0;
         distance.Normalize();

         Vector3 acceleration = distance;
         float distance_to_target = Vector3.Distance(transform.position, target);

         if (distance_to_target <= slow_distance) 
         {
             Vector3 ideal_vector = move.movement.normalized * distance_to_target * time_to_target;

             acceleration = ideal_vector - move.movement * time_to_target;

             if (distance_to_target <= min_distance)
                acceleration = -move.movement;
         }


         move.AccelerateMovement(acceleration);*/

        Vector3 desiredVelocity = target - transform.position;
        float distance = desiredVelocity.magnitude;

        if (distance < slow_distance)
            desiredVelocity = Vector3.Normalize(desiredVelocity) * move.max_mov_velocity * (distance / slow_distance);
        else
            desiredVelocity = Vector3.Normalize(desiredVelocity) * move.max_mov_velocity;

        Vector3 steering = desiredVelocity - move.movement;

        move.AccelerateMovement(steering);

    }





	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
