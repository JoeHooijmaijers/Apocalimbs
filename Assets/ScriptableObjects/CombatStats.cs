using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New CombatStats", menuName ="Stats/Combat")]
public class CombatStats : ScriptableObject
{
    public int health;
    public int maxHealth;

    public int stamina;
    public int maxStamina;

    public int leftLimbAttackpower;
    public int rightLimbAttackpower;

    public int defense;
}
