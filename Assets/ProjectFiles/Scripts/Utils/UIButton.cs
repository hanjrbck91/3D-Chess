using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIInputReciever))]
public class UIButton : Button
{
    private InputReciever reciever;

    protected override void Awake()
    {
        base.Awake();
        reciever = GetComponent<InputReciever>();
        onClick.AddListener(() => reciever.OnInputRecieved());
    }
}
