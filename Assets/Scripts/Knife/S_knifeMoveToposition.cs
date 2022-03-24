using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_knifeMoveToposition : MonoBehaviour
{
    [SerializeField] private Transform placeOfCircleForknifes;
    [SerializeField] private Transform[] posForKnifes = new Transform[9];

    public GameObject[] OnReloadKnifes(GameObject chooseKnifesPrefab, int maxCountknifes)
    {
        GameObject[] lisstOfknifes = new GameObject[9];

        for (int i = 0; i < maxCountknifes; i++)
        {
            lisstOfknifes[i] = Instantiate(chooseKnifesPrefab, posForKnifes[i]);
            lisstOfknifes[i].transform.parent = posForKnifes[i];
        }

        return lisstOfknifes;
    }

}
