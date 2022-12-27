using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// ��� �����, ����� ������ ������ ���� ��� ������� (���� ���� ����� � ����� ������� ��������� ������ �����)
public class Colour : MonoBehaviour, IPointerClickHandler
{
    public GameObject inv;
    public GameObject pressed;
    public GameObject[] unpressed;
    public GameObject buttonsColor;
    void Start()
    {
        inv = GameObject.Find("Inventory"); // ���� �� ������ ������, ��� ����� ������ �� ����� ��� � ���������
        buttonsColor = GameObject.Find("buttonsColor");
    }


    public void OnPointerClick(PointerEventData eventData) // ���� �� ������
    {
        pressed.GetComponent<Image>().color = inv.GetComponent<Image>().color;

        for(int i = 0; i < unpressed.Length; i++)
        {
            unpressed[i].GetComponent<Image>().color = buttonsColor.GetComponent<Image>().color;
        }
    }
}
