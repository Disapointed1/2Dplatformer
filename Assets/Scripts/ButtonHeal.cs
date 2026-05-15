using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeal : MonoBehaviour
{
   public PlatformerPlayer _player;
   private int _healAmount = 35;

   public void OnButtonClick()
   {
      _player.Heal(_healAmount);
   }
}
