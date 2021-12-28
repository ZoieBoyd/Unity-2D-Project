using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float movementSpeed;
    public float distance;

    private bool movingRight = true;

    public Transform feet;

    private void Update()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        RaycastHit2D groundinfo = Physics2D.Raycast(feet.position, Vector2.down, distance, LayerMask.GetMask("Ground"));

        if(!groundinfo.collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false; 
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
