using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Blackhole : MonoBehaviour
{
    public Volume volume;
    float time;
    //private Bloom b;
    private LensDistortion ld;
    //VolumeProfile VolumeProfile;

    void Start()
    {
        volume = GetComponent<Volume>();
        //volume.profile.TryGet(out b);
        volume.profile.TryGet(out ld);
    }
    void Update()

    {
        time += Time.deltaTime;

        //volume.weight = time;
        ld.intensity.value -= time * 0.1f;
        ld.scale.value -= time * 0.1f;
        Mathf.Clamp(ld.scale.value, 0.34f, 2f);

        if (ld.scale.value < 0.54f)

        {
            StartCoroutine(delay());
        }

    }

    IEnumerator delay()

    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);

    }



}
