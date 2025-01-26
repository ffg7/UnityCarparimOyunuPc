using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private Text soruText, birinciText, ikinciText, ucuncuText;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    string hangiOyun;
    int birinciCarpan, ikinciCarpan, dogruSonuc;
    int birinciYanlis, ikinciYanlis;
    public int dogruAdet, yanlisAdet, puan;

    PlayerManager playerManager;


    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }

    void Start () {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        dogruAdet = 0;
        yanlisAdet = 0;
        puan = 0;
        if (PlayerPrefs.HasKey("hangiOyun"))
        {

            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }

        StartCoroutine(baslaYaziRoutine());
        
	}

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();
    }

    private void OyunaBasla()
    {
        playerManager.rotateDegissinMi = true;
        SoruyuYazdir();
    }

    private void BirinciCarpanYazdir()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;
            case "üç":
                birinciCarpan = 3;
                break;
            case "dört":
                birinciCarpan = 4;
                break;
            case "beş":
                birinciCarpan = 5;
                break;
            case "altı":
                birinciCarpan = 6;
                break;
            case "yedi":
                birinciCarpan = 7;
                break;
            case "sekiz":
                birinciCarpan = 8;
                break;
            case "dokuz":
                birinciCarpan = 9;
                break;
            case "on":
                birinciCarpan = 10;
                break;
            case "karışık":
                birinciCarpan = Random.Range(2, 11);
                break;
        }
        
    }

    private void SoruyuYazdir()
    {
        BirinciCarpanYazdir();
        ikinciCarpan = Random.Range(2, 11);
        int rastgeleDeger = Random.Range(0, 100);
        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + " x " + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + " x " + birinciCarpan.ToString();
        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        SonuclariYazdir();
    }

    void SonuclariYazdir()
    {
        birinciYanlis = dogruSonuc + birinciCarpan;
        ikinciYanlis = dogruSonuc - birinciCarpan;
        int rastgeleDeger = Random.Range(0, 100);
        int rastgeleDeger2 = Random.Range(0, 100);
        if (rastgeleDeger <= 33)
        {
            birinciText.text = dogruSonuc.ToString();
            if (rastgeleDeger2 < 50)
            {
                ikinciText.text = birinciYanlis.ToString();
                ucuncuText.text = ikinciYanlis.ToString();
            }
            else
            {
                ikinciText.text = ikinciYanlis.ToString();
                ucuncuText.text = birinciYanlis.ToString();
            }
        }
        else if(rastgeleDeger>33&& rastgeleDeger <= 66)
        {
            ikinciText.text = dogruSonuc.ToString();
            if (rastgeleDeger2 < 50)
            {
                birinciText.text = birinciYanlis.ToString();
                ucuncuText.text = ikinciYanlis.ToString();
            }
            else
            {
                ucuncuText.text = ikinciYanlis.ToString();
                birinciText.text = birinciYanlis.ToString();
            }
        }
        else
        {
            ucuncuText.text = dogruSonuc.ToString();
            if (rastgeleDeger2 < 50)
            {
                ikinciText.text = birinciYanlis.ToString();
                birinciText.text = ikinciYanlis.ToString();
            }
            else
            {
                birinciText.text = ikinciYanlis.ToString();
                ikinciText.text = birinciYanlis.ToString();
            }
        }
    }

    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            puan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, 0.1f);
        }
        else
        {
            yanlisAdet++;
            puan -= 20;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, 0.1f);
        }
        SoruyuYazdir();
        dogruText.text = dogruAdet.ToString() + " DOĞRU";
        yanlisText.text = yanlisAdet.ToString() + " YANLIŞ";
        puanText.text = puan.ToString() + " PUAN";
    }
	
	
}
