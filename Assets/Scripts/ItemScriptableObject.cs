using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Item")] // создаем предмет в папке Inventory

public class ItemScriptableObject : ScriptableObject
{
    public string Name;           // Имя
    public float Damage;          // Урон
    public float Shell;           // Кол-во патрон
    public float FireRate;        // Скорострельность
    public string Speed;          // Скорость (для ножа)
    public Sprite ItemSprite;     // Иконка
    public GameObject ItemObject; // Само оружие
    public bool IsLight;          // Легкое оружие
    public bool IsHeavy;          // Тяжелое оружие
    public bool IsSteel;          // Холодное оружие
}
