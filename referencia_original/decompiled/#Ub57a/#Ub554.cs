// Decompiled with JetBrains decompiler
// Type: 땺.땔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public abstract class 땔
  {
    public static 딥[] 딟([In] GameObject obj0)
    {
      RageSpline[] componentsInChildren = obj0.GetComponentsInChildren<RageSpline>();
      딥[] 딥Array = new 딥[componentsInChildren.Length];
      for (int index = 0; index < componentsInChildren.Length; ++index)
        딥Array[index] = 땔.딟(componentsInChildren[index]);
      return 딥Array;
    }

    public static 딥 땄([In] GameObject obj0) => 땔.딟(obj0.GetComponent<RageSpline>());

    public static 딥 딧([In] GameObject obj0) => 땔.딟(obj0.GetComponentInChildren<RageSpline>());

    public static 딥 딢([In] GameObject obj0) => 땔.딟(obj0.AddComponent<RageSpline>());

    private static 딥 딟([In] RageSpline obj0)
    {
      if (Object.op_Equality((Object) obj0, (Object) null))
        return (딥) null;
      RageSplineAdapter instance = (RageSplineAdapter) ScriptableObject.CreateInstance(typeof (RageSplineAdapter));
      instance.딟((MonoBehaviour) obj0);
      return (딥) instance;
    }

    public enum 땁
    {
      딟,
      땄,
      딧,
      딢,
    }

    public enum 땷
    {
      딟,
      땄,
      딧,
      딢,
    }

    public enum 딸
    {
      딟,
      땄,
      딧,
    }

    public enum 땘
    {
      딟,
      땄,
    }
  }
}
