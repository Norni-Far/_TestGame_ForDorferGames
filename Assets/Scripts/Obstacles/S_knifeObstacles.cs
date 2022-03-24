using System.Collections.Generic;
using UnityEngine;

public class S_knifeObstacles : MonoBehaviour
{
    private float startPos = 1.0f;
    private bool hasPlace;

    public List<GameObject> emptyKnifes = new List<GameObject>();
    public void calculateOfKnifeObstacles(int[] posForKnife, GameObject[] prefabsOfKnifes)
    {
        int rndColKnifes = Random.Range(1, 4);
        int pos;

        for (int i = 1; i <= rndColKnifes; i++)
        {
            do
            {
                pos = Random.Range(0, 25) * 15;

                hasPlace = true;
                foreach (var item in posForKnife)
                {
                    if (item == pos)
                        hasPlace = false;
                }

            } while (!hasPlace);

            posForKnife[i] = pos;

            gameObject.transform.eulerAngles = new Vector3(0, 0, pos);  // 24 части по 15 град
            GameObject inst = Instantiate(prefabsOfKnifes[Random.Range(0,4)]);
            inst.transform.position = new Vector3(0, startPos, 0);
            inst.transform.parent = gameObject.transform;
            emptyKnifes.Add(inst);
        }

        
    }
}
