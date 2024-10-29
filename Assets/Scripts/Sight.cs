using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask obstacleLayers;
    public LayerMask objectsLayers;
    public GameObject detectedObject;

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);
        
        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);

        detectedObject = null;
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstacleLayers))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider.gameObject;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }
}


