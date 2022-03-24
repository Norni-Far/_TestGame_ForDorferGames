using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class S_Save : MonoBehaviour
{
    [SerializeField] private U_settingMenu U_settings;
    [SerializeField] private Game_manager GameManager;
    [SerializeField] private U_scoreText ScoreText;
    [SerializeField] private S_moveReloadPlaceAround S_reloadknife;
    [SerializeField] private S_MoveWood S_moveWood;

    public void SaveForReloadAfter_FailGame(int num)
    {
        PlayerPrefs.SetInt("SavedReload", num);
        PlayerPrefs.Save();
    }

    public int LoadForReloadAfter_FailGame()
    {
        if (PlayerPrefs.HasKey("SavedReload"))
            return PlayerPrefs.GetInt("SavedReload");
        else
            return 0;
    }

    public void SaveGame()
    {
        SaveAll DataZapic = new SaveAll();

        // Data
        DataZapic.scoreOfEfficiency = ScoreText.scoreFull;
        DataZapic.scoreApple = ScoreText.scoreApple;
        DataZapic.numChooseOfKnife = GameManager.chooseknife;

        DataZapic.colKnifesForGame = U_settings.value_SliderForColKnifes();
        DataZapic.delayForFireOfKnife = U_settings.value_SliderDelayForKnifes();
        DataZapic.speedOfRotateWood = U_settings.value_SliderForWoodSpeed();
        DataZapic.timeOfMaxSpeed = U_settings.value_SliderForTimeWoodMaxSpeed();
        DataZapic.timeOfMinSpeed = U_settings.value_SliderForTimeWoodMinSpeed();
        //

        string jsonZapic = JsonUtility.ToJson(DataZapic);

        #region Platform
#if UNITY_ANDROID
        File.WriteAllText(Application.persistentDataPath + "settingsForGame.json", jsonZapic);
#endif

#if UNITY_EDITOR
        File.WriteAllText(Application.dataPath + "settingsForGame.json", jsonZapic);
#endif
        #endregion
    }

    public void LoadGame()
    {
        string jsonZapic2;

        #region Platform
#if UNITY_ANDROID
        if (File.Exists(Application.persistentDataPath + "settingsForGame.json"))
            jsonZapic2 = File.ReadAllText(Application.persistentDataPath + "settingsForGame.json");
        else
        {
            standartPropertiesSave();
            jsonZapic2 = File.ReadAllText(Application.persistentDataPath + "settingsForGame.json");
        }
#endif

#if UNITY_EDITOR
        if (File.Exists(Application.dataPath + "settingsForGame.json"))
            jsonZapic2 = File.ReadAllText(Application.dataPath + "settingsForGame.json");
        else
        {
            standartPropertiesSave();
            jsonZapic2 = File.ReadAllText(Application.dataPath + "settingsForGame.json");
        }
#endif
        #endregion

        SaveAll LoadedDataZapic = JsonUtility.FromJson<SaveAll>(jsonZapic2);

        // Load Data 
        ScoreText.scoreFull = LoadedDataZapic.scoreOfEfficiency;
        ScoreText.scoreApple = LoadedDataZapic.scoreApple;
        GameManager.chooseknife = LoadedDataZapic.numChooseOfKnife;

        GameManager.maxKnifesReady = LoadedDataZapic.colKnifesForGame;
        S_reloadknife.speedRotate = LoadedDataZapic.delayForFireOfKnife;
        S_moveWood.SpeedRotation = LoadedDataZapic.speedOfRotateWood;
        S_moveWood.timeOfSpeedMaxForWood = LoadedDataZapic.timeOfMaxSpeed;
        S_moveWood.timeOfSpeedMinForWood = LoadedDataZapic.timeOfMinSpeed;
        //
    }

    private void standartPropertiesSave()
    {
        SaveAll DataZapic = new SaveAll();

        // Data
        DataZapic.scoreOfEfficiency = 0;
        DataZapic.scoreApple = 0;
        DataZapic.numChooseOfKnife = 0;

        DataZapic.colKnifesForGame = 6;
        DataZapic.delayForFireOfKnife = 35;
        DataZapic.speedOfRotateWood = 50;
        DataZapic.timeOfMaxSpeed = 2;
        DataZapic.timeOfMinSpeed = 1;
        //

        string jsonZapic = JsonUtility.ToJson(DataZapic);

        #region Platform
#if UNITY_ANDROID
        File.WriteAllText(Application.persistentDataPath + "settingsForGame.json", jsonZapic);
#endif

#if UNITY_EDITOR
        File.WriteAllText(Application.dataPath + "settingsForGame.json", jsonZapic);
#endif
        #endregion
    }
}


public class SaveAll
{
    public int scoreOfEfficiency;
    public int scoreApple;
    public int numChooseOfKnife;

    // FromSettings
    public int colKnifesForGame;
    public int delayForFireOfKnife;
    public int speedOfRotateWood;
    public int timeOfMaxSpeed;
    public int timeOfMinSpeed;
}
