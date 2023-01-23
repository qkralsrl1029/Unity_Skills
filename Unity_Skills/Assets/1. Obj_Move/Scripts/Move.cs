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
        move_Addforce,
        move_Velocity
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

        if (myState == moveState.move_Vector)
            transform.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        else if (myState == moveState.move_Translate)
            transform.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        else if (myState == moveState.move_Addforce)
            rigid.AddForce(new Vector3(h, 0, v) * moveSpeed);
        else
            rigid.velocity = new Vector3(h, 0, v) * moveSpeed;
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))        
            rigid.velocity = new Vector3(0, 1, 0) * jumpPower;      
    }
}
