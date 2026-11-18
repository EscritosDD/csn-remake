// Decompiled with JetBrains decompiler
// Type: 딢.땚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public static class 땚
  {
    [SpecialName]
    private static 딾 딟()
    {
      딾 딾 = (딾) GlobalAppData.땽().딟(땹.땥);
      return 딾 == 딾.딢 ? 딾.땃 : 딾;
    }

    [SpecialName]
    public static bool 땄() => 땚.딟() < 딾.딶;

    [SpecialName]
    public static bool 딧() => 땚.딟() == 딾.땄 || 땚.딟() == 딾.딧 || 땚.딟() == 딾.땃;

    [SpecialName]
    public static bool 딢() => 땚.딟() == 딾.딢;

    public static bool 딟([In] SinglePlayerMissionAsset obj0) => obj0.NewUserFlowStartIndex == 땚.딟();

    public static void 딟([In] string obj0)
    {
      if (!string.IsNullOrEmpty(obj0) || 땚.딟() != 딾.딢)
        return;
      땚.땃();
    }

    public static void 땄([In] SinglePlayerMissionAsset obj0)
    {
      if (obj0.NewUserFlowStartIndex != 땚.딟())
        return;
      string str;
      땹 땹;
      switch (땚.딟())
      {
        case 딾.땄:
          str = "NUF_Challenge_1_Start";
          땹 = 땹.땻;
          break;
        case 딾.딧:
          str = "NUF_Challenge_2_Start";
          땹 = 땹.딥;
          break;
        case 딾.딢:
          return;
        case 딾.땃:
          str = "NUF_Challenge_3_Start";
          땹 = 땹.떓;
          break;
        default:
          return;
      }
      if (GlobalAppData.땽().딟(땹) != 0)
        return;
      GlobalAppData.땽().딟(땹, 1);
      딟.딦.딟(str);
    }

    public static bool 딧([In] SinglePlayerMissionAsset obj0)
    {
      if (obj0.NewUserFlowStartIndex != 땚.딟())
        return false;
      switch (땚.딟())
      {
        case 딾.땄:
          딟.딦.딟("NUF_Challenge_1_Complete");
          break;
        case 딾.딧:
          딟.딦.딟("NUF_Challenge_2_Complete");
          break;
        case 딾.땃:
          딟.딦.딟("NUF_Challenge_3_Complete");
          break;
      }
      땚.땃();
      return true;
    }

    private static void 땃() => GlobalAppData.땽().딟(땹.땥, (int) (땚.딟() + 1), true);

    public static void 딶()
    {
    }

    public static void 땓()
    {
    }

    public static void 딢([In] SinglePlayerMissionAsset obj0)
    {
    }

    public static void 땃([In] SinglePlayerMissionAsset obj0)
    {
    }

    public static void 땺()
    {
    }

    public static void 땥()
    {
    }

    public static void 딝()
    {
    }

    public static void 떎()
    {
    }

    public static void 떂()
    {
      if (땚.딟() != 딾.딢)
        return;
      딟.딦.딟("NUF_Multiplayer_1_Selection");
    }

    public static void 땭()
    {
      if (땚.딟() != 딾.딢 || GlobalAppData.땽().딟(땹.딛) != 0)
        return;
      GlobalAppData.땽().딟(땹.딛, 1);
      딟.딦.딟("NUF_Single_Multiplayer_1_Started");
    }

    public static void 땄([In] string obj0) => 땚.딟(obj0, (string) null);

    public static void 딟([In] string obj0, [In] string obj1)
    {
      string str;
      땹 땹;
      switch (땚.딟())
      {
        case 딾.땄:
          str = "NUF_Single_PlayMenu_1";
          땹 = 땹.땩;
          break;
        case 딾.딧:
          str = "NUF_Single_PlayMenu_2";
          땹 = 땹.땠;
          break;
        case 딾.딢:
          str = "NUF_Single_PlayMenu_3";
          땹 = 땹.땴;
          break;
        case 딾.땃:
          str = "NUF_Single_PlayMenu_4";
          땹 = 땹.딗;
          break;
        default:
          str = "NUF_Single_PlayMenu_END";
          땹 = 땹.땳;
          break;
      }
      if (GlobalAppData.땽().딟(땹) != 0)
        return;
      GlobalAppData.땽().딟(땹, 1);
      Dictionary<string, string> dictionary = new Dictionary<string, string>()
      {
        {
          "Button",
          obj0
        }
      };
      if (obj1 != null)
        dictionary.Add("Id", obj1);
      딟.딦.딟(str, dictionary);
    }
  }
}
