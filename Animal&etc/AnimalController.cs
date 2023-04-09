using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
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
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        movement3D.MoveTo(hit.point);
        //    }
        //}
        //if (Input.GetMouseButtonDown(0))
       // {
         //   movement3D.MoveTo(target.position);
       // }
    }
}
