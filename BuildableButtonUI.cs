using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildableButtonUI : MonoBehaviour
{
    public Button button;
    public Text text;
    public Buildable buildable;

    // public event Action<Buildable> buttonClick;

    public void onClick()
    {
        // buttonClick(buildable);
        buildable.build();

    }

}