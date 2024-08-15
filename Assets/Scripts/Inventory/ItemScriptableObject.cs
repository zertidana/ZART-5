using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/itemScriptableObject", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public int id;
    public Vector2 size= Vector2.one; //how many across x and how many across y
    public Sprite sprite;
    public GameObject WorldPrefab;
}