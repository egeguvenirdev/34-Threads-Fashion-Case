using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class ActionManager
{
    //Game Actions
    public static Action<AudioClip> PlayAudio { get; set; }

    public static Action<bool> GameEnd { get; set; }

    public static Action<float> UpdateManager { get; set; }

    public static Action GainRope { get; set; }

    public static Action<ClothesBase> GainClothes { get; set; }

    public static Action SewScreen { get; set; }

    public static Action DyeScreen { get; set; }

    public static Action CloseProducedClothes { get; set; }


    //Input Actions
    public static Action<Thread> ThreadSelection { get; set; }

    public static Action<SewingMachineBase> GetSelectedThread { get; set; }

    public static Action ClearThreadSelection { get; set; }


    public static Action<ClothesBase> ClothSelection { get; set; }

    public static Action<DyeMachineBase> GetSelectedCloth { get; set; }

    public static Action ClearClothSelection { get; set; }

    public static Action<ClothesBase> SellTheClothes { get; set; }

    public static Action<ColorType> SelledClothesType { get; set; }


    //Money Actions
    public static Action<float> UpdateMoney { get; set; }

    public static Action<float> UpdateMoneyMultiplier { get; set; }

    public static Predicate<float> CheckMoneyAmount { get; set; }


    //Player Controls
    public static Action<float> SwerveValue { get; set; }

    public static void ResetAllStaticVariables()
    {
        Type type = typeof(ActionManager);
        var fields = type.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public);
        foreach (var fieldInfo in fields)
        {
            fieldInfo.SetValue(null, GetDefault(type));
        }
    }

    public static object GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }
}
