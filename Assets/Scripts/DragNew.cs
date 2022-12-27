using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Ётот скрипт будет только на панели быстрого доступа, а другой скрипт Drag будет везде выключен 
// зачем в самом инвентаре переносить предметы?

public class DragNew : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Item drag; // предмет, который переносим
    Inventory inv; // инвентарь
    int i, j; // номера €чеек из которой переносим и в которую переносим
    Slot newO, newS, oldS; // сама €чейка, в которую переносим
    Image newI, oldI; // иконки, предметов в €чейках
    public GameObject ne; // кака€ €чейка под курсором


    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData) // когда начинаем переносить
    {
        i = eventData.pointerPress.GetComponent<Slot>().index; // номер €чейки, из которой переносим
               
        drag = inv.hotSlot[i - inv.slot.Length].item;
        oldS = inv.hotSlot[i - inv.slot.Length];
        
        inv.Drag.SetActive(true); // чтоб было видно как предмет перетаскиваетс€
        inv.Drag.GetComponent<CanvasGroup>().blocksRaycasts = false; // чтоб видеть куда переносим

        if (drag)
        {
            inv.Drag.GetComponent<Image>().sprite = drag.item.ItemSprite; // чтоб видеть что переносим
        }
        else // если в €чейке, из которой переносим нет предмета, то ничего переноситьс€ не будет
        {
            drag = null;
            inv.Drag.SetActive(false);
        }

        // когда предмет перетаскиваетс€, кнопки не будут видны
        inv.hotSlot[i - inv.slot.Length].OnPointerClick(eventData);
        inv.hotSlot[i - inv.slot.Length].Use.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Use.GetComponent<Image>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Back.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        inv.hotSlot[i - inv.slot.Length].Back.GetComponent<Image>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData) // в момент переноса
    {
        inv.Drag.transform.position = Input.mousePosition; // предмет будет следовать за курсором
    }

    public void OnEndDrag(PointerEventData eventData) // когда закончили переносить
    {
        ne = eventData.pointerCurrentRaycast.gameObject; // смотрим объект, который находитс€ под курсором 

        if (ne == null) // если этот объект - не объект, обнул€ем
        {
            inv.Drag.GetComponent<Image>().sprite = null;
            inv.Drag.SetActive(false);
        }
        else
        {
            if (ne.GetComponent<Slot>() || ne.transform.parent.GetComponent<Slot>()) // если этот объект - слот 
            {
                if (ne.transform.parent.GetComponent<Slot>())
                {
                    newO = ne.transform.parent.GetComponent<Slot>();
                }
                else
                {
                    newO = ne.GetComponent<Slot>();
                }

                j = newO.index; // запоминаем индес €чейки

                if(j >= 25)
                {
                    newS = inv.hotSlot[j - inv.slot.Length];

                    newI = newS.transform.GetChild(0).GetComponent<Image>(); // это, чтоб запись короче была, когда мен€ем местами иконки
                    oldI = oldS.transform.GetChild(0).GetComponent<Image>();


                    (oldS.item, newS.item) = (newS.item, oldS.item); // мен€ем местами предметы в €чейках
                    (oldI.sprite, newI.sprite) = (newI.sprite, oldI.sprite); // мен€ем иконки в €чейках

                    // дальше включаем видимость иконки, если €чейка непуста€, и выключаем - если пуста€
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

        // все перенеслось, все обнул€ем
        drag = null;
        inv.Drag.GetComponent<Image>().sprite = null;
        inv.Drag.SetActive(false);
        inv.Drag.GetComponent<CanvasGroup>().blocksRaycasts = true;

        // обновл€ем остальные вкладки
        inv.Heavy();
        inv.Light();
        inv.Steel();
    }
   
}
