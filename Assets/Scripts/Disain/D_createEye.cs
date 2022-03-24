using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_createEye : MonoBehaviour
{
    [SerializeField] private GameObject prefabEye;

    private float spawnCubeX = 2.1f;
    private float spawnCubeY = 4.1f;

    public void Start()
    {
        StartCoroutine(CreateDisajn());
    }

    private IEnumerator CreateDisajn()
    {
        yield return new WaitForSeconds(18f);

        for (int i = 0; i < 17; i++)
        {
            GameObject Inst = Instantiate(prefabEye, transform);
            Inst.transform.position = new Vector3(Random.Range(-spawnCubeX, spawnCubeX), Random.Range(-spawnCubeY, spawnCubeY), 0);
            Inst.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
            yield return new WaitForSeconds(Random.Range(40, 81f));
        }

        yield return new WaitForSeconds(40f);
        GameObject Inst2 = Instantiate(prefabEye, transform);
        Inst2.transform.localScale = new Vector3(1, 1, 1);
        Inst2.transform.position = new Vector3(0, 2, 0);
    }
}
