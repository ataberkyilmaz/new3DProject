using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform cameraTransform;    

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            projectile.transform.position = cameraTransform.position;
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            Vector3 direction = cameraTransform.TransformDirection(Vector3.forward);
            projectileRb.velocity = direction * projectileSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = cameraTransform.TransformDirection(Vector3.forward) * projectileSpeed;
        Gizmos.DrawRay(cameraTransform.position, direction);
    }
}
