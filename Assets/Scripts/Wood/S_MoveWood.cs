using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveWood : MonoBehaviour
{
    [SerializeField] private HingeJoint2D Motor;
    [SerializeField] private Rigidbody2D Rigidbody;
    public int SpeedRotation;

    public int timeOfSpeedMaxForWood;
    public int timeOfSpeedMinForWood;

    private JointMotor2D newMotor;
    private int Speed;
    private void Start()
    {
        newMotor.motorSpeed = SpeedRotation;
        newMotor.maxMotorTorque = 10000;
        StartCoroutine(changeRound());
    }

    IEnumerator changeRound()
    {
        while (true)
        {
            for (int i = 0; i < 100; i++)
            {
                Speed = SpeedRotation + i;
                yield return new WaitForSeconds(0.02f);
            }

            yield return new WaitForSeconds(timeOfSpeedMaxForWood);

            for (int i = 100; i > 0; i--)
            {
                Speed = SpeedRotation + i;
                yield return new WaitForSeconds(0.02f);
            }

            yield return new WaitForSeconds(timeOfSpeedMinForWood);
        }
    }



    private void FixedUpdate()
    {
        newMotor.motorSpeed = Speed + 10;
        Motor.motor = newMotor;
    }


}
