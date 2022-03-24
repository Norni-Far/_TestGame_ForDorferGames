using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_shop : MonoBehaviour
{
    public delegate void Delegats(int num);
    public event Delegats Event_buyknife;

    [SerializeField] U_scoreText U_Score;
    [SerializeField] private Image vetrinaImage;
    [SerializeField] private Image[] knifesImageForVitrina = new Image[4];
    [SerializeField] private int[] priceList = new int[4];

    [SerializeField] private TMPro.TextMeshProUGUI textPrice;


    private int nowPositionOnTheVitrina;
    public void SetKnifeIntheStore(int numOfSprite)
    {
        vetrinaImage.sprite = knifesImageForVitrina[numOfSprite].sprite;
        nowPositionOnTheVitrina = numOfSprite;
        textPrice.text = priceList[numOfSprite].ToString();
    }

    public void AfterStart()
    {

    }

    private void ScrollShop(int a)
    {
        int choose = nowPositionOnTheVitrina + a;

        switch (choose)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                vetrinaImage.sprite = knifesImageForVitrina[choose].sprite;
                textPrice.text = priceList[choose].ToString();

                nowPositionOnTheVitrina = choose;
                break;

            default:
                break;
        }
    }

    #region ForBtn
    public void Btn_Left()
    {
        ScrollShop(-1);
    }

    public void Btn_Right()
    {
        ScrollShop(1);
    }

    public void Btn_BuyKnife()
    {
        if (U_Score.scoreApple >= priceList[nowPositionOnTheVitrina])
        {
            Event_buyknife?.Invoke(nowPositionOnTheVitrina);
        }
    }

    #endregion
}
