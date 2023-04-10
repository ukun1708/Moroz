using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    TextMeshProUGUI coinCountText;
    public void ChangeCoinUIPlus()
    {
        int CountText = int.Parse(coinCountText.text);

        CountText++;

        coinCountText.text = CountText.ToString();
    }
    public void ChangeCoinUIMinus()
    {
        int CountText = int.Parse(coinCountText.text);

        CountText--;

        coinCountText.text = CountText.ToString();
    }
}
