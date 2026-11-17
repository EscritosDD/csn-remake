// Decompiled with JetBrains decompiler
// Type: 딢.땞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 땞
  {
    private const string 딟 = "Profile";
    private CloudProfileJsonData 딟;

    public 땞()
    {
    }

    public 땞([In] string obj0, [In] string obj1, [In] string obj2) => this.딟 = new CloudProfileJsonData(obj0, obj1, obj2);

    private string 딟() => 딧.땾.땄((object) this.딟);

    private static 땞 딟([In] string obj0)
    {
      CloudProfileJsonData cloudProfileJsonData = 딧.땾.딟<CloudProfileJsonData>(obj0);
      if (cloudProfileJsonData == null)
        return (땞) null;
      return new 땞() { 딟 = cloudProfileJsonData };
    }

    public void 땄()
    {
      string str = this.딟();
      if (!GlobalAppData.떁().딟())
        return;
      GlobalAppData.떁().딟("Profile", str, (Action) (() => { }));
    }

    public static void 딟([In] Action<땞> obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땞.땜 땜 = new 땞.땜();
      // ISSUE: reference to a compiler-generated field
      땜.딟 = obj0;
      if (GlobalAppData.떁().딟())
      {
        // ISSUE: reference to a compiler-generated method
        GlobalAppData.떁().딟("Profile", new Action<string>(땜.딟));
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        땜.딟((땞) null);
      }
    }

    public static void 딧()
    {
      if (!GlobalAppData.떁().딟())
        return;
      GlobalAppData.떁().딟("Profile", (Action) (() => { }));
    }

    [SpecialName]
    public string 딢() => this.딟.UserName;

    [SpecialName]
    public string 땃() => this.딟.AccessToken;

    [SpecialName]
    public string 딶() => this.딟.RefreshToken;
  }
}
