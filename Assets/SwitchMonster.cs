using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMonster : MonoBehaviour
{
    public Sprite kitsuSp, magmaSp;

    public GameObject kitsuGb, magmaGb;

    public Image selfIm;

    public int index;


    public void SwitchMonsterHandler()
    {
        if (index == 0)
        {
            selfIm.sprite = kitsuSp;
            kitsuGb.SetActive(false);
            magmaGb.SetActive(true);
            index = 1;
        }
        else
        {
            selfIm.sprite = magmaSp;
            magmaGb.SetActive(false);
            kitsuGb.SetActive(true);
            index = 0;
        }
    }


}
