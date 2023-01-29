using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickMove : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float moveSpeed;
    private bool isMove = false;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        TryMove();
        Move();
    }

    private void TryMove()
    {
        if (!Input.GetMouseButton(1))
            return;
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition),out RaycastHit hitinfo))
        {
            Debug.Log(hitinfo.point);
            SetDestination(hitinfo.point);
        }
    }

    private void SetDestination(Vector3 pos)
    {
        destination = pos;
        isMove = true;
    }

    private void Move()
    {
        if (!isMove)
            return;
        if (Vector3.Distance(destination, transform.position) <= 0.6f)
            isMove = false;
        Vector3 dir = destination - transform.position;
        transform.position += dir.normalized * Time.deltaTime * moveSpeed;  //위치 차에 관계없이 일정한 속력을 내도록 정규화
        transform.forward = dir;
    }
}
