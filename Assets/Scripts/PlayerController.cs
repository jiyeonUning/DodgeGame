using UnityEngine;

// 컴포넌트 : 게임 오브젝트의 기능을 담당하는 부품
public class PlayerController : MonoBehaviour
{
    // 인스펙터 창에서 참조하거나, 값을 지정해 사용할 수 있는 경우
    // 멤버변수 : 정보(필드)
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;

    // 유니티 메시지 함수들을 각각의 역할에 맞게 채워넣으며, 기능에 대해서 구현한다.
    // 멤버변수 : 동작
    private void Update()
    {
        Move();
    }

    // ====================================================================================

    // 움직이는 기능을 가진 Move 함수
    void Move()
    {
        // 입력 값을 받아서, 그 값을 저장한다.
        // 입력 매니저 : Edit - ProjectSetting 에서 설정한 이름의 입력 방식을 사용한다. (변경 가능)
        // GetAxis() : 축 입력 -1 ~ 1 float 값 / 조이스틱 처럼 조금의 이동도 인식할 수 있다.
        // GetAxisRaw() : 축 입력 -1, 0, +1 float 값 / 소수점 없이 입력 여부를 판단하기 때문에, 키보드처럼 노르고 있는 경우에 적합하다.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 콘솔 : 게임의 정보를 텍스트 형태로 하여, 제작자에게 알려주는 창.
        // Debug.Log($"{x}, {z}");

        // 정규화 : 크기가 1이 아닌 벡터를 -> 크기 1로 만들어준다
        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.magnitude > 1) // magnitude = 벡터의 크기를 뜻함
        { moveDir.Normalize(); }

        // 리지드바디 : 물리 엔진 담당의 컴포넌트.
        // AddForce, velocity, angularVelocity
        rigid.velocity = new Vector3(x * moveSpeed, 0, z * moveSpeed);
    }
}
