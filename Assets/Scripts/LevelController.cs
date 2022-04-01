using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    public CharacterMovement movement;

    public AudioSource music;
    public AudioSource SFX;
    public AudioClip deathSound;
    public AudioClip battleSong;
    public GameObject deathScreen;

    public string daScene;

    public GameObject cEnd;

    public GameObject gameCam;
    public GameObject endCam;
    public GameObject ETrigger;
    public GameObject bossEnd;
    public GameObject pauseMenu;

    bool paused = false;

    public TextMeshProUGUI worldText;

    // Start is called before the first frame update
    void Start()
    {
        worldText.text = "World " + daScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (paused)
            {
                case true: Resume(); break;
                case false: Pause(); break;
            }
        }
    }

    public void Die()
    {
        music.Stop();
        SFX.PlayOneShot(deathSound);
        deathScreen.SetActive(true);
        movement.allowMovement = false;
        StartCoroutine(whyLol());

        IEnumerator whyLol()
        {
            yield return new WaitForSeconds(2.5f);

            SceneManager.LoadSceneAsync(daScene);
        }
    }

    public void CoulsonEnd()
    {
        IEnumerator end()
        {
            ETrigger.SetActive(false);
            movement.allowMovement = false;
            music.Stop();
            yield return new WaitForSeconds(1.5f);
            music.clip = battleSong;
            music.Play();
            movement.allowMovement = true;
            gameCam.SetActive(false);
            endCam.SetActive(true);
            bossEnd.SetActive(true);
        }

        StartCoroutine(end());
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        movement.allowMovement = false;
        Time.timeScale = 0;
        music.volume -= 0.8f;
        paused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        movement.allowMovement = true;
        Time.timeScale = 1;
        music.volume += 0.8f;
        paused = false;
    }
}
