using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    public int money; // ���������� ����� ����� ��� ������ ����
    public TextMeshProUGUI textMoney; // ������ �� ����� �� ������� �����, � ������� ���������� ���������� �����.
    public Upgrade[] upgrade; // ������ �� ��� ���� ����� (������� Scin1, Scin2, Scin3)

    private void Update()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }

    }
}
