using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public LevelController controller;
    public CharacterMovement movement;
    public AudioClip winSong;
    public string finishScene;

    bool allow = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && allow)
        {
            allow = false;

            Debug.Log("Win");

            movement.allowMovement = false;
            controller.music.Stop();
            controller.SFX.PlayOneShot(winSong);
            StartCoroutine(nextScene());

            IEnumerator nextScene()
            {
                yield return new WaitForSeconds(3.5f);
                SceneManager.LoadSceneAsync(finishScene);
            }
        } 
    }
}
