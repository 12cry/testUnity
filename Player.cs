using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 2;
    Vector3 target;
    private void OnMouseDown()
    {
        GameCtrl.currentSelectedPlayer = this;
        showMoveableOrAttachableTile();
    }
    void Start()
    {
        target = new Vector3(2, transform.position.y, 2);
    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log("update----------");
        Debug.Log(Time.deltaTime);

        


        //transform.Translate(new Vector3(h * Time.deltaTime * speed, 0f, v * Time.deltaTime * speed));
        //transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        Debug.Log(transform.position);
        Debug.Log("update+++++++++++");
    }
    public void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    void showMoveableOrAttachableTile()
    {

    }

}
