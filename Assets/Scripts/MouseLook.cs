using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    public GameObject projectile;
    public float projectileForce = 10;
    public float turnSpeed = 5;
    public Transform muzzle;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = -Input.GetAxis("Mouse Y");

        float shotAngle = -Input.GetAxisRaw("Vertical");

        //rotY += mouseX * mouseSensitivity * Time.deltaTime;
        //rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotX += shotAngle * turnSpeed * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        if (Input.GetKey(KeyCode.Space))
        {
            projectileForce += 5f * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            projectile.transform.position = muzzle.transform.position;
            Rigidbody r = projectile.GetComponent<Rigidbody>();
            r.velocity = new Vector3(0,0,0);
            r.AddForce(muzzle.transform.forward*projectileForce, ForceMode.Impulse);
            projectileForce = 0;
        }
    }
}
