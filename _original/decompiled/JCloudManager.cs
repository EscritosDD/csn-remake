// Decompiled with JetBrains decompiler
// Type: JCloudManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudManager : MonoBehaviour
{
  public static Dictionary<int, 딟.땔.땁> 딟 = new Dictionary<int, 딟.땔.땁>();
  public static Dictionary<int, long> 딟 = new Dictionary<int, long>();
  public static Dictionary<int, int> 딟 = new Dictionary<int, int>();
  private static Dictionary<int, JCloudManager.땷> 딟 = new Dictionary<int, JCloudManager.땷>();
  protected static JCloudManager 딟 = (JCloudManager) null;
  protected static object 딟 = new object();

  public static void 딟()
  {
    lock (JCloudManager.딟)
    {
      if (!Object.op_Equality((Object) JCloudManager.딟, (Object) null))
        return;
      GameObject gameObject = new GameObject(nameof (JCloudManager), new Type[1]
      {
        typeof (JCloudManager)
      });
      JCloudManager.딟 = gameObject.GetComponent<JCloudManager>();
      Object.DontDestroyOnLoad((Object) gameObject);
    }
  }

  public static JCloudManager 땄()
  {
    JCloudManager.딟();
    return JCloudManager.딟;
  }

  public static void 딟([In] int obj0)
  {
    lock (JCloudManager.딟)
    {
      if (!JCloudManager.딟.ContainsKey(obj0))
      {
        JCloudManager.딟.Add(obj0, 1);
      }
      else
      {
        Dictionary<int, int> 딟;
        int key;
        (딟 = JCloudManager.딟)[key = obj0] = 딟[key] + 1;
      }
      if (JCloudManager.딟.ContainsKey(obj0))
        return;
      JCloudManager.딟.Add(obj0, 딟.땔.땁.딟);
    }
  }

  public static void 땄([In] int obj0)
  {
    lock (JCloudManager.딟)
    {
      if (!JCloudManager.딟.ContainsKey(obj0))
      {
        JCloudManager.딟.Add(obj0, 1);
      }
      else
      {
        Dictionary<int, int> 딟;
        int key;
        (딟 = JCloudManager.딟)[key = obj0] = 딟[key] + 1;
      }
      if (JCloudManager.딟.ContainsKey(obj0))
        return;
      JCloudManager.딟.Add(obj0, 딟.땔.땁.땄);
    }
  }

  public static 딟.땔.땁 딧([In] int obj0)
  {
    lock (JCloudManager.딟)
      return JCloudManager.딟.ContainsKey(obj0) ? JCloudManager.딟[obj0] : 딟.땔.땁.딟;
  }

  public static void 딢([In] int obj0)
  {
    lock (JCloudManager.딟)
    {
      if (JCloudManager.딟.ContainsKey(obj0))
      {
        Dictionary<int, int> 딟;
        int key;
        (딟 = JCloudManager.딟)[key = obj0] = 딟[key] - 1;
        if (JCloudManager.딟.ContainsKey(obj0))
          JCloudManager.딟.Remove(obj0);
        if (JCloudManager.딟[obj0] != 0)
          return;
        if (JCloudManager.딟.ContainsKey(obj0))
          JCloudManager.딟.Remove(obj0);
        JCloudManager.딟.Remove(obj0);
      }
      else
      {
        if (JCloudManager.딟.ContainsKey(obj0))
          JCloudManager.딟.Remove(obj0);
        if (!JCloudManager.딟.ContainsKey(obj0))
          return;
        JCloudManager.딟.Remove(obj0);
      }
    }
  }

  public static bool 딟([In] int obj0, out long _param1)
  {
    lock (JCloudManager.딟)
    {
      if (JCloudManager.딟.ContainsKey(obj0))
      {
        _param1 = JCloudManager.딟[obj0];
        return true;
      }
    }
    _param1 = 0L;
    return false;
  }

  public static int 땃([In] int obj0)
  {
    lock (JCloudManager.딟)
    {
      if (JCloudManager.딟.ContainsKey(obj0))
      {
        JCloudManager.땷 땷 = JCloudManager.딟[obj0];
        int num = 땷.땄++;
        JCloudManager.딟[obj0] = 땷;
        return num;
      }
      JCloudManager.딟.Add(obj0, new JCloudManager.땷(0, 1));
      return 0;
    }
  }

  public static bool 딟([In] int obj0, [In] int obj1)
  {
    lock (JCloudManager.딟)
      return JCloudManager.딟.ContainsKey(obj0) && obj1 == JCloudManager.딟[obj0].딟;
  }

  public static void 딶([In] int obj0)
  {
    lock (JCloudManager.딟)
    {
      if (!JCloudManager.딟.ContainsKey(obj0))
        return;
      JCloudManager.땷 땷 = JCloudManager.딟[obj0];
      ++땷.딟;
      if (땷.딟 == 땷.땄)
        JCloudManager.딟.Remove(obj0);
      else
        JCloudManager.딟[obj0] = 땷;
    }
  }

  public static string[] 딟([In] byte[] obj0, [In] bool obj1)
  {
    if (obj0 == null)
      return (string[]) null;
    uint uint32_1 = BitConverter.ToUInt32(obj0, 0);
    List<string> stringList = new List<string>();
    uint num1 = 4;
    for (uint index = 0; index < uint32_1; ++index)
    {
      bool boolean = BitConverter.ToBoolean(obj0, (int) num1);
      uint num2 = num1 + 1U;
      uint uint32_2 = BitConverter.ToUInt32(obj0, (int) num2);
      uint num3 = num2 + 4U;
      if (boolean == obj1)
      {
        UTF8Encoding utF8Encoding = new UTF8Encoding();
        stringList.Add(utF8Encoding.GetString(obj0, (int) num3, (int) uint32_2));
      }
      num1 = num3 + uint32_2;
    }
    return stringList.ToArray();
  }

  private struct 땷
  {
    public int 딟;
    public int 땄;

    public 땷([In] int obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }
  }
}
