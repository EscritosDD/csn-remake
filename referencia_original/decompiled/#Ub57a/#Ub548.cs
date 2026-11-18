// Decompiled with JetBrains decompiler
// Type: 땺.땈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 땺
{
  public struct 땈
  {
    public Color 딟;
    public Vector3[] 딟;

    public static 땈 딟([In] 땥.땟 obj0, [In] 땥.땟 obj1, [In] Color obj2)
    {
      땈 땈 = new 땈();
      땈.딟 = new Vector3[2];
      땈.딟[0] = 딝.딷.딟(obj0);
      땈.딟[1] = 딝.딷.딟(obj1);
      땈.딟 = obj2;
      return 땈;
    }

    public static 땈 딟([In] 땥.땟 obj0, [In] 땥.땟 obj1, [In] 땥.땟 obj2, [In] Color obj3)
    {
      땈 땈 = new 땈();
      땈.딟 = new Vector3[3];
      땈.딟[0] = 딝.딷.딟(obj0);
      땈.딟[1] = 딝.딷.딟(obj1);
      땈.딟[2] = 딝.딷.딟(obj2);
      땈.딟 = obj3;
      return 땈;
    }

    public static 땈 딟([In] 떁 obj0, [In] 떁 obj1, [In] Color obj2)
    {
      땈 땈 = new 땈();
      땈.딟 = new Vector3[2];
      땈.딟[0] = 딝.딷.딟(obj0);
      땈.딟[1] = 딝.딷.딟(obj1);
      땈.딟 = obj2;
      return 땈;
    }

    public static 땈 딟([In] 떁 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] Color obj3)
    {
      땈 땈 = new 땈();
      땈.딟 = new Vector3[3];
      땈.딟[0] = 딝.딷.딟(obj0);
      땈.딟[1] = 딝.딷.딟(obj1);
      땈.딟[2] = 딝.딷.딟(obj2);
      땈.딟 = obj3;
      return 땈;
    }
  }
}
