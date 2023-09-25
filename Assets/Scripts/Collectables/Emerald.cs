using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : BaseCollectable
{
    [SerializeField] private float rotationSpeed = 5f;

    public override void GainBenefit()
    {
        Debug.Log($"Gained 1 Emerald");
    }

    public override void IdleBehaviour()
    {
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
