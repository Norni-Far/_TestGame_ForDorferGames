using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    public U_controlAnimMenu U_controlAnim;
    public U_shop U_Shop;
    [SerializeField] private S_SceneManager S_scene;
    [SerializeField] private S_Save S_Save;
    [SerializeField] private Game_manager GameManager;
    [SerializeField] private S_moveReloadPlaceAround S_reloadknife;
    [SerializeField] private S_MoveWood S_moveWood;
    [SerializeField] private U_settingMenu U_Settings;
    public U_scoreText U_showScore;

    public delegate void Delegats();
    public event Delegats event_Attack;

    public void AttackBtnTuchIn()
    {
        event_Attack?.Invoke();
    }

    public void ReloudScene()
    {
        S_scene.ReloadScene();
    }



    #region fromMenuSettings_Control
    public void BtnSaveAndReload()
    {
        GameManager.maxKnifesReady = U_Settings.value_SliderForColKnifes();
        S_reloadknife.speedRotate = U_Settings.value_SliderDelayForKnifes();
        S_moveWood.SpeedRotation = U_Settings.value_SliderForWoodSpeed(); 
        S_moveWood.timeOfSpeedMaxForWood = U_Settings.value_SliderForTimeWoodMaxSpeed();
        S_moveWood.timeOfSpeedMinForWood = U_Settings.value_SliderForTimeWoodMinSpeed();
        S_Save.SaveGame();
        ReloudScene();
    }

    public void Set_MenuSettings()
    {
        U_Settings.Setvalue_SliderForColKnifes(GameManager.maxKnifesReady);
        U_Settings.Setvalue_SliderDelayForKnifes(S_reloadknife.speedRotate);
        U_Settings.Setvalue_SliderForWoodSpeed(S_moveWood.SpeedRotation);
        U_Settings.Setvalue_SliderForTimeWoodMaxSpeed(S_moveWood.timeOfSpeedMaxForWood);
        U_Settings.Setvalue_SliderForTimeWoodMinSpeed(S_moveWood.timeOfSpeedMinForWood);
    }

    #endregion
}
