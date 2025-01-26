using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    [SerializeField]
    private Text Suretext;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject zamanImage, dogruYanlisImage, puanDogruYanlisPanel, player, sonuclar;

    int kalanSure;
    bool sureSaysinmi;

	void Start () {

        sonucPaneli.SetActive(false);
        zamanImage.SetActive(true);
        dogruYanlisImage.SetActive(true);
        puanDogruYanlisPanel.SetActive(true);
        player.SetActive(true);
        sonuclar.SetActive(true);
        kalanSure = 90;
        sureSaysinmi = true;
        StartCoroutine(SureTimerRoutıne());
	}

    IEnumerator SureTimerRoutıne()
    {
        

        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                Suretext.text = "0"+kalanSure.ToString();
            }
            else
            {
                Suretext.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                Suretext.text = "";
                EkraniTemizle();
                sonucPaneli.SetActive(true);
            }

            kalanSure--;

        }
       
    }

    void EkraniTemizle()
    {
        

        zamanImage.SetActive(false);
        dogruYanlisImage.SetActive(false);
        puanDogruYanlisPanel.SetActive(false);
        player.SetActive(false);
        sonuclar.SetActive(false);
    }
	
	
}
