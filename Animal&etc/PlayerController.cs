using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Movement3D movement3D;
    [SerializeField] Transform target;

    private void Awake()
    {
        {
            movement3D = GetComponent<Movement3D>();
        }
    }

    void Update()
    {
        movement3D.MoveTo(target.position);
    
    }
}
