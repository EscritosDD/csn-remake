// Decompiled with JetBrains decompiler
// Type: 딟.때
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Build;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 때
  {
    public bool 딟([In] BuildManifestBundleData[] obj0, [In] bool obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new Dictionary<string, 땟>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땟>());
      for (int index = 0; index < obj0.Length; ++index)
      {
        땟 땟 = new 땟();
        땟.딟 = obj0[index].Name;
        땟.땄 = obj0[index].ResourceName;
        땟.딟 = obj0[index].Version;
        땟.딟 = obj0[index].Content;
        this.땄().Add(땟.딟, 땟);
        this.딧().Add(땟);
        bool flag = obj0[index].Internal;
        땟.딟 = !obj1 || flag;
        if (!flag && string.IsNullOrEmpty(땟.땄))
          딧.떀.딧("No Resource Name specified on external bundle " + 땟.딟);
      }
      return true;
    }

    public 땟 딟([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return (땟) null;
      땟 땟;
      return !this.땄().TryGetValue(obj0, out 땟) ? (땟) null : 땟;
    }

    public void 딟()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟((List<땟>) null);
      // ISSUE: reference to a compiler-generated method
      this.딟((Dictionary<string, 땟>) null);
    }

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, 땟> 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<땟> 딧() => this.딟;
  }
}
