using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : MonoBehaviour
{
    public Transform[] waypoints;
    private Animator animator;
    public float moveSpeed = 3f;
    
    private int currentWaypointIndex = 0;

    private void Start()
    {
        // Get the Animator component from the same GameObject
        animator = GetComponent<Animator>();

        // Check if the Animator component was found
        if (animator == null)
        {
            return;
        }
    }
    
    private void Update()
    {
        // Check if there are waypoints defined
        if (waypoints.Length > 0 && animator.GetBool("isChasing") == false)
        {
            // Get the current waypoint
            Transform currentWaypoint = waypoints[currentWaypointIndex];

            // Calculate the direction from current position to target position
            Vector3 direction = currentWaypoint.position - transform.position;
            bool isMovingRight = direction.x > 0;

            if (isMovingRight)
            {
                // Additional logic for moving right
               transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
            else
            {
                // Additional logic for moving left
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            // Move towards the current waypoint
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                // Increment the waypoint index or reset to 0 if it reaches the end
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
        else{
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
