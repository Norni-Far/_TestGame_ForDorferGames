using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_moveKnife : MonoBehaviour
{
    [SerializeField] private AudioSource audioMetanie;
    [SerializeField] private Rigidbody2D Rigidbody;

    [SerializeField] private float speedAtack;
    public void Attack()
    {
        audioMetanie.Play();
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody.AddForce(new Vector2(0, speedAtack), ForceMode2D.Impulse);
    }


}
