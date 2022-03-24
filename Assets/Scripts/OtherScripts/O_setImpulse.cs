using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class O_setImpulse : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody;

    void Start()
    {
        transform.parent = null;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody.gravityScale = 1;
        Rigidbody.AddForce(new Vector2(Random.Range(-2, 2.1f), Random.Range(0, 1.1f)), ForceMode2D.Impulse);
        Rigidbody.angularVelocity = Random.Range(60, 300.01f);
        StartCoroutine(StartDestroy());
    }

    IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
