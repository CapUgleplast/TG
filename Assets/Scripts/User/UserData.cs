using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoSingleton<UserData>
{
    public int Money => money;
    public int Crystal => crystal;

    int money;
    int crystal;

    public void SetUserData(int money, int crystal) {
        this.money = money;
        this.crystal = crystal;
        UpdateVisual();
    }
    public void SetMoney(int money) {
        this.money = money;
        UpdateVisual();
    }

    public void SetCrystal(int crystal) {
        this.crystal = crystal;
        UpdateVisual();
    }

    void UpdateVisual() {
        if (UserDataUI.Instance)
            UserDataUI.Instance.UpdateUI(Money, Crystal);
    }
}
