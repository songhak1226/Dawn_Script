using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrail : MonoBehaviour
{
    //Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CubeGO();
    }

    void CubeGO()
    {
        //rigidbody.AddForce(Vector3.forward* 50f, ForceMode.VelocityChange);
    }
}
