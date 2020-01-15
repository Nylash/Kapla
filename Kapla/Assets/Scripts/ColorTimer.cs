using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTimer : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Gradient colors;
#pragma warning restore 0649
    Image counter;

    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();
    }

    void Update()
    {
        if(!GameManager.instance.timerStopped)
            counter.color = colors.Evaluate(GameManager.instance.timer / GameManager.instance.timeBeforeAutoDrop);
    }
}
