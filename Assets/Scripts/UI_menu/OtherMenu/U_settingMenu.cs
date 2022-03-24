using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_settingMenu : MonoBehaviour
{
    public delegate int DelegatsForChangeSpeedOfWood(int Speed);
    public event DelegatsForChangeSpeedOfWood event_changeSpeedOfWood;

    [Header("Количество ножей")]
    [SerializeField] private TMPro.TextMeshProUGUI textColKnifes;
    [SerializeField] private Slider sliderForColKnifes;
    [SerializeField] private int minValueForColKnifes;
    [SerializeField] private int maxValueForColKnifes;

    [Header("Задержка бросков ножей")]
    [SerializeField] private TMPro.TextMeshProUGUI textDelayForKnifes;
    [SerializeField] private Slider sliderDelayForKnifes;
    [SerializeField] private int minValueDelayForKnifes;
    [SerializeField] private int maxValueDelayForKnifes;

    [Header("Скорость вращения бревна")]
    [SerializeField] private TMPro.TextMeshProUGUI textOfColSpeedOfWood;
    [SerializeField] private Slider sliderForWood_speed;
    [SerializeField] private int minValueForSpeedOfWood;
    [SerializeField] private int maxValueForSpeedOfWood;

    [Header("Время макс и мин вращения бревна")]
    [SerializeField] private TMPro.TextMeshProUGUI textOfColMaxTimeSpeedOfWood;
    [SerializeField] private Slider sliderForWood_timeMaxOfSpeed;
    [SerializeField] private TMPro.TextMeshProUGUI textOfColMinTimeSpeedOfWood;
    [SerializeField] private Slider sliderForWood_timeMinOfSpeed;
    [SerializeField] private int minValueForTimeMinOfSpeed;
    [SerializeField] private int maxValueForTimeMinOfSpeed;

    private void Start()
    {
        // Загрузука грарниц Слайдеров (не влияет на игровой процесс)
        sliderForColKnifes.maxValue = maxValueForColKnifes;
        sliderForColKnifes.minValue = minValueForColKnifes;

        sliderDelayForKnifes.maxValue = maxValueDelayForKnifes;
        sliderDelayForKnifes.minValue = minValueDelayForKnifes;

        sliderForWood_speed.maxValue = maxValueForSpeedOfWood;
        sliderForWood_speed.minValue = minValueForSpeedOfWood;

        sliderForWood_timeMaxOfSpeed.minValue = minValueForTimeMinOfSpeed;
        sliderForWood_timeMaxOfSpeed.maxValue = maxValueForTimeMinOfSpeed;
        sliderForWood_timeMinOfSpeed.minValue = minValueForTimeMinOfSpeed;
        sliderForWood_timeMinOfSpeed.maxValue = maxValueForTimeMinOfSpeed;
    }

    public void changeSliderForColKnifes()
    {
        textColKnifes.text = Convert.ToString(sliderForColKnifes.value);
    }

    public void changeSliderDelayForKnifes()
    {
        textDelayForKnifes.text = Convert.ToString(sliderDelayForKnifes.value);
    }

    public void changeSliderForWoodSpeed()
    {
        textOfColSpeedOfWood.text = Convert.ToString(sliderForWood_speed.value);
    }

    public void changeSliderForTimeWoodMaxSpeed()
    {
        textOfColMaxTimeSpeedOfWood.text = Convert.ToString(sliderForWood_timeMaxOfSpeed.value);
    }
    public void changeSliderForTimeWoodMinSpeed()
    {
        textOfColMinTimeSpeedOfWood.text = Convert.ToString(sliderForWood_timeMinOfSpeed.value);
    }

    #region GetValue
    public int value_SliderForColKnifes()
    {
        return (int)sliderForColKnifes.value;
    }

    public int value_SliderDelayForKnifes()
    {
        return (int)sliderDelayForKnifes.value;
    }

    public int value_SliderForWoodSpeed()
    {
        return (int)sliderForWood_speed.value;
    }

    public int value_SliderForTimeWoodMaxSpeed()
    {
        return (int)sliderForWood_timeMaxOfSpeed.value;
    }

    public int value_SliderForTimeWoodMinSpeed()
    {
        return (int)sliderForWood_timeMinOfSpeed.value;
    }
    #endregion


    #region SetValue

    public void Setvalue_SliderForColKnifes(int Num)
    {
        sliderForColKnifes.value = Num;
    }

    public void Setvalue_SliderDelayForKnifes(int Num)
    {
        sliderDelayForKnifes.value = Num;
    }

    public void Setvalue_SliderForWoodSpeed(int Num)
    {
        sliderForWood_speed.value = Num;
    }

    public void Setvalue_SliderForTimeWoodMaxSpeed(int Num)
    {
        sliderForWood_timeMaxOfSpeed.value = Num;
    }

    public void Setvalue_SliderForTimeWoodMinSpeed(int Num)
    {
        sliderForWood_timeMinOfSpeed.value = Num;
    }


    #endregion
}
