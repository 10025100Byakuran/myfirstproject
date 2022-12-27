using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryObject; //���������
    public bool IsOpen = false; // ������ ��������� ��� ���

    public Slot[] slot; // ������ � ���������

    public Slot[] hotSlot;
    public Slot[] HeavySlot;
    public Slot[] LightSlot;
    public Slot[] SteelSlot;

    int k = 0;

    PointerEventData eventData;

    public GameObject Drag;

    GameObject norm;

    void Start()
    {
        inventoryObject = GameObject.Find("Inventory"); // ���� ���������
        inventoryObject.SetActive(false); // ������� ��������� ������

        for(int i = 0; i < slot.Length; i++)
        {
            slot[i].index = i;
            slot[i].number = i;

        }

        for(int i = 0; i < hotSlot.Length; i++)
        {
            hotSlot[i].index = i + slot.Length;
            hotSlot[i].number = i;
        }

        norm = GameObject.Find("norm");
             
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // ���� ������ ������ I
        {
            if (IsOpen) // ���� ��������� ������
            {
                inventoryObject.SetActive(false); // ��������� ���
                IsOpen = false;

                for (int i = 0; i < slot.Length; i++) // ���������� ���� ������� ���������� ����
                {            
                    if(slot[i].GetComponent<Image>().color != norm.GetComponent<Image>().color)
                    {
                        slot[i].GetComponent<Image>().color = norm.GetComponent<Image>().color;
                        break;
                    }                        
                }
                                
                Cursor.visible = false; // ������ ������ ���� �������
            }
            else //���� ��������� ������
            {
                inventoryObject.SetActive(true); // ��������� ���
                IsOpen = true;
                Cursor.visible = true; // ������ ������ ���� �������
                Cursor.lockState = CursorLockMode.None; // ����� ������ �������� �� ������
                Heavy();
                Light();
                Steel();
            }
        }
        
    }

    
    public void Heavy()
    {
        for(int i = 0; i < HeavySlot.Length; i++)
        {
            HeavySlot[i].item = null;
            HeavySlot[i].index = 0;
            HeavySlot[i].number = i;
            HeavySlot[i].IsEmpty = true;
            HeavySlot[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            HeavySlot[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        k = 0;
        for(int j = 0; j < HeavySlot.Length; j++)
        {
            for (int i = k; i < slot.Length; i++)
            {
                if(slot[i].IsEmpty == false)
                {
                    if (slot[i].item.item.IsHeavy)
                    {
                        HeavySlot[j].item = slot[i].item;
                        HeavySlot[j].index = slot[i].index;
                        HeavySlot[j].IsEmpty = false;
                        HeavySlot[j].transform.GetChild(0).GetComponent<Image>().sprite = slot[i].transform.GetChild(0).GetComponent<Image>().sprite;
                        HeavySlot[j].transform.GetChild(0).GetComponent<Image>().enabled = true;
                        k = i + 1;
                        break;
                    }
                }                
            }
            if (k == slot.Length)
            {
                break;
            }
        }        
    }

    public void Light()
    {
        for (int i = 0; i < LightSlot.Length; i++)
        {
            LightSlot[i].item = null;
            LightSlot[i].index = 0;
            LightSlot[i].number = i;
            LightSlot[i].IsEmpty = true;
            LightSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            LightSlot[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        k = 0;
        for (int j = 0; j < LightSlot.Length; j++)
        {
            for (int i = k; i < slot.Length; i++)
            {
                if (slot[i].IsEmpty == false)
                {
                    if (slot[i].item.item.IsLight)
                    {
                        LightSlot[j].item = slot[i].item;
                        LightSlot[j].index = slot[i].index;
                        LightSlot[j].IsEmpty = false;
                        LightSlot[j].transform.GetChild(0).GetComponent<Image>().sprite = slot[i].transform.GetChild(0).GetComponent<Image>().sprite;
                        LightSlot[j].transform.GetChild(0).GetComponent<Image>().enabled = true;
                        k = i + 1;
                        break;
                    }
                }
            }
            if (k == slot.Length)
            {
                break;
            }
        }
    }

    public void Steel()
    {
        for (int i = 0; i < SteelSlot.Length; i++)
        {
            SteelSlot[i].item = null;
            SteelSlot[i].index = 0;
            SteelSlot[i].number = i;
            SteelSlot[i].IsEmpty = true;
            SteelSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            SteelSlot[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        k = 0;
        for (int j = 0; j < SteelSlot.Length; j++)
        {
            for (int i = k; i < slot.Length; i++)
            {
                if (slot[i].IsEmpty == false)
                {
                    if (slot[i].item.item.IsSteel)
                    {
                        SteelSlot[j].item = slot[i].item;
                        SteelSlot[j].index = slot[i].index;
                        SteelSlot[j].IsEmpty = false;
                        SteelSlot[j].transform.GetChild(0).GetComponent<Image>().sprite = slot[i].transform.GetChild(0).GetComponent<Image>().sprite;
                        SteelSlot[j].transform.GetChild(0).GetComponent<Image>().enabled = true;
                        k = i + 1;
                        break;
                    }
                }
            }
            if (k == slot.Length)
            {
                break;
            }
        }
    }

}
