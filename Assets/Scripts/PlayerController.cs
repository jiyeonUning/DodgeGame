using UnityEngine;

// ������Ʈ : ���� ������Ʈ�� ����� ����ϴ� ��ǰ
public class PlayerController : MonoBehaviour
{
    // �ν����� â���� �����ϰų�, ���� ������ ����� �� �ִ� ���
    // ������� : ����(�ʵ�)
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;

    // ����Ƽ �޽��� �Լ����� ������ ���ҿ� �°� ä��������, ��ɿ� ���ؼ� �����Ѵ�.
    // ������� : ����
    private void Update()
    {
        Move();
    }

    // ====================================================================================

    // �����̴� ����� ���� Move �Լ�
    void Move()
    {
        // �Է� ���� �޾Ƽ�, �� ���� �����Ѵ�.
        // �Է� �Ŵ��� : Edit - ProjectSetting ���� ������ �̸��� �Է� ����� ����Ѵ�. (���� ����)
        // GetAxis() : �� �Է� -1 ~ 1 float �� / ���̽�ƽ ó�� ������ �̵��� �ν��� �� �ִ�.
        // GetAxisRaw() : �� �Է� -1, 0, +1 float �� / �Ҽ��� ���� �Է� ���θ� �Ǵ��ϱ� ������, Ű����ó�� �븣�� �ִ� ��쿡 �����ϴ�.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �ܼ� : ������ ������ �ؽ�Ʈ ���·� �Ͽ�, �����ڿ��� �˷��ִ� â.
        // Debug.Log($"{x}, {z}");

        // ����ȭ : ũ�Ⱑ 1�� �ƴ� ���͸� -> ũ�� 1�� ������ش�
        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.magnitude > 1) // magnitude = ������ ũ�⸦ ����
        { moveDir.Normalize(); }

        // ������ٵ� : ���� ���� ����� ������Ʈ.
        // AddForce, velocity, angularVelocity
        rigid.velocity = new Vector3(x * moveSpeed, 0, z * moveSpeed);
    }
}
