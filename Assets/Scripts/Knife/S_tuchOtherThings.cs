using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_tuchOtherThings : MonoBehaviour
{
    public delegate void DelegatsForDestroyWood(GameObject knife);
    public event DelegatsForDestroyWood event_tuchOfWood;

    public delegate void DelegatsForUITuchOfWood();
    public event DelegatsForUITuchOfWood event_forUITuchOfWood;

    public delegate void DelegatsForFinish();
    public event DelegatsForFinish event_tuchOfKnife;

    [SerializeField] private AudioSource audio_tuchWood;
    [SerializeField] private AudioSource audio_tucKnife;


    [SerializeField] private CapsuleCollider2D Collider;
    [SerializeField] private Rigidbody2D Rigidbody;

    [SerializeField] private BoxCollider2D rucoyatOfKnife;
    [SerializeField] private GameObject particleTuchWood;

    [SerializeField] private bool tuchKnife;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knife" && !tuchKnife)
        {
            audio_tucKnife.Play();

            gameObject.tag = "Untagged";
            tuchKnife = true;
            Collider.enabled = false;

            //Rigidbody.bodyType = RigidbodyType2D.Dynamic;

            Rigidbody.velocity = new Vector2(0, 0);
            Rigidbody.angularVelocity = Random.Range(300, 600.01f);
            Rigidbody.gravityScale = 0.7f;
            Vibration.Vibrate(100);


            event_tuchOfKnife?.Invoke();

            Destroy(this);
        }

        if (collision.gameObject.tag == "Wood" && !tuchKnife)
        {
            audio_tuchWood.Play();

            Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.parent = collision.gameObject.transform;
            Collider.enabled = false;
            rucoyatOfKnife.enabled = true;

            event_tuchOfWood?.Invoke(gameObject);
            event_forUITuchOfWood?.Invoke();
            particleTuchWood.SetActive(true);
            Vibration.Vibrate(100);

            Destroy(this);
        }


        if (collision.gameObject.tag == "Apple")
        {
            collision.gameObject.GetComponent<S_Apple>().DestroyApple();
        }
    }

}
