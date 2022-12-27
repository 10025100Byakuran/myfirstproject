using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Use : MonoBehaviour, IPointerClickHandler
{
    Inventory inv;
    public Butt uSe;
    int j;
    public GameObject UseButt;

    void Start()
    {
        UseButt = GameObject.Find("Use");
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        uSe = GameObject.Find("Use").GetComponent<Butt>();
    }

    public void OnPointerClick(PointerEventData eventData) // Если нажата кнопка "Use"
    {
        for(int i = 0; i < inv.hotSlot.Length; i++) // проходим по слотам панели быстрого доступа
        {
            if (inv.hotSlot[i].IsEmpty) // в пустой слот передаем оружие из инвентаря
            {
                inv.hotSlot[i].item = uSe.item;
                inv.hotSlot[i].IsEmpty = false;
                inv.hotSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = uSe.item.item.ItemSprite;
                inv.hotSlot[i].transform.GetChild(0).GetComponent<Image>().enabled = true;

                j = uSe.index; // запоминаем из какого слота взяли оружие

                
                for(int k = j; k < inv.slot.Length; k++) // проходим по слотам инвентаря и перекидываем предмет из следующего слота (чтоб не было пустой ячейки среди заполненых)
                {
                    if (k == inv.slot.Length)
                    {
                        inv.slot[k].item = null;
                        inv.slot[k].transform.GetChild(0).GetComponent<Image>().sprite = null;
                        inv.slot[k].transform.GetChild(0).GetComponent<Image>().enabled = false;
                        inv.slot[k].IsEmpty = true;
                    }
                    else
                    {
                        inv.slot[k].item = inv.slot[k + 1].item;
                        inv.slot[k].transform.GetChild(0).GetComponent<Image>().sprite = inv.slot[k + 1].transform.GetChild(0).GetComponent<Image>().sprite;
                        inv.slot[k].transform.GetChild(0).GetComponent<Image>().enabled = inv.slot[k + 1].transform.GetChild(0).GetComponent<Image>().enabled;
                        inv.slot[k].IsEmpty = inv.slot[k + 1].IsEmpty;

                        if (inv.slot[k + 1].IsEmpty)
                        {
                            break;
                        }
                    }                    
                }

                // обновляем остальные вкладки
                inv.Heavy();
                inv.Light();
                inv.Steel();               

                uSe.item = null;
                uSe.index = 0;

                UseButt.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                UseButt.GetComponent<Image>().enabled = false;

                break;
            }
        }
    }
}
