using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRange : MonoBehaviour
{
    public float detectRange=5f;
    public Transform range;
    public LayerMask detectLayer;
    CircleCollider2D collider2D;
    void Start()
    {
        collider2D= GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        collider2D.transform.position = range.position;
        collider2D.transform.localScale = new Vector3(detectRange, 0f, 0f);
    }
    private void OnDrawGizmosSelected()
    {
        if (range == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(range.position, detectRange);

    }
    void FeedBack() 
    {
      
    }
}

