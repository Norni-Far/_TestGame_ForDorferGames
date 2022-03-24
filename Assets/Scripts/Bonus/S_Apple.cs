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

    public void DestroyApple()
    {
        audioDestroyApple.Play();
        event_DestroyAplle?.Invoke();
        spriteApple.enabled = false;

        if (!O_SetImpulse.enabled)
            part.SetActive(true);
    }

}
