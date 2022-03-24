using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Apple : MonoBehaviour
{
    public delegate void Delegats();
    public event Delegats event_DestroyAplle;

    [SerializeField] private AudioSource audioDestroyApple;

    [SerializeField] private O_setImpulse SetImpylse;
    [SerializeField] private GameObject part;
    [SerializeField] private SpriteRenderer spriteApple;
    [SerializeField] private O_setImpulse O_SetImpulse;

    //private bool isTuch;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Knife" && !SetImpylse.enabled && !isTuch)
    //    {
    //        isTuch = true;
    //        DestroyApple();
    //    }
    //}

    public void DestroyApple()
    {
        audioDestroyApple.Play();

        event_DestroyAplle?.Invoke();

        spriteApple.enabled = false;

        if (!O_SetImpulse.enabled)
            part.SetActive(true);
    }

}
