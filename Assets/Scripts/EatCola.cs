using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCola : MonoBehaviour
{
    public static bool isCola;
    public static bool isGoldenCola;
    public Material regularSkybox;
    public Material colaSkybox;
    public Material goldenColaSkybox;
    public static int colaJumpingAbility;
    public static float goldenColaJumpingAbility;
    public AudioSource audioSource;
    public AudioClip eatColaSound;
    public AudioClip buyColaSound;
    public AudioClip goldenColaSound;
    Coroutine currentColaCoroutine;
    
    void Start()
    {
        isCola = false;
        isGoldenCola = false;
        colaJumpingAbility = 1;
        goldenColaJumpingAbility = 1;
        currentColaCoroutine = null;
    }

    void Update()
    {

        if (isCola && currentColaCoroutine == null)
        {
            currentColaCoroutine = StartCoroutine(ColaMode());
        }
        PlayerBuyCola();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Cola")
        {
            Destroy(hit.gameObject);
            isCola = true;
            audioSource.PlayOneShot(eatColaSound);
            if (currentColaCoroutine != null)
            {
                StopCoroutine(currentColaCoroutine);
                currentColaCoroutine = null;
            }

            currentColaCoroutine = StartCoroutine(ColaMode());
        }
        if (hit.gameObject.tag == "GoldenCola")
        {
            Destroy(hit.gameObject);
            RenderSettings.skybox = goldenColaSkybox;
            goldenColaJumpingAbility = 3.5f;
            isGoldenCola = true;
            audioSource.PlayOneShot(goldenColaSound);

        }
    }

    void PlayerHasColaOnHim()
    {
        RenderSettings.skybox = colaSkybox;
        colaJumpingAbility = 2;
    }
    void PlayerHasNoColaOnHim()
    {
        isCola = false;
        RenderSettings.skybox = regularSkybox;
        colaJumpingAbility = 1;  
    }
    void PlayerBuyCola()
    {
        if (Input.GetKeyDown(KeyCode.P) && MyUIManager.canBuy)
        {
            isCola = true;
            EatCoins.coinsAmount -= 15;
            audioSource.PlayOneShot(buyColaSound);
            if (currentColaCoroutine != null)
            {
                StopCoroutine(currentColaCoroutine);
                currentColaCoroutine = null;
            }

            currentColaCoroutine = StartCoroutine(ColaMode());
        }
    }
    IEnumerator ColaMode()
    {
        PlayerHasColaOnHim();
        yield return new WaitForSecondsRealtime(10);
        PlayerHasNoColaOnHim();
        currentColaCoroutine = null;
    }
}
