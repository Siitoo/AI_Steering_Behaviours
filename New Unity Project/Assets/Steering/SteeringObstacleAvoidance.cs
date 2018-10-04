using UnityEngine;
using System.Collections;


[System.Serializable]
public class RayClass : System.Object
{
    public Vector3 direction = Vector3.zero;
    public float max_distance = 10.0F;
}

public class SteeringObstacleAvoidance : MonoBehaviour
{

    public LayerMask mask;
    public float avoid_distance = 5.0f;

    Move move;
    SteeringSeek seek;

    public RayClass[] rays;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 2: Agents must avoid any collider in their way
        // 1- Create your own (serializable) class for rays and make a public array with it
        // 2- Calculate a quaternion with rotation based on movement vector
        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        // 4- Make sure there is debug draw for all rays (below in OnDrawGizmosSelected)
        float current_angle = Mathf.Atan2(move.movement.x, move.movement.z) * Mathf.Rad2Deg;
        RaycastHit hit;
        foreach (RayClass ray in rays)
        {
            Vector3 rotation_vector = Quaternion.AngleAxis(current_angle, Vector3.up) * ray.direction;

            if (Physics.Raycast(transform.position, rotation_vector, out hit, ray.max_distance, mask))
            {
                Debug.DrawRay(move.transform.position, ray.direction * ray.max_distance, Color.green);
                Vector3 escape_vector = hit.point + hit.normal * avoid_distance;
               
                seek.Steer(escape_vector);
            }
            else
            {
                Debug.DrawRay(move.transform.position, ray.direction * ray.max_distance, Color.red);
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if (move && this.isActiveAndEnabled)
        {
            Gizmos.color = Color.red;
            float angle = Mathf.Atan2(move.movement.x, move.movement.z);
            Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);


        }
    }
}

