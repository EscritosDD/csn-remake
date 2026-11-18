// Decompiled with JetBrains decompiler
// Type: 딶.딠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딠 : IDisposable
  {
    public List<딠.딿> 딟 = new List<딠.딿>();
    public int 딟;
    public GameTileComponent 딟;
    public 딡 딟;

    public 딠([In] 딡 obj0) => this.딟 = obj0;

    public void 딟()
    {
      this.땺();
      if (!this.딟.땼().땼() && !this.딟.땼().떔().딶() && this.딟.땼().떔().떂())
      {
        땓.딟 timeline = new 땓.딟();
        timeline.딟((땏) new 딤(this.딟.땼().딝()));
        EventTimelineManager.딟().AddEventTimeline(timeline);
      }
      this.딟 = -1;
      List<땓.땊> 땊List = this.딟.땼().떎();
      List<땓.딲> 딲List = this.딟.땼().땻();
      for (int index = 0; index < 딲List.Count; ++index)
      {
        if (this.딟.땼().딝() == 땊List[index].땄 && 딲List[index].땺())
          this.딟.Add(new 딠.딿()
          {
            딟 = 딲List[index],
            딟 = index,
            땄 = this.딟.땼().딝(),
            딟 = 딢.딯.딟
          });
      }
      if (this.딟.땼().떔().딶())
        this.딟.땼().떔().딟(this.딟);
      else if (this.딟.땼().땼() || true)
        this.딢();
      if (!this.딶())
        return;
      this.땓();
    }

    public void Dispose()
    {
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟(index);
    }

    public void 딟([In] GameTileComponent obj0)
    {
      if (this.딟 == -1)
        return;
      int num = this.땄(obj0);
      if (num != -1)
        this.딟(num);
      if (num == this.딟)
        return;
      this.딟(this.딟);
      SpawnPointComponent component = ((Component) obj0).GetComponent<SpawnPointComponent>();
      if (Object.op_Inequality((Object) component, (Object) null))
        this.딟[this.딟].딟 = component.Direction;
      this.딟[this.딟].딟 = obj0;
      GameObject gameObject = new GameObject();
      gameObject.transform.position = ((Component) obj0).transform.position;
      int 땄 = this.딟[this.딟].땄;
      땓.떀 딟 = this.딟[this.딟].딟 as 땓.떀;
      UnitTesterComponent.딟(gameObject.transform, 딟.딣(), 딟.딛(), 딟.땷(), 딟.땔(), (Material) null, 딟.딛().딟((땖) null, 땓.딺.딟), 땄).localRotation = 땓.땊.딟(this.딟[this.딟].딟);
      this.딟[this.딟].딟 = gameObject;
    }

    public void 딟([In] int obj0)
    {
      if (!Object.op_Inequality((Object) this.딟[obj0].딟, (Object) null))
        return;
      Object.Destroy((Object) this.딟[obj0].딟);
      this.딟[obj0].딟 = (GameTileComponent) null;
    }

    public void 땄()
    {
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟(index);
    }

    public bool 딧() => this.딟 >= 0 && this.딟 < this.딟.Count && Object.op_Inequality((Object) this.딟[this.딟].딟, (Object) null);

    public int 땄([In] GameTileComponent obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (Object.op_Equality((Object) this.딟[index].딟, (Object) obj0))
          return index;
      }
      return -1;
    }

    public void 딢()
    {
      this.딟 = -1;
      while (!this.딶())
        this.딟(this, this.딟.땼().딝() != 0 ? 땂.땄 : 땂.딟);
    }

    private void 딟([In] 딠 obj0, [In] 땂 obj1)
    {
      ++obj0.딟;
      if (obj0.딧() || obj0.딟 >= obj0.딟.Count)
        return;
      GameTileComponent gameTileComponent1 = (GameTileComponent) null;
      int num = int.MaxValue;
      for (int index = 0; index < this.딟.땼().딳().Count; ++index)
      {
        GameTileComponent gameTileComponent2 = this.딟.땼().딳()[index];
        SpawnPointComponent component = ((Component) gameTileComponent2).GetComponent<SpawnPointComponent>();
        if (component.Team == obj1 && obj0.땄(gameTileComponent2) == -1 && component.get_DistanceToControlPoint() < num)
        {
          gameTileComponent1 = gameTileComponent2;
          num = component.get_DistanceToControlPoint();
        }
      }
      obj0.딟(gameTileComponent1);
    }

    private GameTileComponent 땃() => (GameTileComponent) null;

    [SpecialName]
    public bool 딶()
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (Object.op_Equality((Object) this.딟[index].딟, (Object) null))
          return false;
      }
      return true;
    }

    public void 땓()
    {
      if (!this.딶())
        return;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        딠.딿 딿 = this.딟[index];
        this.딟.딷().딟((땃.땧) new 땃.땬(딿.딟, 딿.딟.TileIndexX, 딿.딟.TileIndexY, 딿.딟));
        if (this.딟.땼().땼() || this.딟.땼().떔() is 딖)
          EventTimelineManager.딟().RunToEnd(true);
      }
      this.딟.딷().딟(딨.딢);
      if (this.딟.땼().떔().딶())
        this.딟.딷().땼();
      if (this.딟.땼().떔().떂())
        return;
      if (this.딟.땼().딝() == 0)
        this.딟.딟.MoveToSpawn(땂.딟);
      else
        this.딟.딟.MoveToSpawn(땂.땄);
    }

    private void 땺()
    {
      if (!(this.딟.땼().떔() is 딮 딮))
        return;
      땂 땂 = this.딟.땼().딝() != 0 ? 땂.땄 : 땂.딟;
      for (int index = 0; index < this.딟.땼().딳().Count; ++index)
      {
        GameTileComponent gameTileComponent = this.딟.땼().딳()[index];
        SpawnPointComponent component = ((Component) gameTileComponent).GetComponent<SpawnPointComponent>();
        if (Object.op_Inequality((Object) component, (Object) null) && component.Team == 땂)
        {
          int num = 땃.딺.딟(딮, this.딟, gameTileComponent, 1);
          component.set_DistanceToControlPoint(num);
        }
      }
    }

    public void 딧([In] GameTileComponent obj0)
    {
      for (int index = 0; index < this.딟.땼().딳().Count; ++index)
      {
        if (Object.op_Equality((Object) this.딟.땼().딳()[index], (Object) obj0))
        {
          int num = ((Component) this.딟.땼().딳()[index]).GetComponent<SpawnPointComponent>().Team != 땂.딟 ? 1 : 0;
          if (this.딟.땼().딝() == num)
          {
            this.딟(this.딟.땼().딳()[index]);
            this.딟 = -1;
          }
        }
      }
    }

    public class 딿
    {
      public 땓.딲 딟;
      public int 딟;
      public int 땄;
      public GameTileComponent 딟;
      public 딢.딯 딟;
      public GameObject 딟;
    }
  }
}
