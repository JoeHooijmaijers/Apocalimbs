using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerStats", menuName = "PlayerStats") ]
public class PlayerStats : ScriptableObject
{
    public int movementSpeed;
    public float jumpHeight;
    public float RotationSpeed;
    public float rollSpeed;
}
