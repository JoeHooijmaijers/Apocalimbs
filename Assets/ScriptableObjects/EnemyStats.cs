using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New EnemyStats", menuName ="Stats/Enemy")]
public class EnemyStats : ScriptableObject
{
    public float turnSpeed;
    public float awareness;
    public string triggerName;
}
