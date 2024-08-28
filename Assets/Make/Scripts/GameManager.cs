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

        // FindObjectsOfType = ���Ӿ��� �ִ� ��� ������Ʈ�� ã�´�.
        // ��, �ð��� �����ɸ��� �Լ��̱� ������, �ε� �������� ����ϴ� ���� �����Ѵ�.
        towers = FindObjectsOfType<TowerController>();

        // FindObjectsOfType = ���Ӿ��� �ִ� Ư�� ������Ʈ�� ã�´�.
        // ��, �ð��� �����ɸ��� �Լ��̱� ������, �ε� �������� ����ϴ� ���� �����Ѵ�.
        player = FindObjectOfType<PlayerController>();
        player.OnDied += GameOver;
    }

    private void Update()
    {
        // �ƹ�Ű�� ���� ��, ���� ���� (Ÿ���� ������)
        if (curState == GameState.Ready && Input.anyKeyDown)
        { GameStart(); }    
    }

    void GameStart()
    {
        curState = GameState.Running;
        // ��� Ÿ�� ���� ����
        foreach (TowerController tower in towers)
        { tower.StartAttack(); }
    }

    void GameOver()
    {
        curState |= GameState.GameOver;
        // ��� Ÿ�� ���� ����
        foreach (TowerController tower in towers)
        { tower.StopAttack(); }
    }
}
