//using System;
//using UnityEngine;
//using UnityEngine.Purchasing;

//public class IAPManager : MonoBehaviour, IStoreListener
//{
//    private static IStoreController storeController;
//    private static IExtensionProvider storeExtensionProvider;

//    public static string productIDConsumable = "Hint1";
//    public static string productIDNonConsumable = "UnlockProMode";

//    void Start()
//    {
//        if (storeController == null)
//        {
//            InitializePurchasing();
//        }
//    }

//    public void InitializePurchasing()
//    {
//        if (IsInitialized())
//        {
//            return;
//        }

//        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
//        builder.AddProduct(productIDConsumable, ProductType.Consumable);
//        builder.AddProduct(productIDNonConsumable, ProductType.NonConsumable);

//        UnityPurchasing.Initialize(this, builder);
//    }

//    private bool IsInitialized()
//    {
//        return storeController != null && storeExtensionProvider != null;
//    }

//    public void BuyConsumable()
//    {
//        BuyProductID(productIDConsumable);
//    }

//    void BuyProductID(string productId)
//    {
//        if (IsInitialized())
//        {
//            Product product = storeController.products.WithID(productId);

//            if (product != null && product.availableToPurchase)
//            {
//                storeController.InitiatePurchase(product);
//            }
//            else
//            {
//                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//            }
//        }
//        else
//        {
//            Debug.Log("BuyProductID FAIL. Not initialized.");
//        }
//    }

//    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//    {
//        storeController = controller;
//        storeExtensionProvider = extensions;
//    }

//    public void OnInitializeFailed(InitializationFailureReason error)
//    {
//        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//    }

//    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//    {
//        Debug.Log("OnPurchaseFailed: FAIL. Product: " + product.definition.storeSpecificId + ", PurchaseFailureReason: " + failureReason);
//    }

//    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//    {
//        if (String.Equals(args.purchasedProduct.definition.id, productIDConsumable, StringComparison.Ordinal))
//        {
//            Debug.Log("ProcessPurchase: PASS. Product: " + args.purchasedProduct.definition.id);

//            // Handle the logic for the purchased consumable product here
//            PlayerPrefs.SetString("purchaseDate_" + productIDConsumable, DateTime.Now.ToString());
//        }
//        else if (String.Equals(args.purchasedProduct.definition.id, productIDNonConsumable, StringComparison.Ordinal))
//        {
//            Debug.Log("ProcessPurchase: PASS. Product: " + args.purchasedProduct.definition.id);

//            // Handle the logic for the purchased non-consumable product here
//            PlayerPrefs.SetInt("isProModeUnlocked", 1);
//        }
//        else
//        {
//            Debug.Log("ProcessPurchase: FAIL. Unrecognized product: " + args.purchasedProduct.definition.id);
//        }

//        return PurchaseProcessingResult.Complete;
//    }


//    public void OnInitializeFailed(InitializationFailureReason error, string message)
//    {
//        throw new NotImplementedException();
//    }
//}
