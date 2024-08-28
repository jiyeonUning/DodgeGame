using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {
        // LookAt : Ÿ�� ������ �ٶ󺸰Բ� ȸ�������� �� �ִ�.
        transform.LookAt(target.position);
        // �Ѿ��� �ӵ� = �չ��� X ȸ���ӵ� ���� �������ش�.
        rigid.velocity = transform.forward * speed;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    // ===========================================================

    // < ����Ƽ �浹 �޽��� �Լ� >
    // �浹 (Collision) : ������ �浹�� Ȯ���Ѵ�.
    // Ʈ���� (Trigger) : ��ħ ���θ� Ȯ���Ѵ�.
    private void OnCollisionEnter(Collision collision)
    {
        // Collision �Ű����� : �浹�� ��Ȳ�� ���� �������� ������ �ִ�.
        // ex) �浹�� �ٸ� �浹ü, �̷� ���� ���� ��, �Σ��� ���� ��...

        // �Ѿ��� �÷��̾ �΋H���� ��,
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.TakeHit();
        }

            // Destroy : ���� ������Ʈ�� �����ϴ� �Լ�.
            Destroy(gameObject);
    }


}
