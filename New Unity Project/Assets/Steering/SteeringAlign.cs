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
        float current_angle = 2 * Mathf.Acos(transform.rotation.w);
        float target_angle = 2 * Mathf.Acos(move.target.transform.rotation.w);

        float angle_to_target = Mathf.DeltaAngle(current_angle,target_angle);

        if(angle_to_target <= slow_angle)
        {
            float ideal_angle = Mathf.LerpAngle(min_angle, angle_to_target, time_to_target);
            float acceleration_angle = Mathf.MoveTowardsAngle(ideal_angle, angle_to_target,move.max_rot_acceleration);

            if (angle_to_target <= min_angle)
                move.SetRotationVelocity(0);
            else
                move.AccelerateRotation(acceleration_angle);
        }
        //NOT FINISH
	}
}
