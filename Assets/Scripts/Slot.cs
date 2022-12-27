using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public Item item; // ������� � ������
	public bool IsEmpty = true; // ������ ������ ��� ���
    public int index;
    public int number;

    Image Selected; // ��������� ������
    GameObject lIght, nOrm; // ������� ������ � ������� ������


    public GameObject ItemImage; // ���� �� ������� �������� ������������ �������� ������
    public GameObject info; // ���������� �� ������
    
    public GameObject Use; // ������, ������� ����� ����������, ����� ������ ������ � ������ �������� �������
    public Butt uSe; // ����� ������� ������, ������� ����� ������������ � ������ �������� �������, � ����� �����, �� �������� ��� ����������� (�����, ���� ��� ������ ��������� � �� ��������� �������) 

    public GameObject Back;

    void Start()
    {
        Selected = GetComponent<Image>();

        ItemImage = GameObject.Find("Image");
        info = GameObject.Find("Info");

        Use = GameObject.Find("Use");
        uSe = GameObject.Find("Use").GetComponent<Butt>();

        Back = GameObject.Find("Back");

        lIght = GameObject.Find("light");
        nOrm = GameObject.Find("norm");
    }


    public void OnPointerEnter(PointerEventData eventData) // ���� ������ �� ������, ������������ ��
    {
        Selected.color = lIght.GetComponent<Image>().color;
    }

    public void OnPointerExit(PointerEventData eventData) // ���� ������ ������ �� ������, ���������� ����
    {
        Selected.color = nOrm.GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData) // ���� �� ������
    {
        if(IsEmpty == false) // ���� ������ �� ������
        {
            ItemImage.transform.GetChild(0).GetComponent<Image>().sprite = item.item.ItemSprite; // ������� �� ������� ������ �������� ������
            ItemImage.transform.GetChild(0).GetComponent<Image>().enabled = true; // ������� �������� ���������, ������ ��������

            info.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Name; // ������� ��� ������
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Damage.ToString(); // ������� ����
            info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Shell.ToString(); // ������� ����������� ������
            info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            if (item.item.IsSteel == true) // ���� ������ - ������
            {
                info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Speed; // ������� �������� ������ (������, �������)
            }
            else // ���� ������ - ���������
            {
                info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.FireRate.ToString(); // ������� �������� ��������
            }
           
            info.transform.GetChild(3).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;


            uSe.item = item;
            uSe.index = index;
            Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            Use.GetComponent<Image>().enabled = true;
        }
        else // ������ ������, ��� ��������
        {
            //ItemImage.transform.GetChild(0).GetComponent<Image>().sprite = null;
            ItemImage.transform.GetChild(0).GetComponent<Image>().enabled = false;

            for (int i = 0; i < 4; i++)
            {
                info.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = null;
                info.transform.GetChild(i).GetComponent<TextMeshProUGUI>().enabled = false;
                info.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }

            Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            Use.GetComponent<Image>().enabled = false;
                                 
        }

        if (index < 25)
        {
            Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            Back.GetComponent<Image>().enabled = false;
        }
    }
     
}
