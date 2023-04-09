using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatResult : MonoBehaviour
{
    [SerializeField] GameObject Result;
    // Start is called before the first frame update
    private void Awake()
    {
        Invoke("floatR", 4.5f); 
    }
    void Start()
    {

    }

    void floatR()
    {
        Result.gameObject.SetActive(true);
    }

    // Update is called once per frame  
    void Update()
    {
        
    }
}
