using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppPurchase : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public void Purchase(int numberHealth) {
        playerData.maxHealth += numberHealth;
        PlayerPrefs.SetInt(Constants.PrefsKey_PlayerHealth, playerData.maxHealth);
    }
}
