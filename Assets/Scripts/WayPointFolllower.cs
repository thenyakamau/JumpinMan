using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFolllower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        Vector2 position = waypoints[currentWayPointIndex].transform.position;
        float distance = Vector2.Distance(position, transform.position);

        if (distance < 1f)
        {
            currentWayPointIndex++;

            if (currentWayPointIndex >= waypoints.Length)
                currentWayPointIndex = 0;
        }

        float distanceTraveled = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, position, distanceTraveled);
    }
}
