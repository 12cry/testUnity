


using Cry.Common;
using UnityEngine;

public class CanvasCtrl : Singleton<CanvasCtrl>
{
    public  Transform _transform { get; set; }
    protected override void Awake()
    {
        base.Awake();
        init();
    }

    void OnEnable()
    {
        _transform = transform;
    }

    void init()
    {

    }

}
