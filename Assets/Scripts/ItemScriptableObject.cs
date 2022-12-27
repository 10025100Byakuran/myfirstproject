using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Item")] // ������� ������� � ����� Inventory

public class ItemScriptableObject : ScriptableObject
{
    public string Name;           // ���
    public float Damage;          // ����
    public float Shell;           // ���-�� ������
    public float FireRate;        // ����������������
    public string Speed;          // �������� (��� ����)
    public Sprite ItemSprite;     // ������
    public GameObject ItemObject; // ���� ������
    public bool IsLight;          // ������ ������
    public bool IsHeavy;          // ������� ������
    public bool IsSteel;          // �������� ������
}
