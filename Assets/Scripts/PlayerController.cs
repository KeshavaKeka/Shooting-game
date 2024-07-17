using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public FixedJoystick joystick;
    public float speed;

    public GameObject arrow;

    private float minX = -13;
    private float maxX = 13;
    private float minZ = -13;
    private float maxZ = 13;

    private void Update()
    {

    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * speed, rigidBody.velocity.y, joystick.Vertical * speed);

        float clampedX = Mathf.Clamp(rigidBody.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(rigidBody.position.z, minZ, maxZ);
        rigidBody.position = new Vector3(clampedX, rigidBody.position.y, clampedZ);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
        }
    }

    public void ShootArrow()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.6f);
        Instantiate(arrow, pos, transform.rotation);
    }
}