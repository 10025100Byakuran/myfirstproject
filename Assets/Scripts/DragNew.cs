using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// ���� ������ ����� ������ �� ������ �������� �������, � ������ ������ Drag ����� ����� �������� 
// ����� � ����� ��������� ���������� ��������?

public class DragNew : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Item drag; // �������, ������� ���������
    Inventory inv; // ���������
    int i, j; // ������ ����� �� ������� ��������� � � ������� ���������
    Slot newO, newS, oldS; // ���� ������, � ������� ���������
    Image newI, oldI; // ������, ��������� � �������
    public GameObject ne; // ����� ������ ��� ��������


    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData) // ����� �������� ����������
    {
        i = eventData.pointerPress.GetComponent<Slot>().index; // ����� ������, �� ������� ���������
               
        drag = inv.hotSlot[i - inv.slot.Length].item;
        oldS = inv.hotSlot[i - inv.slot.Length];
        
        inv.Drag.SetActive(true); // ���� ���� ����� ��� ������� ���������������
        inv.Drag.GetComponent<CanvasGroup>().blocksRaycasts = false; // ���� ������ ���� ���������

        if (drag)
        {
            inv.Drag.GetComponent<Image>().sprite = drag.item.ItemSprite; // ���� ������ ��� ���������
        }
        else // ���� � ������, �� ������� ��������� ��� ��������, �� ������ ������������ �� �����
        {
            drag = null;
            inv.Drag.SetActive(false);
        }

        // ����� ������� ���������������, ������ �� ����� �����
        inv.hotSlot[i - inv.slot.Length].OnPointerClick(eventData);
        inv.hotSlot[i - inv.slot.Length].Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Use.GetComponent<Image>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Back.GetComponent<Image>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData) // � ������ ��������
    {
        inv.Drag.transform.position = Input.mousePosition; // ������� ����� ��������� �� ��������
    }

    public void OnEndDrag(PointerEventData eventData) // ����� ��������� ����������
    {
        ne = eventData.pointerCurrentRaycast.gameObject; // ������� ������, ������� ��������� ��� �������� 

        if (ne == null) // ���� ���� ������ - �� ������, ��������
        {
            inv.Drag.GetComponent<Image>().sprite = null;
            inv.Drag.SetActive(false);
        }
        else
        {
            if (ne.GetComponent<Slot>() || ne.transform.parent.GetComponent<Slot>()) // ���� ���� ������ - ���� 
            {
                if (ne.transform.parent.GetComponent<Slot>())
                {
                    newO = ne.transform.parent.GetComponent<Slot>();
                }
                else
                {
                    newO = ne.GetComponent<Slot>();
                }

                j = newO.index; // ���������� ����� ������

                if(j >= 25)
                {
                    newS = inv.hotSlot[j - inv.slot.Length];

                    newI = newS.transform.GetChild(0).GetComponent<Image>(); // ���, ���� ������ ������ ����, ����� ������ ������� ������
                    oldI = oldS.transform.GetChild(0).GetComponent<Image>();


                    (oldS.item, newS.item) = (newS.item, oldS.item); // ������ ������� �������� � �������
                    (oldI.sprite, newI.sprite) = (newI.sprite, oldI.sprite); // ������ ������ � �������

                    // ������ �������� ��������� ������, ���� ������ ��������, � ��������� - ���� ������
                    if (newS.item)
                    {
                        newS.IsEmpty = false;
                        newI.enabled = true;
                    }
                    else
                    {
                        newS.IsEmpty = true;
                        newI.enabled = false;
                    }

                    if (oldS.item)
                    {
                        oldS.IsEmpty = false;
                        oldI.enabled = true;
                    }
                    else
                    {
                        oldS.IsEmpty = true;
                        oldI.enabled = false;
                    }
                }                                                     

            }
        }

        // ��� �����������, ��� ��������
        drag = null;
        inv.Drag.GetComponent<Image>().sprite = null;
        inv.Drag.SetActive(false);
        inv.Drag.GetComponent<CanvasGroup>().blocksRaycasts = true;

        // ��������� ��������� �������
        inv.Heavy();
        inv.Light();
        inv.Steel();
    }
   
}
