using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_controlAnimMenu : MonoBehaviour
{
    public delegate void DelegatsForSave(int num);
    public event DelegatsForSave Event_reloadBtnIsDown;
    public delegate void Delegats();
    public event Delegats Event_reloadNeed;



    [SerializeField] private GameObject GameUI;
    [SerializeField] private Animator MainMenu_Anim;
    [SerializeField] private Animator SettingsMenu_Anim;
    [SerializeField] private Animator FailPanel_Anim;
    [SerializeField] private Animator ShopPanel_Anim;


    public int reloadGameIsWas;

    private const string nameAnim = "openAnim";
    public void AfterStart()
    {
        if (reloadGameIsWas != 1)
            MainMenu_Open();
        else
        {
            GameUI.SetActive(true);
            Event_reloadBtnIsDown?.Invoke(0);
        }

    }

    public void SetRetoadGame() => reloadGameIsWas = 1;

    // MainMenu
    public void Btn_MainMenu_play()
    {
        MainMenu_Close();
        GameUI.SetActive(true);
    }

    public void Btn_MainMenu_settings()
    {
        SettingsMenu_Open();
        MainMenu_Close();
    }


    //Settings
    public void Btn_SettingsMenu_back()
    {
        SettingsMenu_Close();
        MainMenu_Open();
    }

    // GameUI
    public void Btn_GameUI_Menu()
    {
        GameUI.SetActive(false);
        MainMenu_Open();
    }

    // Failpanel
    public void forEvent_FailGameIsOpen()
    {
        FailGame_Open();
    }

    public void Btn_FailGame_Reload()
    {
        FailGame_Close();
        reloadGameIsWas = 1;
        Event_reloadBtnIsDown?.Invoke(1);
        Event_reloadNeed?.Invoke();
    }

    //Shop
    public void Btn_MainMenu_Shop()
    {
        ShopMenu_Open();
        MainMenu_Close();
    }

    public void Btn_ShopMenu_Back()
    {
        ShopMenu_Close();
        MainMenu_Open();
    }



    #region MoveAnim
    private void MainMenu_Open()
    {
        MainMenu_Anim.SetInteger(nameAnim, 1);
    }
    private void MainMenu_Close()
    {
        MainMenu_Anim.SetInteger(nameAnim, 0);
    }

    private void SettingsMenu_Open()
    {
        SettingsMenu_Anim.SetInteger(nameAnim, 1);
    }

    private void SettingsMenu_Close()
    {
        SettingsMenu_Anim.SetInteger(nameAnim, 0);
    }

    private void FailGame_Open()
    {
        FailPanel_Anim.SetInteger(nameAnim, 1);
    }

    private void FailGame_Close()
    {
        FailPanel_Anim.SetInteger(nameAnim, 0);
    }

    private void ShopMenu_Open()
    {
        ShopPanel_Anim.SetInteger(nameAnim, 1);
    }
    private void ShopMenu_Close()
    {
        ShopPanel_Anim.SetInteger(nameAnim, 0);
    }
    #endregion
}
