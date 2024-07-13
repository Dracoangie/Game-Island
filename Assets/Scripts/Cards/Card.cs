using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    Attack,
    Defense,
    Effect
}

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Game/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite cardArt;
    public int attack;
    public CardType cardType;
}