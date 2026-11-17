// Decompiled with JetBrains decompiler
// Type: 땺.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public class 땢
  {
    public static float 딟([In] float obj0)
    {
      obj0 = (double) obj0 <= 1.0 ? obj0 : 1f;
      return (double) obj0 < 0.0 ? 0.0f : obj0;
    }

    public static int 딟([In] int obj0)
    {
      obj0 = obj0 <= 1 ? obj0 : 1;
      return obj0 < 0 ? 0 : obj0;
    }

    public static bool 딟([In] float obj0, [In] float obj1) => (double) obj0 + 5.96000013786124E-08 >= (double) obj1 && (double) obj0 - 5.96000013786124E-08 <= (double) obj1;

    public static Vector3 딟([In] ref Vector3 obj0, [In] ref Vector3 obj1) => new Vector3((float) (obj0.x + obj1.x), (float) (obj0.y + obj1.y), 0.0f);

    public static Vector3 딟([In] ref Vector3 obj0, [In] ref Vector3 obj1, [In] ref Vector3 obj2) => new Vector3((float) (obj0.x + obj1.x + obj2.x), (float) (obj0.y + obj1.y + obj2.y), 0.0f);

    public static Vector3 딟(
      [In] ref Vector3 obj0,
      [In] ref Vector3 obj1,
      [In] ref Vector3 obj2,
      [In] ref Vector3 obj3,
      [In] ref Vector3 obj4)
    {
      return new Vector3((float) (obj0.x + obj1.x + obj2.x + obj3.x + obj4.x), (float) (obj0.y + obj1.y + obj2.y + obj3.y + obj4.y), 0.0f);
    }

    public static Vector3 땄([In] ref Vector3 obj0, [In] ref Vector3 obj1) => new Vector3((float) (obj0.x * obj1.x), (float) (obj0.y * obj1.y), 0.0f);

    public static Vector3 딟([In] ref Vector3 obj0, [In] ref float obj1) => new Vector3((float) obj0.x * obj1, (float) obj0.y * obj1, 0.0f);

    public static Vector3 딟([In] Vector3 obj0, [In] ref float obj1) => new Vector3((float) obj0.x * obj1, (float) obj0.y * obj1, 0.0f);

    public static Vector3 딟([In] Vector3 obj0, [In] float obj1) => new Vector3((float) obj0.x * obj1, (float) obj0.y * obj1, 0.0f);

    public static Vector3 딟([In] ref Vector3 obj0, [In] ref float obj1, [In] ref float obj2) => new Vector3((float) obj0.x * obj1 * obj2, (float) obj0.y * obj1 * obj2, 0.0f);

    public static Vector3 딟([In] ref Vector3 obj0, [In] ref float obj1, [In] float obj2) => new Vector3((float) obj0.x * obj1 * obj2, (float) obj0.y * obj1 * obj2, 0.0f);
  }
}
