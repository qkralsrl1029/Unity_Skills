using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_MoveMent : MonoBehaviour
{
    #region 목표
    /*
    카메라를 메인 캐릭터의 자식으로 설정하지 않고도, 
    3인칭 TPS 시점으로 캐릭터를 따라서 자연스러운 회전을 구현하도록 함

    이를 위해서 Container 객체에 캐릭터와 카메라를 각각 자식으로 두어 둘의 이동을 함께 관리하면서  회전을 분리
    카메라에는 다시 Holder라는 부모 객체를 만들어 초기 3인칭으로 배치해두었던 구도가 유지되도록 함 
    */
    #endregion

    [SerializeField]  private Transform player;
    [SerializeField] private Transform holder;
 
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = holder.rotation.eulerAngles;

        float lockedX = camAngle.x - mouseDelta.y;  // 수직 방향 카메라 움직임 제한
        if (lockedX < 180)
            lockedX = Mathf.Clamp(lockedX, -1f, 75f);   //카메라가 수평면 아래로 내려가지 않는 문제를 해결하기 위해 -1로 설정
        else
            lockedX = Mathf.Clamp(lockedX, 335f, 361f);

        holder.rotation = Quaternion.Euler(lockedX, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
