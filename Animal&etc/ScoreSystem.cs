using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int PlayerHP = 3;
    public GameObject[] HP = new GameObject[3];
    public bool isDamage = false;
    public GameObject DamageEff;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayerState());
    }

    IEnumerator PlayerState()
    {
        while (PlayerHP > 0)
        {
            DamageEff.SetActive(true);
            DamageEff.SetActive(false);
            if (isDamage)
            {
                DamageEff.SetActive(true);
                PlayerHP--;
                HP[PlayerHP].SetActive(false);
                isDamage = false;
                yield return new WaitForSeconds(0.15f);
                DamageEff.SetActive(false);
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
