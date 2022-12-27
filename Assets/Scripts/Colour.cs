using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Это нужно, чтобы кнопки меняли цвет при нажатии (чтоб было видно в какой вкладке инвентаря сейчас игрок)
public class Colour : MonoBehaviour, IPointerClickHandler
{
    public GameObject inv;
    public GameObject pressed;
    public GameObject[] unpressed;
    public GameObject buttonsColor;
    void Start()
    {
        inv = GameObject.Find("Inventory"); // если на кнопку нажали, она будет такого же цвета как и инвентарь
        buttonsColor = GameObject.Find("buttonsColor");
    }


    public void OnPointerClick(PointerEventData eventData) // клик на кнопку
    {
        pressed.GetComponent<Image>().color = inv.GetComponent<Image>().color;

        for(int i = 0; i < unpressed.Length; i++)
        {
            unpressed[i].GetComponent<Image>().color = buttonsColor.GetComponent<Image>().color;
        }
    }
}
