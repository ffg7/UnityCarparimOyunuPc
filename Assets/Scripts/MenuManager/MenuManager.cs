using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject sesImage;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonclip;

    bool sesImageAcikMi;
	void Start () {
        sesImageAcikMi = false;
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
	}

    public void IkinciLeveleGec()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonclip);
        }
        
        SceneManager.LoadScene("IkinciMenuLevel");
    }
    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonclip);
        }
        if (!sesImageAcikMi)
        {
            sesImage.GetComponent<RectTransform>().DOLocalMoveY(-173, 0.5f);
            sesImageAcikMi = true;
        }
        else
        {
            sesImage.GetComponent<RectTransform>().DOLocalMoveY(-73, 0.5f);
            sesImageAcikMi = false;
        }
        //Daha Sonra
    }
    public void OyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonclip);
        }
        Application.Quit();
    }
	
	
}
