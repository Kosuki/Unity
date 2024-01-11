using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Data/Waves/New Wave")]
public class WaveScriptable : ScriptableObject
{
    // Enemies info
    public GameObject[] targets;
    public float enemyRateMax;
    public bool actived = false;
    public float enemySpeed;
}
