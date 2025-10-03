using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public NPC[] NPC_array;

    public NPC.Symbol playerSelectedSymbol; 
    
    public int heartCount;
    public int starCount;
    public int spadeCount;

    [HideInInspector]
    public int heartCountFound;
    [HideInInspector]
    public int starCountFound;
    [HideInInspector]
    public int spadeCountFound;

    public TextMeshProUGUI gui;

    public TextMeshProUGUI heartCounter;
    public TextMeshProUGUI starCounter;
    public TextMeshProUGUI spadeCounter;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        NPC_array = FindObjectsByType<NPC>(FindObjectsSortMode.None);
    }

    private void Start()
    {
        CountSymbols();
    }

    public void CountSymbols()
    {
        foreach (NPC npc in NPC_array)
        {
            switch (npc.symbol)
            {
                case NPC.Symbol.HEART:
                    heartCount++;
                    break;
                case NPC.Symbol.SPADE:
                    spadeCount++;
                    break;
                case NPC.Symbol.STAR:
                    starCount++;
                    break;
            }
        }
    }
    public void UpdateUI()
    {
        heartCounter.text = heartCountFound.ToString();
        starCounter.text = starCountFound.ToString();
        spadeCounter.text = spadeCountFound.ToString();
    }
    public NPC.Symbol  GreatestSymbol()
    {
        int greatestVal = Mathf.Max(heartCount,spadeCount,starCount);
        if (greatestVal == heartCount)
        {
            return NPC.Symbol.HEART;
        }else if (greatestVal == spadeCount)
        {
            return NPC.Symbol.SPADE;
        }else 
        {
            return NPC.Symbol.STAR;
        }
        
    }
}
