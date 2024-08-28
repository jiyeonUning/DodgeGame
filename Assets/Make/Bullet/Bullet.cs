using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {
        // LookAt : 타겟 방향을 바라보게끔 회전시켜줄 수 있다.
        transform.LookAt(target.position);
        // 총알의 속도 = 앞방향 X 회전속도 으로 설정해준다.
        rigid.velocity = transform.forward * speed;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    // ===========================================================

    // < 유니티 충돌 메시지 함수 >
    // 충돌 (Collision) : 물리적 충돌을 확인한다.
    // 트리거 (Trigger) : 겹침 여부를 확인한다.
    private void OnCollisionEnter(Collision collision)
    {
        // Collision 매개변수 : 충돌한 상황에 대한 정보들을 가지고 있다.
        // ex) 충돌한 다른 충돌체, 이로 인해 받은 힘, 부짗힌 지점 등...

        // 총알이 플레이어에 부딫혔을 때,
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeHit();
        }

            // Destroy : 게임 오브젝트를 삭제하는 함수.
            Destroy(gameObject);
    }


}
