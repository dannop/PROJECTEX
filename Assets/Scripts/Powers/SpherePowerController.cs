using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePowerController : MonoBehaviour
{
    Transform target;

    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 180.0f;

    private void Awake()
    {
        target = GameObject.Find("OVRPlayerController").transform;
    }

    void Orbit()
    {
        if (target != null)
        {
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        Orbit();
    }
}
