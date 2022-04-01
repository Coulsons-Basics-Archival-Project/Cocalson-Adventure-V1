using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonkTrigger : MonoBehaviour
{
    public UnityEvent onBonk;

    private void OnCollisionEnter2D(Collision2D other)
    {
        onBonk.Invoke();
        Debug.Log("Bonk!");
    }
}
