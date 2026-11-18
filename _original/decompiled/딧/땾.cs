// Decompiled with JetBrains decompiler
// Type: 딧.땾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public static class 땾
  {
    public static 딟 딟<딟>([In] string obj0)
    {
      if (땾.땄() == null)
        땾.딟(new 딗());
      try
      {
        return 땾.땄().딟<딟>(obj0);
      }
      catch (Exception ex)
      {
        return default (딟);
      }
    }

    public static 딟 딟<딟>([In] object obj0)
    {
      if (땾.땄() == null)
        땾.딟(new 딗());
      return 땾.땄().딟<딟>(obj0);
    }

    public static string 땄([In] object obj0)
    {
      if (땾.딟() == null)
        땾.딟(new 딾());
      StringBuilder stringBuilder = new StringBuilder(1024);
      땾.딟().딢(stringBuilder, obj0);
      return stringBuilder.ToString();
    }

    public static string 딧([In] object obj0) => 땾.땄(obj0);

    public static 딟[] 딟<딟>([In] 딟[] obj0) => obj0 == null ? new 딟[0] : obj0;

    public static 딟 딟<딟>([In] 딟 obj0) where 딟 : new()
    {
      if ((object) obj0 != null)
        return obj0;
      return new 딟();
    }

    [CompilerGenerated]
    [SpecialName]
    public static 딾 딟() => 땾.딟;

    [CompilerGenerated]
    [SpecialName]
    public static void 딟([In] 딾 obj0) => 땾.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public static 딗 땄() => 땾.딟;

    [CompilerGenerated]
    [SpecialName]
    public static void 딟([In] 딗 obj0) => 땾.딟 = obj0;
  }
}
