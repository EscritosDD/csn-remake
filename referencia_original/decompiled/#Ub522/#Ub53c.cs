// Decompiled with JetBrains decompiler
// Type: 딢.딼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

namespace 딢
{
  public static class 딼
  {
    private static int 딟;
    private static int 땄;
    private static int 딧;
    private static int 딢;
    private static bool 딟;

    private static void 딟(out int _param0, out int _param1)
    {
      int index1 = 0;
      int num1 = 0;
      for (int index2 = 0; index2 < Screen.resolutions.Length; ++index2)
      {
        int num2 = ((Resolution) ref Screen.resolutions[index2]).width * ((Resolution) ref Screen.resolutions[index2]).height;
        if (num2 > num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      _param0 = ((Resolution) ref Screen.resolutions[index1]).width;
      _param1 = ((Resolution) ref Screen.resolutions[index1]).height;
    }

    public static void 딟()
    {
      딼.땄();
      if (Screen.fullScreen)
        Screen.SetResolution(딼.딧, 딼.딢, false);
      else
        Screen.SetResolution(딼.딟, 딼.땄, true);
    }

    private static void 땄()
    {
      if (딼.딟)
        return;
      딼.딟 = true;
      딼.딧 = Screen.width;
      딼.딢 = Screen.height;
      딼.딟(out 딼.딟, out 딼.땄);
    }

    public static void 딧()
    {
      딼.땄();
      if (Screen.fullScreen)
      {
        if (Screen.width == 딼.딟 && Screen.height == 딼.땄)
          return;
        Screen.SetResolution(딼.딟, 딼.땄, true);
      }
      else
      {
        if (Screen.width == 딼.딧 && Screen.height == 딼.딢)
          return;
        Screen.SetResolution(딼.딧, 딼.딢, false);
      }
    }
  }
}
