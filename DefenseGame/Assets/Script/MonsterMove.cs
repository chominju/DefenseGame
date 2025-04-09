using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterMove : MonoBehaviour
{
    public Tilemap tilemap;
    public float moveSpeed = 2f;
    public Vector2 moveDirection = Vector2.up;

    void Update()
    {
        // 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


        Vector3Int cellPos = tilemap.WorldToCell(transform.position);
        Vector3 tileCenter = tilemap.GetCellCenterWorld(cellPos);

        // 중심점에 거의 도달했을 때만 방향 전환
        if (Vector3.Distance(transform.position, tileCenter) < 0.02f)
        {

            TileBase tile = tilemap.GetTile(cellPos);

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
            }
        }
            // 만약 TurnTile이라면 방향 바꾸기
            //if (tile is TurnTile turnTile)
            //{
            //    switch (turnTile.turnTo)
            //    {
            //        case TurnTile.TurnDirection.Left:
            //            moveDirection = Vector2.left;
            //            transform.rotation = Quaternion.Euler(0, 0, 180);
            //            break;
            //        case TurnTile.TurnDirection.Right:
            //            moveDirection = Vector2.right;
            //            transform.rotation = Quaternion.Euler(0, 0, 0);
            //            break;
            //        case TurnTile.TurnDirection.Up:
            //            moveDirection = Vector2.up;
            //            transform.rotation = Quaternion.Euler(0, 0, 90);
            //            break;
            //        case TurnTile.TurnDirection.Down:
            //            moveDirection = Vector2.down;
            //            transform.rotation = Quaternion.Euler(0, 0, -90);
            //            break;
            //    }
            //}
        }
}
