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

    public TextMeshProUGUI gui; 
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
