using UnityEngine;
using System.Collections;

public class SteeringWander : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 1.0f;


    public float distanceToCircle = 4.0f;
    public float circleRadius = 1.0f;
    public float wanderRate = 0.1f;
    private SteeringSeek seek;

    private Vector3 target = Vector3.zero;

    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        seek = GetComponent<SteeringSeek>();
	}

	// Update is called once per frame
	void Update () 
	{
        if (timer >= wanderRate)
        {
            // Update the target
            Vector3 Direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));

            Vector3 circlePosition = transform.position + transform.forward * distanceToCircle;
            target = circlePosition + Direction * circleRadius;

            timer = 0.0f;
        }

        timer += Time.deltaTime;

        seek.Steer(target);
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
