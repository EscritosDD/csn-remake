// Decompiled with JetBrains decompiler
// Type: 땃.딡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딡
  {
    public 땓.땦 딟;
    public GameTileComponent[] 딟;
    public int[] 딟;
    public List<딩> 딟;
    public List<떑> 딟;
    public List<떑> 땄;
    public 딯 딟;
    public float 딟;
    public 떍 딟;
    public 떋[] 딟;
    public 딴 딟;
    public int 딟;
    public 땀 딟;
    public 땪 딟;
    public List<땁> 딟;
    public 딞 딟;
    public bool 딟;
    public bool 땄;
    public bool 딧;
    public bool 딢;
    public bool[] 딟 = new bool[8];
    public bool 땃;
    public int 땄;
    public bool 딶;
    public bool 땓;
    public bool 땺;
    public bool 땥;
    public bool 딝;
    public 따 딟;
    public WeaponGameplayData 딟;
    public 딠 딟;
    public 딖 딟;
    public 딖 땄;
    public 딽 딟;

    public 딡([In] 땓.땦 obj0)
    {
      this.딟 = obj0;
      this.딟 = new 딯();
      this.딟 = new List<땁>();
      this.딟 = new 딞();
      this.딟 = true;
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index] = false;
      this.땃 = true;
    }

    public void 딟([In] 딶.딡 obj0)
    {
      this.땄 = new List<떑>();
      this.딟 = new List<떑>();
      if (obj0.땼().땻()[this.딟.땔()] is 땓.떀 떀)
      {
        this.딟.Add(땎.딟(obj0.땼(), this.딟.땔(), 딢.딴.땄));
        this.딟.Add((떑) new 딺());
        for (int index = 0; index < 떀.땁().Abilities.Length; ++index)
        {
          떑 떑 = 땎.딟(obj0.땼(), this.딟.땔(), 떀.땁().Abilities[index]);
          if (떑 != null)
            this.딟.Add(떑);
        }
        for (int index = 0; index < 떀.떓().Count; ++index)
        {
          떑 떑 = 땎.딟(obj0.땼(), this.딟.땔(), 떀.떓()[index]);
          if (떑 != null)
            this.딟.Add(떑);
        }
      }
      if (obj0.땼().땻()[this.딟.땔()] is 딶.딚)
        this.딟.Add(땎.딟(obj0.땼(), this.딟.땔(), 딢.딴.땄));
      if (obj0.땼().땻()[this.딟.땔()] is 딶.따)
        this.딟.Add((떑) new 땾(obj0.땼(), this.딟.땔(), 딢.딴.땄));
      if (!(obj0.땼().땻()[this.딟.땔()] is 딶.딾))
        return;
      this.딟.Add((떑) new 딺());
    }

    public void 딟([In] 딵 obj0)
    {
      if (this.딟)
      {
        this.딟 = 0.0f;
        if (this.딟 != null)
          this.딟.딟();
        this.딟.딟();
        this.딟 = new 딴();
        this.딟 = new 땀();
      }
      this.딟.Clear();
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index].딟(this, obj0);
      if (this.딟 != null)
        this.딟.딟();
      this.딟 = (딖) null;
      this.땄 = (딖) null;
    }

    public void 땄([In] 딵 obj0)
    {
      this.딟 = true;
      this.땄 = false;
      this.딧 = false;
      this.땃 = true;
      this.땥 = Random.Range(0, 딵.딧) >= obj0.땄;
      this.땓 = false;
      this.땺 = false;
    }

    public void 딟([In] 땜 obj0, [In] 땯 obj1)
    {
      this.딟.Clear();
      switch (obj0)
      {
        case 땜.딟:
          this.딟.Add((땁) new 땹(obj1.딟, obj1.딟, obj1.땄, obj1.땄, obj1.딟));
          break;
        case 땜.땄:
          this.딟.Add((땁) new 떔(obj1.딟, obj1.딟, obj1.딟));
          break;
        case 땜.딧:
          this.딟.Add((땁) new 땘(obj1.딟, obj1.딟, obj1.딟));
          break;
        case 땜.딢:
          this.딟.Add((땁) new 땷(obj1.딟, obj1.딟, obj1.딟));
          break;
        case 땜.땃:
          this.땃 = false;
          this.딟.Add((땁) new 땈(obj1.딟, obj1.딟));
          break;
        case 땜.딶:
          this.딟.Add((땁) new 땈(obj1.딟, obj1.딟));
          break;
        case 땜.땓:
          this.딟.Add((땁) new 땉(obj1.딟));
          break;
        case 땜.땺:
          this.땺 = true;
          this.딟.Add((땁) new 땈(obj1.딟, obj1.딟));
          break;
      }
    }

    public 땻 땄([In] 딶.딡 obj0)
    {
      땻 땻 = 땻.땄;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        땻 = 땻.땄;
        while (땻 == 땻.땄)
          땻 = this.딟[index].딟(obj0, this, obj0.땼().떂());
      }
      this.땄 |= obj0.땼().떂().땺()[this.딟.땔()].딢 == 0;
      this.딟.Clear();
      return 땻;
    }

    public bool 딟([In] 딶.땙 obj0, [In] bool obj1)
    {
      if (!this.딟.딟())
        this.딟 = true;
      땓.땊 땊 = obj0.땺()[this.딟.땔()];
      this.딟 = 땊.땃 != this.딟.딟 || 땊.딶 != this.딟.땄 || obj1 && 땊.딢 != this.딟.딧;
      return this.딟;
    }

    public int 딟([In] 딶.딡 obj0, [In] bool obj1)
    {
      땓.땊 땊 = obj0.땼().떂().땺()[this.딟.땔()];
      땓.딲 딲 = obj0.땼().땻()[this.딟.땔()];
      WeaponGameplayData weaponGameplayData = 딲.딢().딟(obj0.땼());
      return (!obj1 ? 땊.딢 : 딲.딟(땊)) / weaponGameplayData.RequiredActionPoints;
    }

    public bool 딧([In] 딶.딡 obj0)
    {
      if (!(obj0.땼().땻()[this.딟.땔()] is 땓.떀 떀))
        return false;
      return 떀.땄(딢.딴.때) || 떀.땄(딢.딴.땴);
    }

    public int 딟([In] GameTileComponent obj0, [In] ref int obj1)
    {
      obj1 = -1;
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if (Object.op_Equality((Object) obj0, (Object) this.딟[index]))
        {
          obj1 = index;
          return this.딟[index];
        }
      }
      return 딵.떎;
    }

    public bool 딟()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return false;
      return this.딟.Category == 땓.땍.딢 || this.딟.Category == 땓.땍.딶;
    }

    public void 딟([In] 딢.딴 obj0)
    {
      if (obj0 != 딢.딴.땻)
        return;
      this.땓 = true;
    }

    public bool 땄()
    {
      땓.땊 땊 = this.딟.땴();
      return 땊.딢(딢.떍.땓) > 0 || 땊.딢(딢.떍.떈) > 0 || 땊.딢(딢.떍.땔) > 0;
    }

    public bool 딟([In] 딶.땖 obj0, [In] 딢.딴 obj1)
    {
      땓.딲 딲 = obj0.땻()[this.딟.땔()];
      switch (obj1)
      {
        case 딢.딴.땋:
        case 딢.딴.딾:
          return 딲.떎();
        case 딢.딴.딗:
          return 딲.땭();
        case 딢.딴.떌:
          return 딲.땋();
        default:
          return true;
      }
    }

    public int 딟([In] GameTileComponent obj0, [In] 딶.땖 obj1)
    {
      if (!obj1.땻()[this.딟.땔()].땄(딢.딴.땔))
        return this.딟.땴().딟(obj0.TileIndexX, obj0.TileIndexY);
      if (this.딟 != null)
      {
        for (int index = 0; index < this.딟.Length; ++index)
        {
          if (obj0.TileIndexX == this.딟[index].TileIndexX && obj0.TileIndexY == this.딟[index].TileIndexY)
            return this.딟[index];
        }
      }
      return int.MaxValue;
    }
  }
}
