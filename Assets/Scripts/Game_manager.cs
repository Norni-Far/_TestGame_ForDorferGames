using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    public delegate void Delegats();
    public event Delegats Event_TuchFire;

    [SerializeField] private S_SceneManager S_scene;
    [SerializeField] private S_Save S_Save;
    [SerializeField] private UI_manager UI_manager;
    [SerializeField] private S_knifeMoveToposition S_knifePosition;
    [SerializeField] private S_moveReloadPlaceAround S_reloudknife;
    [SerializeField] private S_createApple S_createApple;
    [SerializeField] private S_knifeObstacles S_knifeObstacles;
    [SerializeField] private S_lifeOfWood S_lifeOfWood;
    [SerializeField] private S_animationControl S_animationControlForWood;
    [SerializeField] private U_settingMenu SettingMenu;

    [SerializeField] private GameObject MainCamera;

    [SerializeField] private GameObject[] knifesPrefabs = new GameObject[4];
    [SerializeField] private GameObject[] emptyKnifesPrefabs = new GameObject[4];

    [SerializeField] private GameObject[] readyKnifes = new GameObject[9];

    [Range(min: 0, max: 3)] public int chooseknife;
    [Range(min: 0, max: 9)] public int maxKnifesReady;

    [SerializeField] private int[] partsOfCircle = new int[24];  // 24 части по 15 градусов 
    [SerializeField] private bool StandartGame;

    private int colFire;

    private void Start()
    {
        S_Save.LoadGame();
        UI_manager.U_controlAnim.reloadGameIsWas = S_Save.LoadForReloadAfter_FailGame();

        Vibration.Init();
        S_lifeOfWood.event_gamerWinner += UI_manager.U_showScore.setNullForVariables;
        UI_manager.U_controlAnim.Event_reloadBtnIsDown += S_Save.SaveForReloadAfter_FailGame;
        UI_manager.U_controlAnim.Event_reloadNeed += UI_manager.ReloudScene;
        UI_manager.U_Shop.Event_buyknife += SetKnifeFromShop;
        Event_TuchFire += UI_manager.U_showScore.ForEventTuchFire;

        UI_manager.event_Attack += KnifeFire;
        S_lifeOfWood.event_gamerWinner += GamerIsWinner;
        S_lifeOfWood.event_gamerWinner += UI_manager.U_controlAnim.SetRetoadGame;

        StartGames();
    }

    private void StartGames()
    {
        //создание бревна 
        S_lifeOfWood.CreateWood();
        S_animationControlForWood.OnAnimation();

        // выставление настроек 
        propertiesForGame();

        // выствавление ножей по кругу, перезарядка
        S_reloudknife.towardsAngle = 0;
        S_reloudknife.gameObject.transform.eulerAngles = Vector3.zero;
        readyKnifes = S_knifePosition.OnReloadKnifes(knifesPrefabs[chooseknife], maxKnifesReady);

        // подписка ножей на нанесение урона бревну
        SubscribeForWoodLife();

        // выставление яблока 
        CreateApple();

        // выставление рандомных ножей 
        S_knifeObstacles.calculateOfKnifeObstacles(partsOfCircle, emptyKnifesPrefabs);
        S_lifeOfWood.addEmptyWoods(S_knifeObstacles.emptyKnifes);

        // UI
        UI_manager.U_controlAnim.AfterStart();
        UI_manager.U_Shop.SetKnifeIntheStore(chooseknife);
        UI_manager.U_showScore.SetCountOfKnifesLeftInTheList();
    }

    private void propertiesForGame()
    {
        // maxKnifesReady = Random.Range(4, 10);

        S_lifeOfWood.lifeOfWood = maxKnifesReady;
        UI_manager.U_showScore.colReadyknifesForAttack = maxKnifesReady;
        UI_manager.U_showScore.SetnullIncountOfKnifesLeft();

        colFire = 0;
        partsOfCircle = new int[24];
        S_lifeOfWood.nullOfFallObjects();
        S_knifeObstacles.emptyKnifes = new List<GameObject>();

        UI_manager.Set_MenuSettings();
    }

    private void SubscribeForWoodLife()
    {
        foreach (var item in readyKnifes)
        {
            if (item != null)
            {
                item.GetComponent<S_tuchOtherThings>().event_tuchOfWood += S_lifeOfWood.minuslifeOfWood;
                item.GetComponent<S_tuchOtherThings>().event_forUITuchOfWood += UI_manager.U_showScore.AddScoreWhenKnifeTuchWood;
                item.GetComponent<S_tuchOtherThings>().event_tuchOfKnife += UI_manager.U_controlAnim.forEvent_FailGameIsOpen;
            }
        }
    }

    private void CreateApple()
    {
        partsOfCircle[0] = S_createApple.calculateOfApple();

        if (S_createApple.getAppleObject() != null)
        {
            S_lifeOfWood.addItemObjectForListOfFallObjects(S_createApple.getAppleObject());
            S_createApple.getAppleObject().GetComponent<S_Apple>().event_DestroyAplle += UI_manager.U_showScore.AddScoreWhenKnifeTuchApple;
        }
    }

    private void KnifeFire()
    {
        if (S_reloudknife.readyFire)
            Attack();
    }


    public void SetKnifeFromShop(int num)
    {
        chooseknife = num;
        S_Save.SaveGame();
        S_scene.ReloadScene();

    }

    private void Attack()
    {
        if (colFire < maxKnifesReady)
        {
            readyKnifes[colFire].transform.parent = null;
            readyKnifes[colFire].GetComponent<S_moveKnife>().Attack();

            S_reloudknife.towardsAngle += 40;

            Event_TuchFire?.Invoke();
            colFire++;
        }
    }

    #region Winner
    private void GamerIsWinner()
    {
        StartCoroutine(StartNewGame());
    }

    IEnumerator StartNewGame()
    {
        S_Save.SaveGame();
        yield return new WaitForSeconds(1.5f);
        StartGames();
        S_animationControlForWood.SetSmallScaleForAnim();
        S_animationControlForWood.OnAnimation();
    }

    #endregion

}
