using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_MoveMent : MonoBehaviour
{
    #region ��ǥ
    /*
    ī�޶� ���� ĳ������ �ڽ����� �������� �ʰ�, 
    3��Ī TPS �������� ĳ���͸� ���� �ڿ������� ȸ���� �����ϵ��� ��

    �̸� ���ؼ� Container ��ü�� ĳ���Ϳ� ī�޶� ���� �ڽ����� �ξ� ���� �̵��� �Բ� �����ϸ鼭  ȸ���� �и�
    ī�޶󿡴� �ٽ� Holder��� �θ� ��ü�� ����� �ʱ� 3��Ī���� ��ġ�صξ��� ������ �����ǵ��� �� 
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

        float lockedX = camAngle.x - mouseDelta.y;  // ���� ���� ī�޶� ������ ����
        if (lockedX < 180)
            lockedX = Mathf.Clamp(lockedX, -1f, 75f);   //ī�޶� ����� �Ʒ��� �������� �ʴ� ������ �ذ��ϱ� ���� -1�� ����
        else
            lockedX = Mathf.Clamp(lockedX, 335f, 361f);

        holder.rotation = Quaternion.Euler(lockedX, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
