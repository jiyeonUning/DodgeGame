using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver }

    [SerializeField] GameState curState;
    [SerializeField] TowerController[] towers;
    [SerializeField] PlayerController player;

    private void Start()
    {
        curState = GameState.Ready;

        // FindObjectsOfType = 게임씬에 있는 모든 컴포넌트를 찾는다.
        // 단, 시간이 오래걸리는 함수이기 때문에, 로딩 과정에서 사용하는 것을 권장한다.
        towers = FindObjectsOfType<TowerController>();

        // FindObjectsOfType = 게임씬에 있는 특정 컴포넌트를 찾는다.
        // 단, 시간이 오래걸리는 함수이기 때문에, 로딩 과정에서 사용하는 것을 권장한다.
        player = FindObjectOfType<PlayerController>();
        player.OnDied += GameOver;
    }

    private void Update()
    {
        // 아무키나 누를 때, 게임 시작 (타워들 움직임)
        if (curState == GameState.Ready && Input.anyKeyDown)
        { GameStart(); }    
    }

    void GameStart()
    {
        curState = GameState.Running;
        // 모든 타워 공격 개시
        foreach (TowerController tower in towers)
        { tower.StartAttack(); }
    }

    void GameOver()
    {
        curState |= GameState.GameOver;
        // 모든 타워 공격 중지
        foreach (TowerController tower in towers)
        { tower.StopAttack(); }
    }
}
