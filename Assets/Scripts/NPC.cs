using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    public enum Symbol {EMPTY, STAR, HEART, SPADE, UNKNOWN}
    
    public Symbol symbol;
    public Sprite[] symbolsSprite;
    public GameObject symbolIndicator;
    public SpriteRenderer symbolSpriteRenderer;
    private bool interacted; 
    private void Awake()
    {
        int randInt = Random.Range(1, 4);
        if (symbol == Symbol.EMPTY)
        {
            symbol = (Symbol)randInt;
        }
        symbolIndicator.SetActive(false);
        symbolSpriteRenderer.sprite = symbolsSprite[randInt - 1];
    }

    public void SetSymbol(Symbol symbol)
    {
        this.symbol = symbol;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!interacted)
            {
                if (symbol == Symbol.STAR) GameManager.instance.starCountFound++;
                if (symbol == Symbol.HEART) GameManager.instance.heartCountFound++;
                if (symbol == Symbol.SPADE) GameManager.instance.spadeCountFound++;
                GameManager.instance.UpdateUI();
                interacted = true;

            }
            symbolIndicator.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            symbolIndicator.SetActive(false);
        }
    }
}
