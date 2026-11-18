// Decompiled with JetBrains decompiler
// Type: 딝.딷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public static class 딷
  {
    public static float 딟;
    public static float 땄;
    public static Vector3 딟;

    public static 떁 딟([In] Vector3 obj0) => new 떁((float) obj0.x, (float) obj0.y);

    public static Vector3 딟([In] 땥.땟 obj0) => new Vector3(obj0.딟, obj0.땄, obj0.딧);

    public static Vector3 딟([In] 떁 obj0) => new Vector3(obj0.딟, obj0.땄, 0.0f);

    public static 떁 딟([In] Vector2 obj0) => new 떁((float) obj0.x, (float) obj0.y);

    public static Vector3 딟([In] Vector3 obj0, [In] Transform obj1)
    {
      딷.딟 = new Vector3();
      딷.딟 = Mathf.Atan2((float) obj0.y, (float) obj0.x);
      double 딟 = (double) 딷.딟;
      Quaternion localRotation = obj1.localRotation;
      double num = ((Quaternion) ref localRotation).eulerAngles.z * (Math.PI / 180.0);
      딷.딟 = (float) (딟 + num);
      딷.땄 = ((Vector3) ref obj0).magnitude;
      딷.딟.x = (__Null) ((double) Mathf.Cos(딷.딟) * (double) 딷.땄);
      딷.딟.y = (__Null) ((double) Mathf.Sin(딷.딟) * (double) 딷.땄);
      return Vector3.op_Addition(딷.딟, obj1.localPosition);
    }
  }
}
