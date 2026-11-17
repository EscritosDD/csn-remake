// Decompiled with JetBrains decompiler
// Type: 땃.딠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 딠
  {
    public 딶.딡 딟;
    public 딵 딟;
    public 딶.땙 딟;
    public 딡 딟;
    public WeaponGameplayData 딟;
    public 땓.땊 딟;
    public List<딡> 딟;
    public int 딟;
    public int 땄;
    public List<int> 딟;

    public 딠(
      [In] 딶.딡 obj0,
      [In] 딵 obj1,
      [In] 딶.땙 obj2,
      [In] 딡 obj3,
      [In] WeaponGameplayData obj4,
      [In] 땓.땊 obj5,
      [In] int obj6,
      [In] int obj7,
      [In] List<딡> obj8)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
      this.딟 = obj8;
      this.딟 = obj4;
      this.딟 = obj5;
      this.딟 = obj6;
      this.땄 = obj7;
      this.딟 = obj0.땓().GatherBlockingTiles(obj0.땼(), obj2);
    }

    public void 딟(
      [In] 딶.딡 obj0,
      [In] 딵 obj1,
      [In] 딶.땙 obj2,
      [In] 딡 obj3,
      [In] WeaponGameplayData obj4,
      [In] 땓.땊 obj5,
      [In] int obj6,
      [In] int obj7,
      [In] List<딡> obj8)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
      this.딟 = obj8;
      this.딟 = obj4;
      this.딟 = obj5;
      this.딟 = obj6;
      this.땄 = obj7;
      this.딟 = obj0.땓().GatherBlockingTiles(obj0.땼(), obj2);
    }

    public void 딟() => this.딟 = (딶.딡) null;

    public bool 땄() => this.딟 != null;
  }
}
