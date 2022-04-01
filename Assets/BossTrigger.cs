using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public LevelController controller;
    bool allow = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && allow)
        {
            allow = false;
            Debug.Log("Boss");
            controller.CoulsonEnd();
        } 
    }
}
