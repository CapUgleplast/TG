using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataUI : MonoSingleton<UserDataUI>
{
    public Text Money;
    public Text Crystal;

    void Awake() {
        UpdateUI(UserData.Instance.Money, UserData.Instance.Crystal);
    }

    public void UpdateUI(int money, int crystal) {
        Money.text = money.ToString();
        Crystal.text = crystal.ToString();
    }
}
