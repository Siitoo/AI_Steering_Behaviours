using UnityEngine;
using System.Collections;


public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 4: As with arrive, we first construct our ideal rotation
        // then accelerate to it. Use Mathf.DeltaAngle() to wrap around PI
        // Is the same as arrive but with angular velocities


        float current_angle = Mathf.Atan2(transform.forward.x,transform.forward.z) * Mathf.Rad2Deg;
        float target_angle =  Mathf.Atan2(move.movement.x,move.movement.z) * Mathf.Rad2Deg;

        float angle_to_target = Mathf.DeltaAngle(current_angle, target_angle);

        if (Mathf.Abs(angle_to_target) < slow_angle)
        {
            float ideal_angle = Mathf.LerpAngle(current_angle, target_angle, time_to_target);
            float x = angle_to_target * time_to_target;

            if (Mathf.Abs(ideal_angle) < min_angle)
            {
                angle_to_target = -move.max_rot_acceleration;
               
            }
        }
        else
            angle_to_target *= move.max_rot_acceleration;

        move.AccelerateRotation(angle_to_target);

    }
}
