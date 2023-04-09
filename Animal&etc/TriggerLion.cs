using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLion : MonoBehaviour
{
    SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "HappyStage")
        {
            sceneChanger.LoadScene("HappyEnding");
        }
    }
}
