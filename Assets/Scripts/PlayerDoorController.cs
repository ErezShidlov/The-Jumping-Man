using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoorController : MonoBehaviour
{
    // Animations
    Animation anmControl;

    // Physics
    public bool isTouching;
    float radius;
    public LayerMask playerLayerMask;
    public Transform playerCheck;

    // Sounds
    public AudioSource audioSource;
    public AudioClip openDoorSound;

    void Start()
    {
        // Animations
        anmControl = GetComponent<Animation>();

        // Physics
        isTouching = false;
        radius = 1.5f;
    }


    void Update()
    {
        if (Physics.CheckSphere(playerCheck.position, radius, playerLayerMask) && PlayerMovement.hasKey)
        {
            anmControl.Play("Door_Open");
            audioSource.PlayOneShot(openDoorSound);
            PlayerMovement.hasKey = false;
            
        }
    }
    public void Level1toLevel2()
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void Level2toLevel3()
    {
        SceneManager.LoadScene("LevelThree");
    }
    public void Level3toLevel4()
    {
        SceneManager.LoadScene("LevelFour");
    }
    public void Level4toLevel5()
    {
        SceneManager.LoadScene("LevelFive");
    }
    public void Level5toExitMenu()
    {
        SceneManager.LoadScene("ExitMenu");
    }
}
