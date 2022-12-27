using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Back : MonoBehaviour, IPointerClickHandler
{
    Inventory inv;
    public Butt bAck;
    public int j;
    public GameObject BackButt;

    void Start()
    {
        BackButt = GameObject.Find("Back");
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        bAck = GameObject.Find("Back").GetComponent<Butt>();
    }

    public void OnPointerClick(PointerEventData eventData) // ≈сли нажата кнопка "Back"
    {
        for (int i = 0; i < inv.slot.Length; i++) // проходим по слотам инвентар€
        {
            if (inv.slot[i].IsEmpty) // в пустой слот передаем оружие из панели быстрого доступа
            {
                inv.slot[i].item = bAck.item;
                inv.slot[i].IsEmpty = false;
                inv.slot[i].transform.GetChild(0).GetComponent<Image>().sprite = bAck.item.item.ItemSprite;
                inv.slot[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                           
                // обновл€ем остальные вкладки
                inv.Heavy();
                inv.Light();
                inv.Steel();

                bAck.item = null;                

                BackButt.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                BackButt.GetComponent<Image>().enabled = false;

                break;
            }
        }

        j = bAck.index - inv.slot.Length;
        inv.hotSlot[j].item = null;
        inv.hotSlot[j].IsEmpty = true;
        inv.hotSlot[j].transform.GetChild(0).GetComponent<Image>().sprite = null;
        inv.hotSlot[j].transform.GetChild(0).GetComponent<Image>().enabled = false;

    }
}
