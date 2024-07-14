using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    Attack,
    Defense,
    Heal
}

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Game/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite cardArt1;
    public Sprite cardArt2;
    public Sprite cardArt3;
    public int value;
    public CardType cardType;
}