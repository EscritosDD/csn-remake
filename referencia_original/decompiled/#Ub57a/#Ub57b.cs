// Decompiled with JetBrains decompiler
// Type: 땺.땻
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public static class 땻
  {
    public static float 딟([In] this Camera obj0)
    {
      Vector3 worldPoint1 = obj0.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, obj0.nearClipPlane));
      Vector3 worldPoint2 = obj0.ScreenToWorldPoint(new Vector3(obj0.pixelWidth, obj0.pixelHeight, obj0.nearClipPlane));
      return (float) ((worldPoint2.x - worldPoint1.x) * (worldPoint2.y - worldPoint1.y));
    }

    public static GameObject 딟([In] this GameObject obj0, [In] string obj1)
    {
      foreach (Transform transform in obj0.transform)
      {
        if (((Object) transform).name.Equals(obj1))
          return ((Component) transform).gameObject;
      }
      return (GameObject) null;
    }
  }
}
