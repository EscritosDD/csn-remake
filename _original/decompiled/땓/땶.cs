// Decompiled with JetBrains decompiler
// Type: 땓.땶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public abstract class 땶
  {
    public const string 딟 = "avatar";
    public const string 땄 = "facebook";

    public static 땶 딟([In] Uri obj0)
    {
      string scheme = obj0.Scheme;
      if (scheme != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (땶.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땶.딟 = new Dictionary<string, int>(2)
          {
            {
              "avatar",
              0
            },
            {
              "facebook",
              1
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (땶.딟.TryGetValue(scheme, out num))
        {
          if (num == 0)
            return (땶) new 떅(obj0);
          if (num == 1)
            return (땶) new 딫(obj0);
        }
      }
      return (땶) new 땖();
    }

    public static Uri 딟([In] string obj0)
    {
      Uri uri = 땶.땄(obj0);
      if (uri == (Uri) null && !string.IsNullOrEmpty(obj0))
        uri = 땶.땄("avatar://" + obj0);
      if (uri == (Uri) null)
        uri = 땶.땄("avatar://" + GlobalAppData.딟.DefaultPlayerAvatarId);
      return uri;
    }

    private static Uri 땄([In] string obj0)
    {
      try
      {
        if (!string.IsNullOrEmpty(obj0))
          return new Uri(obj0);
      }
      catch (UriFormatException ex)
      {
      }
      return (Uri) null;
    }

    [SpecialName]
    public abstract bool 딟();

    [SpecialName]
    public abstract bool 땄();

    [SpecialName]
    public abstract Material 딧();
  }
}
