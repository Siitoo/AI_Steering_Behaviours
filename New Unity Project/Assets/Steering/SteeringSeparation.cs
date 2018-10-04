using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration
        Vector3 repulsion = new Vector3(0, 0, 0);


        Collider[] near_collider = Physics.OverlapSphere(move.transform.position, search_radius ,mask.value);

        foreach(Collider collider in near_collider)
        {
            Vector3 escape_direction = transform.position - collider.transform.position;

            float force = falloff.Evaluate((escape_direction.magnitude/search_radius));
            escape_direction.Normalize();

            escape_direction *= force;
            repulsion += escape_direction;
        }

        if(near_collider.Length > 0)
        {
            repulsion /= near_collider.Length;
        }

        if (repulsion.magnitude > 0)
        {
            repulsion.y = 0;
            if (repulsion.magnitude > move.max_mov_acceleration)
            {
                
                repulsion *= move.max_mov_acceleration;
            }

            move.AccelerateMovement(repulsion);
        }
        else
        {
            Vector3 v = -move.movement.normalized / move.max_mov_acceleration;
            v.y = 0;
           move.AccelerateMovement(v);
        }
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
