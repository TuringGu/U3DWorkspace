using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {

    public float speed = 1; // Cube moving speed
    private Vector3 target; // Target location
    private bool isOver = true; // Weather moving end

    // Update is called once per frame
    void Update()
    {
        // Obtain the target location when mouse click
        // Using ray to implement

        // Create ray: from camera through mouse to the location on the plane
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Delivering a ray
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitInfo))
        {   // Obtain collision location
            if (string.Equals(hitInfo.collider.name, "Plane"))
            {
                target = hitInfo.point;
                target.y = 0.5f;
                isOver = false; // Start a new target
            }
        }

        // Moving object to the target
        MoveTo(target);
    }

    // Moving object to the target
    private void MoveTo(Vector3 tar)
    {
        if (!isOver)
        {   // When not in the target
            Vector3 v1 = tar - transform.position;
            transform.position += v1.normalized * speed * Time.deltaTime;
            if (Vector3.Distance(tar, transform.position) <= 0.3f)
            {
                isOver = true;
                transform.position = tar;
            }
        }
    }
}
