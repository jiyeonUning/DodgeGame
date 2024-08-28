using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        // GameObject.FindGamePbjectWithTag : ���ӿ� �ִ� �±׸� ���Ͽ�, Ư�� ���ӿ�����Ʈ�� ã�� �� �ִ�.
        GameObject playerOBJ = GameObject.FindGameObjectWithTag("Player");

        // GetCommponent : �ش��ϴ� ���ӿ�����Ʈ�� �ִ� ������Ʈ�� �����´�.
        target = playerOBJ.GetComponent<Transform>();

        // transform : ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ��� �����.
        //   transform ������Ʈ�� ��� ���ӿ�����Ʈ�� �ݵ�� �����Ѵ�.
        // = transform ������Ʈ�� Ư���ϰ� transform ������Ƽ�� �ٷ� ����� �����ϴ�.
        target = playerOBJ.transform;
    }

    // =======================================================================================================


    [SerializeField] float bulletTime; // �Ѿ��� ������ �ð� (�Ѿ� ���� �ֱ�)
    [SerializeField] float remainTime; // ���� �Ѿ��� �� �� ���� ��ٸ� �ð�
    [SerializeField] GameObject bulletPrefab; // ������ �Ѿ��� ����, ������

    private void Update()
    {
        // ���� �Ѿ��� �������� ���� �ð��� ��� �����Ѵ�.
        remainTime -= Time.deltaTime;

        // �Ѿ��� �߻��� ������ ���ϴ� if��
        // ���� �Ѿ��� ������ �� ����, ���� �ð��� ���� ��� = �Ѿ��� ������ Ÿ�̹�
        if (remainTime <= 0)
        {
            // bulletPrefab ���赵�� ���� �Ͽ�, �Ѿ��� �����Ѵ�.
            // Instantiate : �������� ���� ���� ������Ʈ�� �����Ѵ�.
            // Instantiate(������, ��ġ, ȸ��);
            GameObject bulletGameOBJ = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bullet = bulletGameOBJ.GetComponent<Bullet>();
            bullet.SetTarget(target);

            // ���� �Ѿ��� ������ �� ����, ���� �ð��� �ٽ� �����Ѵ�.
            remainTime = bulletTime;
        }
    }
}
