using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 드래그 시작, 드래그 하는중, 드래그 끝 이벤트 탐지를 위한 인터페이스 상속
public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beginDraggedItem;  // 드래그 될때 이동되는 아이템

    Vector3 startPosition;                      // 처음 위치

    Transform onDragParent;                     // 아이템 드래그 중 변경할 부모의 rectTransform
    [HideInInspector]
    public Transform startParent;               // 초기 부모의 rectTransform



    public void OnBeginDrag(PointerEventData eventData)
    {
        // 시작 아이템
        beginDraggedItem = gameObject;

        // 백업용 위치 , 부모의 rectTransform
        startPosition = transform.position;
        startParent = transform.parent;

       // onDragParent = InventoryManager.instacne.transform;

        // drag이벤트를 정상적으로 감지하기 Click이벤트 막기
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        // 현재 클릭한 아이템의 부모 변경
        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중 아이템의 위치 수정
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beginDraggedItem = null;
        // 다시 ui 입력을 받아들임(click같은거)
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // 부모가 변경x -> 즉 다른 슬롯 위에 놓아진게 아님
        // 원래의 자리로 돌아갑니다
        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }


}
