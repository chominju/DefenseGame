using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DraggableUnit : MonoBehaviour
{
    public Tilemap installableTilemap; // 설치 가능한 영역 타일맵
    private bool isDragging = false;
    private Camera cam;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        isDragging = true;
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        if (isDragging)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorld.x, mouseWorld.y, 0) + offset;
        }
    }

    void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        isDragging = false;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = installableTilemap.WorldToCell(mouseWorld);

        // 설치 가능한 영역에만 스냅

        TileBase tile = installableTilemap.GetTile(cellPos);

        if(tile is PlayerTile playerTile)
        {
            transform.position = installableTilemap.GetCellCenterWorld(cellPos);
        }
        //if (installableTilemap.HasTile(cellPos))
        //{
        //    if()
        //    transform.position = installableTilemap.GetCellCenterWorld(cellPos);
        //}
        else
        {
            Debug.Log("설치 불가능한 위치입니다");
        }
    }
}
