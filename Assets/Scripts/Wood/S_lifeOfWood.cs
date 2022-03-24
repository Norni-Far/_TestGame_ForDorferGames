using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_lifeOfWood : MonoBehaviour
{
    public delegate void Delegats();
    public event Delegats event_gamerWinner;

    [SerializeField] private AudioSource createWood;
    [SerializeField] private AudioSource destroyWood;


    [SerializeField] private SpriteRenderer fullSpriteOfWood;
    private GameObject objestsParts;
    [SerializeField] private GameObject partsOfWoodPrefab;

    public int lifeOfWood;

    [SerializeField] private List<GameObject> fallObjects = new List<GameObject>();

    public void nullOfFallObjects() => fallObjects = new List<GameObject>();

    public void minuslifeOfWood(GameObject knife)
    {
        lifeOfWood--;
        fallObjects.Add(knife);

        StartCoroutine(takeDamaheAnim());
    }

    private IEnumerator takeDamaheAnim()
    {
        fullSpriteOfWood.color = new Color(1, 0.6f, 0.6f, 1);
        yield return new WaitForSeconds(0.05f);
        fullSpriteOfWood.color = new Color(1, 1, 1, 1);

        if (lifeOfWood == 0)
            DestroyWood();

    }

    public void addEmptyWoods(List<GameObject> emptyKnifes)
    {
        foreach (var item in emptyKnifes)
        {
            fallObjects.Add(item);
        }
    }

    public void CreateWood()
    {
        fallObjects.Clear();
        createWood.Play();
        fullSpriteOfWood.enabled = true;
        objestsParts = Instantiate(partsOfWoodPrefab, gameObject.transform);
    }

    private void DestroyWood()
    {
        foreach (var item in fallObjects)
        {
            item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            item.GetComponent<O_setImpulse>().enabled = true;
            item.gameObject.tag = "Untagged";
        }
        fallObjects.Clear();
        fullSpriteOfWood.enabled = false;
        objestsParts.SetActive(true);
        Vibration.Vibrate(400);

        destroyWood.Play();

        event_gamerWinner?.Invoke();
    }

    public void addItemObjectForListOfFallObjects(GameObject Item) => fallObjects.Add(Item);



}
