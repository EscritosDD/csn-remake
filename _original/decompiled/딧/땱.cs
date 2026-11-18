// Decompiled with JetBrains decompiler
// Type: 딧.땱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public static class 땱
  {
    public static void 딟([In] string obj0, [In] string obj1) => PlayerPrefs.SetString(obj0, obj1);

    public static string 딟([In] string obj0) => PlayerPrefs.GetString(obj0);

    public static void 땄([In] string obj0) => PlayerPrefs.DeleteKey(obj0);

    public static string 딧([In] string obj0) => !PlayerPrefs.HasKey(obj0) ? string.Empty : 딟.딥.딧(PlayerPrefs.GetString(obj0));

    public static void 땄([In] string obj0, [In] string obj1) => PlayerPrefs.SetString(obj0, 딟.딥.딟(obj1));
  }
}
