using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowersController : MonoBehaviour
{
    [SerializeField] Rigidbody power;

    void Start()
    {
        Instantiate(power, transform.position, power.transform.rotation);
    }
}
