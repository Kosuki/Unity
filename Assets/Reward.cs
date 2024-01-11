using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Reward : MonoBehaviour
{
    public Image backImage;
    public Image plushPlaceholder;
    public Sprite[] plushes;
    public GameObject endImage;
    public AudioSource PlushAS;
    
    // Start is called before the first frame update
    void Start()
    {
        int count = Settings.Score / 25;
        if (Settings.Score > 0 && count != 0 && count % 1 == 0)
        {
            int index = count - 1;
            plushPlaceholder.sprite = plushes[index];
            plushPlaceholder.DOFade(1f, 1f);
            backImage.DOFade(1f, 1f);
            PlushAS.Play();
        }
        else
        {
            Destroy(backImage.gameObject);
            endImage.SetActive(true);
        }
    }

    public void click()
    {
        endImage.SetActive(true);
        plushPlaceholder.DOFade(0f, 1f);
        backImage.DOFade(0f, 1f).onComplete = () => { Destroy(gameObject);  };
    }
}
