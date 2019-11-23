using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    public Transform pos1, pos2;//end point
    public float speed;
    public Transform startPos;
    public bool isFrozen;

    Vector3 nextPos;//move to this endpoint


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(speed);
        nextPos = startPos.position;
        if (transform.parent.gameObject.CompareTag("PlatformWaterfall")) {
            PlatformWaterfall myParent = GetComponentInParent<PlatformWaterfall>();
            speed = myParent.speed;
        }
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            //at endpoint set next end point
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            //at endpoint set next end point
            transform.position = pos1.position;
        }
        if (isFrozen)
        {
            //do slidey stuff
            //change art?
        }
        else
        {
            //Move
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
