using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatusSO", menuName = "Player/PlayerStatus", order = 1)]

public class PlayerStatus : ScriptableObject
{
    public int max_health;
    public int current_health;
    public int damage;

}
