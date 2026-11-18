// Decompiled with JetBrains decompiler
// Type: 땺.딶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace 땺
{
  public static class 딶
  {
    public static Action<Action> 딟 = (Action<Action>) (obj0 =>
    {
      GUILayout.BeginHorizontal(new GUILayoutOption[0]);
      obj0();
      GUILayout.EndHorizontal();
    });
    public static Action<GUIStyle, Action> 딟 = (Action<GUIStyle, Action>) ((obj0, obj1) =>
    {
      if (obj0 == null)
        GUILayout.BeginVertical(new GUILayoutOption[0]);
      else
        GUILayout.BeginVertical(obj0, new GUILayoutOption[0]);
      obj1();
      GUILayout.EndVertical();
    });
  }
}
