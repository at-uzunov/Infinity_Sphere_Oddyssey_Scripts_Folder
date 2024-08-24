using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

[Serializable]

public class ConsumableItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
}

public class ShopScript : MonoBehaviour, IStoreListener
{
    public Text coinTxt;
    IStoreController m_StoreController;
    public ConsumableItem cItem;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("Coins",0);
        coinTxt.text = coins.ToString();
        SetupBuilder();
    }
    void Update()
    {
        int coins = PlayerPrefs.GetInt("Coins",0);
        coinTxt.text = coins.ToString();

    }
    void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(cItem.Id, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);

    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_StoreController = controller;
    }
    public void Consumable_Btn_Pressed()
    {
        m_StoreController.InitiatePurchase(cItem.Id);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        print("Purchase Complete" + product.definition.id);

        int current_coins = PlayerPrefs.GetInt("Coins", 0);
        PlayerPrefs.SetInt("Coins", current_coins + 50);

        return PurchaseProcessingResult.Complete;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("initialize failed" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("initialize failed" + error+message);
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("purchase failed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        throw new NotImplementedException();
    }
}