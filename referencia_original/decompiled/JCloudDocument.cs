// Decompiled with JetBrains decompiler
// Type: JCloudDocument
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudDocument : MonoBehaviour
{
  public static bool 딟([In] string obj0)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static bool 땄([In] string obj0)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static bool 딟([In] string obj0, [In] byte[] obj1)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static byte[] 딧([In] string obj0) => obj0 == null || obj0 == string.Empty ? (byte[]) null : (byte[]) null;

  public static bool 딟([In] string obj0, out DateTime _param1)
  {
    if (obj0 == null || obj0 == string.Empty)
    {
      _param1 = new DateTime(0L);
      return false;
    }
    _param1 = new DateTime(0L);
    return false;
  }

  public static bool 딟([In] string obj0, [In] string obj1, [In] bool obj2)
  {
    if (obj0 == null || obj0 == string.Empty || obj1 == null || !(obj1 == string.Empty))
      ;
    return false;
  }

  public static bool 땄([In] string obj0, [In] string obj1, [In] bool obj2)
  {
    if (obj0 == null || obj0 == string.Empty || obj1 == null || !(obj1 == string.Empty))
      ;
    return false;
  }

  public static bool 딢([In] string obj0)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static bool 땃([In] string obj0)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static bool 딶([In] string obj0)
  {
    if (obj0 == null || !(obj0 == string.Empty))
      ;
    return false;
  }

  public static string[] 땓([In] string obj0) => obj0 == null ? (string[]) null : (string[]) null;

  public static string[] 땺([In] string obj0) => obj0 == null ? (string[]) null : (string[]) null;

  public static bool 땄([In] string obj0, out DateTime _param1)
  {
    if (obj0 == null || obj0 == string.Empty)
    {
      _param1 = new DateTime(0L);
      return false;
    }
    _param1 = new DateTime(0L);
    return false;
  }

  public static bool 딧([In] string obj0, [In] string obj1, [In] bool obj2)
  {
    if (obj0 == null || obj0 == string.Empty || obj1 == null || !(obj1 == string.Empty))
      ;
    return false;
  }

  public static bool 딢([In] string obj0, [In] string obj1, [In] bool obj2)
  {
    if (obj0 == null || obj0 == string.Empty || obj1 == null || !(obj1 == string.Empty))
      ;
    return false;
  }

  public static bool 딟() => false;
}
