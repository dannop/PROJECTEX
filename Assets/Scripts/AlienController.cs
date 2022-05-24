using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private void Update()
    {
        transform.LookAt(playerTransform);
        
    }

}
