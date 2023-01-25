using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] private moveState myState;
    private enum moveState
    {
        move_Vector,
        move_Translate,
        move_Towards,
        move_Addforce,
        move_Velocity,
        move_Lerp
    }

    private Rigidbody rigid;

    private void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        move();
        jump();
    }

    private void move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // with manipulating obj's transformation, no physical calc
        // equal velocity
        if (myState == moveState.move_Vector)
            transform.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        else if (myState == moveState.move_Translate)
            transform.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        else if (myState == moveState.move_Towards)     // set destination
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(h, 0, v), moveSpeed * Time.deltaTime);
        // with using rigidboy, physical calc
        else if (myState == moveState.move_Addforce)    // add physical force
            rigid.AddForce(new Vector3(h, 0, v) * moveSpeed);
        else if (myState == moveState.move_Velocity)   // modifying obj speed
            rigid.velocity = new Vector3(h, 0, v) * moveSpeed;
        else
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(h, 0, v), moveSpeed * Time.deltaTime);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))        
            rigid.velocity = new Vector3(0, 1, 0) * jumpPower;      
    }
}
