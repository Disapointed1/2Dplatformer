using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDamage : MonoBehaviour
{
    private int _poisonDamage = 40;
    public PlatformerPlayer _player;

    public void OnButtonClick()
    {
        _player.TakeDamage(_poisonDamage);
    }
}

