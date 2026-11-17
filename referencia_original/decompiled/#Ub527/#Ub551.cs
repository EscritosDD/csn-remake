// Decompiled with JetBrains decompiler
// Type: 딧.땑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public class 땑
  {
    public static 딘 딟([In] string obj0, [In] string obj1) => (딘) new 땑.딲(obj0, obj1);

    private class 딲 : 딘
    {
      private string 딟;

      public 딲([In] string obj0, [In] string obj1) => this.딟 = string.Format("{0}/{1}", (object) obj0, (object) obj1);

      public void 딟([In] string obj0) => PlayerPrefs.SetString(this.딟, obj0);

      public string 딟() => PlayerPrefs.GetString(this.딟);
    }
  }
}
