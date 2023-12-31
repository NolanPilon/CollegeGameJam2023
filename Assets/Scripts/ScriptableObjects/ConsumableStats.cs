using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableData", menuName = "ScriptableObjects/Data", order = 1)]
public class ConsumableStats : ScriptableObject
{
    public int sizeValue = 1;
    public int unitType = 1;
}
