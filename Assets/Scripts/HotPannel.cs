using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HotPannel : MonoBehaviour, IPointerClickHandler
{
    int i; // ����� ����� �� ������ �������� �������
    Inventory inv;
    bool f = false; // ������, ��� ������ �����
    bool f1 = true; // ������, ��� ������ ���
    GameObject newParent, oldParent; // ������������ ������ �������� ������ � ������� �������� ������, ������� ����� �����
    GameObject Unarmed; // ��� ������ (������� ����� ��� ������)

    public GameObject Back;
    public Butt bAck;

    public GameObject Use;

    public int j;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Unarmed = GameObject.FindGameObjectWithTag("unarmed");

        Back = GameObject.Find("Back");
        bAck = GameObject.Find("Back").GetComponent<Butt>();

        Use = GameObject.Find("Use");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� ������ ������ 1
        {
            i = 0; // ������, ��� ���� ������
            Equip(); // �������� ������ �� ������� �����
        } 

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            i = 1;
            Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            i = 2;
            Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            i = 3;
            Equip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            i = 4;
            Equip();
        }

    }

    public void Equip()
    {
        for (int k = 0; k < inv.hotSlot.Length; k++) // �������� �� ���� ������
        {
            if(k == i) // ���� ����� ����� ��������� � ������� ����� �� ������� ������
            {                
                if (inv.hotSlot[k].item == null) // ���� � ����� ��� ������
                {
                    if (f) // � ���� ������ ���� ������ ������
                    {
                        oldParent.SetActive(false); // ������� ������ ������
                    }
                    Unarmed.SetActive(true); // ������ ����� ����������
                    f1 = true; // ��������� ������, ��� ������ ���
                    break;
                }
                else // �����, ���� � ����� ���� ������
                {
                    newParent = inv.hotSlot[k].item.transform.parent.gameObject; // �������� ������������ ������, ������� ����� ������
                    if (f) // � ���� ������ ���� ������ ������
                    {
                        oldParent.SetActive(false); // ������� ������ ������
                    }

                    if (f1) // ���� ��� �� ����� ���������
                    {
                        Unarmed.SetActive(false); 
                        f1 = false; // ������� ������, ��� ������ ���
                    }

                    newParent.SetActive(true); // �������� ����� ������
                    oldParent = newParent; // ���������, ����� ����� �����
                    f = true;
                }
                break;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) // ���� �� ������
    {
        j = eventData.pointerPress.GetComponent<Slot>().index;
        j -= inv.slot.Length;

        if (inv.hotSlot[j].IsEmpty == false) // ���� ������ �� ������
        {           
            bAck.item = inv.hotSlot[j].item;
            bAck.index = inv.hotSlot[j].index;
            Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            Back.GetComponent<Image>().enabled = true;
        }
        else // ������ ������, ��� ��������
        {           
            Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            Back.GetComponent<Image>().enabled = false;
        }

        Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        Use.GetComponent<Image>().enabled = false;
    }

}
