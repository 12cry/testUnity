using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestEvent : MonoBehaviour, IPointerDownHandler,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag---------");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick---------");
    }

    // private void OnMouseDown()
    // {
    //     Debug.Log("TestEvent-OnMouseDown-----------");
    // }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown---------");
    }


    public void test()
    {
        Debug.Log("test--");
    }

}
