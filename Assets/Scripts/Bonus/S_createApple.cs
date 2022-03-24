using UnityEngine;

public class S_createApple : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    private float startPos = 1.3f;

    private GameObject appleObject;
    public int calculateOfApple()
    {
        appleObject = null;

        int rnd = Random.Range(0, 101);

        if (rnd <= 25)
        {
            int pos = Random.Range(1, 25) * 15;
            // 24 ����� �� 15 ����
            gameObject.transform.eulerAngles = new Vector3(0, 0, pos);  // 24 ����� �� 15 ����
            appleObject = Instantiate(applePrefab);
            appleObject.transform.position = new Vector3(0, startPos, 0);
            appleObject.transform.parent = gameObject.transform;
            return pos;
        }
        else
        {
            return 0;
        }

    }

    public GameObject getAppleObject() => appleObject;
}
