using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyUIManager : MonoBehaviour
{
    public GameObject colaImage;
    public GameObject keyImage;
    public TMP_Text coinsText;
    public GameObject miniShopText;
    public GameObject colaMiniShopImage;

    public GameObject colaTimerTextGameObject;
    public TMP_Text colaTimerText;
    float colaTimer;

    public GameObject goldenColaImage;
    public GameObject infinityText;

    public static bool canBuy;

    void Start()
    {
        colaTimer = 10f;
    }

    void Update()
    {
        ColaUI();
        GoldenColaUI();
        KeyUI();
        CoinUI();
        MiniShop();
        ColaTimerUI();
    }
    void ColaUI()
    {
        if (EatCola.isCola)
        {
            colaImage.SetActive(true);
            colaTimerTextGameObject.SetActive(true);
            
        }
        else
        {
            colaImage.SetActive(false);
            colaTimerTextGameObject.SetActive(false) ;
        }
    }
    void GoldenColaUI()
    {
        if (EatCola.isGoldenCola)
        {
            goldenColaImage.SetActive(true);
            infinityText.SetActive(true);
        }
        else
        {
            goldenColaImage.SetActive(false);
            infinityText.SetActive(false) ;
        }
    }
    void ColaTimerUI()
    {
        if (EatCola.isCola)
        {
            colaTimer -= Time.deltaTime;
            if (colaTimer <= 0)
            {
                colaTimer = 10f;
            }
            colaTimerText.text = Mathf.RoundToInt(colaTimer).ToString();
        }
    }
    void KeyUI()
    {
        if (PlayerMovement.hasKey)
        {
            keyImage.SetActive(true);
        }
        else
            keyImage.SetActive(false);
    }
    void CoinUI()
    {
        coinsText.text = EatCoins.coinsAmount.ToString();
    }
    void MiniShop()
    {
        if (EatCoins.coinsAmount >= 15)
        {
            colaMiniShopImage.SetActive(true);
            miniShopText.SetActive(true);
            canBuy = true;
        }
        else
        {
            colaMiniShopImage.SetActive(false);
            miniShopText.SetActive(false);
            canBuy = false;
        }

    }
}
