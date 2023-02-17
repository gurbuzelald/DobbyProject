using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSlaveData", menuName = "SlaveData")]
public class SlaveData : ScriptableObject
{
    public float slaveSpeed;
    public bool isSwording;
    public float delayLookAt;//LookAt Function is working with delay
}
