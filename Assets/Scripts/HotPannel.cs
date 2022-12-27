using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HotPannel : MonoBehaviour, IPointerClickHandler
{
    int i; // номер слота на панели быстрого доступа
    Inventory inv;
    bool f = false; // флажок, что оружие взято
    bool f1 = true; // флажок, что оружия нет
    GameObject newParent, oldParent; // расположения нового надетого оружия и старого надетого оружия, которое нужно снять
    GameObject Unarmed; // нет оружия (сначала игрок без оружия)

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
        if (Input.GetKeyDown(KeyCode.Alpha1)) // если нажата кнопка 1
        {
            i = 0; // значит, что слот первый
            Equip(); // надеваем оружие из первого слота
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
        for (int k = 0; k < inv.hotSlot.Length; k++) // проходим по всем слотам
        {
            if(k == i) // если номер слота совпадает с номером слота на который нажали
            {                
                if (inv.hotSlot[k].item == null) // если в слоте нет оружия
                {
                    if (f) // и если оружие было надето раньше
                    {
                        oldParent.SetActive(false); // снимаем старое оружие
                    }
                    Unarmed.SetActive(true); // теперь игрок безоружный
                    f1 = true; // поднимаем флажок, что оружия нет
                    break;
                }
                else // иначе, если в слоте есть оружие
                {
                    newParent = inv.hotSlot[k].item.transform.parent.gameObject; // получаем расположение оружея, которое нужно надеть
                    if (f) // и если оружие было надето раньше
                    {
                        oldParent.SetActive(false); // снимаем старое оружие
                    }

                    if (f1) // если был до этого безоружен
                    {
                        Unarmed.SetActive(false); 
                        f1 = false; // снимаем флажок, что оружия нет
                    }

                    newParent.SetActive(true); // надеваем новое оружие
                    oldParent = newParent; // сохраняем, чтобы потом снять
                    f = true;
                }
                break;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) // клик на ячейку
    {
        j = eventData.pointerPress.GetComponent<Slot>().index;
        j -= inv.slot.Length;

        if (inv.hotSlot[j].IsEmpty == false) // если ячейка не пустая
        {           
            bAck.item = inv.hotSlot[j].item;
            bAck.index = inv.hotSlot[j].index;
            Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
            Back.GetComponent<Image>().enabled = true;
        }
        else // ячейка пустая, все обнуляем
        {           
            Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            Back.GetComponent<Image>().enabled = false;
        }

        Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        Use.GetComponent<Image>().enabled = false;
    }

}
