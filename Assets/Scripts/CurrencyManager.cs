using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    [SerializeField]
    private int m_currency;

    public static CurrencyManager m_currencymanager;
    private bool b_isCanBuy;
    public Text currencyText;

    // Use this for initialization
    void Start()
    {
        m_currencymanager = this;
        b_isCanBuy = true;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void AddCurrency(int amount)
    {
        //float tempCurrency = currency;
        //tempCurrency -= amount;

        m_currency += amount;
        UpdateUI();
    }

    //to check whether user has enough currency
    public bool RequestCurrency(int amount)
    {
        if (amount <= m_currency)
            return true;
        else
            return false;
    }

    void UpdateUI()
    {
        currencyText.text = "Currency: " + m_currency.ToString() + " Coins";
    }
}
