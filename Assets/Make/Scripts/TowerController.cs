using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        // GameObject.FindGamePbjectWithTag : 게임에 있는 태그를 통하여, 특정 게임오브젝트를 찾을 수 있다.
        GameObject playerOBJ = GameObject.FindGameObjectWithTag("Player");

        // GetCommponent : 해당하는 게임오브젝트에 있는 컴포넌트를 가져온다.
        target = playerOBJ.GetComponent<Transform>();

        // transform : 게임오브젝트의 위치, 회전, 크기를 관리하는 기능 담당자.
        //   transform 컴포넌트는 모든 게임오브젝트에 반드시 존재한다.
        // = transform 컴포넌트만 특별하게 transform 프로퍼티로 바로 사용이 가능하다.
        target = playerOBJ.transform;
    }

    // =======================================================================================================


    [SerializeField] float bulletTime; // 총알을 생성한 시간 (총알 생성 주기)
    [SerializeField] float remainTime; // 다음 총알을 쏠 때 까지 기다린 시간
    [SerializeField] GameObject bulletPrefab; // 생성할 총알의 원본, 프리팹

    private void Update()
    {
        // 다음 총알의 생성까지 남은 시간을 계속 차감한다.
        remainTime -= Time.deltaTime;

        // 총알을 발사할 시점을 정하는 if문
        // 다음 총알을 생성할 때 까지, 남은 시간이 없는 경우 = 총알을 생성할 타이밍
        if (remainTime <= 0)
        {
            // bulletPrefab 설계도를 토대로 하여, 총알을 생성한다.
            // Instantiate : 프리팹을 토대로 게임 오브젝트를 생성한다.
            // Instantiate(프리팹, 위치, 회전);
            GameObject bulletGameOBJ = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bullet = bulletGameOBJ.GetComponent<Bullet>();
            bullet.SetTarget(target);

            // 다음 총알을 생성할 때 까지, 남은 시간을 다시 설정한다.
            remainTime = bulletTime;
        }
    }
}
