using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    public TextMeshProUGUI deathText;

    private void Start()
    {
        deathText.text = "You died " + playerData.playerDeaths + " times";
    }
}
