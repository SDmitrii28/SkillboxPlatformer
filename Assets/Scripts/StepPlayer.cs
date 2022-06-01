using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPlayer : MonoBehaviour
{
    public void PlayStep()
    {
        GetComponentInParent<PlayerController>().playRandomStep();
    }
}
