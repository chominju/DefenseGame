using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Enemy : MonoBehaviour
{
    public Tilemap tilemap;                             // 맵 타일
    enum PlayerNumber { PLAYER1, PLAYER2 };             // 어떤 플레이어쪽에서 나온 몹인지 구분
    public float moveSpeed = 2f;


    public Vector2 moveDirection = Vector2.up;          // 몬스터의 방향
    public float turnTimer = 0.5f;                      // 연속 회전 방지 타이머
    float currentTurnTimer = 0.0f;               // 연속 회전 방지 현재 타이머
    bool isTurn = true;                                 // 회전을 했는지

    bool isSpawned = true;                              // 지금 소환됐는지
    float spawnTimer = 0.5f;




    private void Start()
    {
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
    }
    void Update()
    {
        // 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0.0f)
            isSpawned = false;

        if (isSpawned == false)
            Turn();
          

    }

    private void Turn()
    {
        Vector3Int cellPos = tilemap.WorldToCell(transform.position);
        Vector3 tileCenter = tilemap.GetCellCenterWorld(cellPos);

        // 중심점에 거의 도달했을 때만 방향 전환
        if (Vector3.Distance(transform.position, tileCenter) < 0.04f)
        {
            TileBase tile = tilemap.GetTile(cellPos);

            if (isTurn)
            {
                if (tile is TurnTile turnTile)
                {
                    if (moveDirection == Vector2.up)
                    {
                        moveDirection = Vector2.right;
                    }
                    else if (moveDirection == Vector2.right)
                    {
                        moveDirection = Vector2.down;
                    }
                    else if (moveDirection == Vector2.down)
                    {
                        moveDirection = Vector2.left;
                    }
                    else if (moveDirection == Vector2.left)
                    {
                        moveDirection = Vector2.up;
                    }

                    isTurn = false;
                }
            }
        }

        if (!isTurn)
        {
            currentTurnTimer += Time.deltaTime;
            if (currentTurnTimer >= turnTimer)
            {
                currentTurnTimer = 0.0f;
                isTurn = true;
            }

        }
    }
}

