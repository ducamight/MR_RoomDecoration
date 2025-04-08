using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.Instance.Play("ButtonSound");
    }
}
