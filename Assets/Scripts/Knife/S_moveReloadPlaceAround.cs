using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_moveReloadPlaceAround : MonoBehaviour
{
    public int towardsAngle;
    public int speedRotate;
    public bool readyFire;

    [SerializeField] private bool readyReload;
    private void FixedUpdate()
    {
        if (readyReload)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, towardsAngle), Time.deltaTime * speedRotate);

        if (towardsAngle == Convert.ToInt32(transform.rotation.eulerAngles.z))
        {
            readyFire = true;
            readyReload = false;
        }
        else
        {
            readyFire = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            readyReload = true;
        }
    }

}
