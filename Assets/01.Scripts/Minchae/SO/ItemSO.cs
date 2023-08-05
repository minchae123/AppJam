using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{

}

[CreateAssetMenu(fileName ="ItemSO", menuName ="SO/Item")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public Sprite sprite;
}
