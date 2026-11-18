// Decompiled with JetBrains decompiler
// Type: 딧.떀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public static class 떀
  {
    public static void 딟([In] string obj0, params object[] args) => Debug.Log((object) string.Format(obj0, args));

    public static void 땄([In] string obj0, params object[] args) => Debug.LogError((object) string.Format(obj0, args));

    public static void 딧([In] string obj0, params object[] args) => Debug.LogWarning((object) string.Format(obj0, args));
  }
}
