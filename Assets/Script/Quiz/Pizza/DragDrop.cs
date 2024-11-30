using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 _offset = new Vector3(0,0,10);
    private Vector3 _mousePos;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (this)
        {
            transform.position = _mousePos + _offset;
        }
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
                Debug.Log("Touching Player");
                break;
        }
    }*/
}
