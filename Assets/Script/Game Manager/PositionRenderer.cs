using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderer : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnce = false;

    private float timer;
    private float maxTimer = .1f;
    private Renderer renderer;
    
    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = maxTimer;
            renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnce)
            {
                Destroy(this);
            }
        }
        
    }
}
