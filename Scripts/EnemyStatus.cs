using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Enemy/EnemyStatus", order = 2)]

public class EnemyStatus : ScriptableObject
{
    public int max_health;
    public int current_health;
    public int damage;
}
