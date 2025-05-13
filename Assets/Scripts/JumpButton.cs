using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public void OnPointerDown(PointerEventData data)
    {
        if (PlayerJump.instance != null)
        {
            PlayerJump.instance.SetPower(true);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (PlayerJump.instance != null)
        {
            PlayerJump.instance.SetPower(false);
        }
    }

}
