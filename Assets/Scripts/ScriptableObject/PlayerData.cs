using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO")]
public class PlayerData : ScriptableObject
{
    public int playerCoins;
    public int playerDeaths;
    public Action OnPlayerDeath;
}
