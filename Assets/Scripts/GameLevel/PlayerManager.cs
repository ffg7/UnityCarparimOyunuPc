using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topclip;

    float angle;
    float donusHizi = 5f;

    float ikiMermiArasi = 500f;
    float sonrakiAtis;

    public bool rotateDegissinMi;

    bool atsinMi;

    private void Start()
    {
        atsinMi = true;
        rotateDegissinMi = false;
    }

    void Update ()
    {
        if (rotateDegissinMi)
        {
            RotateDegistir();
        }
        
	}

    private void RotateDegistir()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (angle > -45 && angle < 45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
            
        }





        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time > sonrakiAtis)
            {
                if (PlayerPrefs.GetInt("sesDurumu") == 1)
                {
                    audioSource.PlayOneShot(topclip);
                }
                sonrakiAtis = Time.time + ikiMermiArasi / 1000f;
                atsinMi = !atsinMi;
                MermiAt();
            }

        }


    }

    private void MermiAt()
    {
        if (atsinMi == true) 
        {
            GameObject mermi = Instantiate(mermiPrefab[Random.Range(0, mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation);
        }
        
    }
}
