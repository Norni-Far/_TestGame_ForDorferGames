using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_scoreText : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;

    [SerializeField] private TMPro.TextMeshProUGUI textScore;
    [SerializeField] private TMPro.TextMeshProUGUI textScoreGameUI;

    [SerializeField] private TMPro.TextMeshProUGUI textApple;
    [SerializeField] private TMPro.TextMeshProUGUI textAppleGameUI;
    [SerializeField] private TMPro.TextMeshProUGUI textAppleShopMenu;


    [SerializeField] private GameObject posOfCreateKnifeInTheScreen;
    [SerializeField] private List<GameObject> countOfKnifesLeft = new List<GameObject>();
    [SerializeField] private GameObject prefabOfColKnifeInTheScreen;

    public int scoreApple;
    public int scoreFull;

    public int colReadyknifesForAttack;
    [SerializeField] private int scoreOneGame;


    public void SetnullIncountOfKnifesLeft()
    {
        foreach (var item in countOfKnifesLeft)
        {
            Destroy(item.gameObject);
        }

        countOfKnifesLeft.Clear();
    }

    public void SetCountOfKnifesLeftInTheList()
    {
        float backPos = 0;

        for (int i = 0; i < colReadyknifesForAttack; i++)
        {
            GameObject Inst = Instantiate(prefabOfColKnifeInTheScreen, posOfCreateKnifeInTheScreen.transform);
            Inst.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, Inst.GetComponent<RectTransform>().anchoredPosition.y + backPos, 0); ;
            countOfKnifesLeft.Add(Inst);
            backPos = Inst.GetComponent<RectTransform>().anchoredPosition.y + 100;
        }
    }

    public void ForEventTuchFire()
    {
        countOfKnifesLeft[colReadyknifesForAttack - 1].GetComponent<Image>().color = Color.black;
        colReadyknifesForAttack--;
    }

    public void setNullForVariables()
    {
        scoreOneGame = 0;
    }

    private void LateUpdate()
    {
        textScoreGameUI.text = scoreFull.ToString();
        textScore.text = Convert.ToString(scoreFull);
        textApple.text = Convert.ToString(scoreApple);
        textAppleGameUI.text = Convert.ToString(scoreApple);
        textAppleShopMenu.text = Convert.ToString(scoreApple);

    }

    /// <summary>
    /// Метод, когда нож воткнулся в дерево
    /// </summary>
    public void AddScoreWhenKnifeTuchWood()
    {
        scoreFull++;
        scoreOneGame++;
        SeePointsAnim("+1", 0.5f);
    }

    /// <summary>
    /// Метод, когда нож воткнулся в яблоко
    /// </summary>
    public void AddScoreWhenKnifeTuchApple()
    {
        scoreApple++;
        scoreOneGame += scoreOneGame;
        SeePointsAnim(("+" + (scoreOneGame + 8)).ToString(), 0.3f);
        scoreOneGame += 8;
        scoreFull += scoreOneGame;
    }
    private void SeePointsAnim(string Show, float SpeedAnim)
    {
        GameObject inst = Instantiate(textPrefab, gameObject.transform.parent);
        inst.transform.GetComponent<TMPro.TextMeshProUGUI>().text = Show;
        inst.transform.GetComponent<Animator>().speed = SpeedAnim;
    }

}
