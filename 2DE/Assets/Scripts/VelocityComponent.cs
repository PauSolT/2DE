using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    Vector3 direction;
    public Vector3 Direction { get => direction; set => direction = value; }

    float velocity;
    public float Velocity { get => velocity; set => velocity = value; }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * velocity * direction;
    }
}
