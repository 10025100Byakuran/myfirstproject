using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public Item item; // предмет в €чейке
	public bool IsEmpty = true; // пуста€ €чейка или нет
    public int index;
    public int number;

    Image Selected; // ¬ыбранна€ €чейка
    GameObject lIght, nOrm; // светла€ €чейка и обычна€ €чейка


    public GameObject ItemImage; // чтоб на большой панельке показывалась картинка оружи€
    public GameObject info; // »нформаци€ об оружии
    
    public GameObject Use; // кнопка, котора€ будет по€вл€тьс€, чтобы добать оружие в панель быстрого доступа
    public Butt uSe; // будет хранить оружие, которое будет переноситьс€ в панель быстрого доступа, и номер слота, из которого оно добавл€етс€ (нужно, чтоб это оружие убиралось и из остальных вкладок) 

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


    public void OnPointerEnter(PointerEventData eventData) // если курсор на €чейке, подсвечиваем ее
    {
        Selected.color = lIght.GetComponent<Image>().color;
    }

    public void OnPointerExit(PointerEventData eventData) // если курсор отошел от €чейки, возвращаем цвет
    {
        Selected.color = nOrm.GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData) // клик на €чейку
    {
        if(IsEmpty == false) // если €чейка не пуста€
        {
            ItemImage.transform.GetChild(0).GetComponent<Image>().sprite = item.item.ItemSprite; // выводим на большую панель картинку оружи€
            ItemImage.transform.GetChild(0).GetComponent<Image>().enabled = true; // сначала картинка отключена, теперь включена

            info.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Name; // выводим им€ оружи€
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Damage.ToString(); // выводим урон
            info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Shell.ToString(); // выводим вмещаемость патрон
            info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            if (item.item.IsSteel == true) // если оружие - клинок
            {
                info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Speed; // выводим скоромть клинка (быстро, медлено)
            }
            else // если оружие - огнестрел
            {
                info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.FireRate.ToString(); // выводим скорость стрельбы
            }
           
            info.transform.GetChild(3).GetComponent<TextMeshProUGUI>().enabled = true;
            info.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;


            uSe.item = item;
            uSe.index = index;
            Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            Use.GetComponent<Image>().enabled = true;
        }
        else // €чейка пуста€, все обнул€ем
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
