// Decompiled with JetBrains decompiler
// Type: 땃.딵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딵
  {
    public int 딟;
    private 땏 딟 = new 땏();
    private 딜 딟 = new 딜();
    private 땐 딟 = new 땐();
    private 땗 딟 = new 땗();
    private 떅 딟 = new 떅();
    private 딫 딟 = new 딫();
    private 땡 딟 = new 땡();
    private 딪 딟 = new 딪();
    private 떕 딟 = new 떕();
    private 떆 딟 = new 떆();
    private 땙 딟 = new 땙();
    private List<딡> 딟;
    private int[] 딟 = new int[2];
    public List<GameObject> 딟;
    public float 딟;
    public List<딽> 딟;
    public int 땄;
    public static int 딧 = 10;
    public bool 딟;
    private List<int> 딟 = new List<int>();
    private int 딢;
    private int 땃;
    private int 딶;
    private int 땓;
    private int 땺;
    private int 땥;
    private bool 땄;
    private 땅 딟;
    private 딡 딟;
    private 떀 딟;
    public float 땄 = 0.015f;
    private bool 딧;
    private bool 딢;
    private bool 땃;
    private int 딝;
    public bool 딶;
    public static int 떎 = int.MaxValue;
    private int 떂 = 6;
    private int 땭 = 6;

    public 딵([In] 딶.딡 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      // ISSUE: reference to a compiler-generated method
      this.땄(new List<딡>());
      // ISSUE: reference to a compiler-generated method
      this.딧(new List<딡>());
      this.딟 = new List<딡>();
      this.딟 = new List<GameObject>();
      this.딟 = 떀.딟;
      this.딢 = 0;
      this.땃 = 0;
      this.딶 = 0;
      this.땓 = 0;
      this.땺 = 0;
      this.땥 = -1;
      this.땄 = true;
      this.딟 = 1;
      // ISSUE: reference to a compiler-generated method
      this.딟(new short[obj0.땓().SizeX, obj0.땓().SizeY, 딮.딟 + 3]);
    }

    public void 딟([In] 딶.딮 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new int[this.딣().땓().SizeX, this.딣().땓().SizeY]);
      for (int index1 = 0; index1 < this.딣().땓().SizeX; ++index1)
      {
        for (int index2 = 0; index2 < this.딣().땓().SizeY; ++index2)
          this.떔()[index1, index2] = int.MaxValue;
      }
      // ISSUE: reference to a compiler-generated method
      this.땄(new short[this.딣().땓().SizeX, this.딣().땓().SizeY]);
      int num = 0;
      int MaxRange = int.MaxValue;
      for (int index = 0; index < this.딣().땼().땻().Count; ++index)
      {
        if (this.딣().땼().땻()[index] is 딶.땕 땕1)
        {
          WeaponGameplayData weaponGameplayData = 땕1.딢().딟(this.딣().땼());
          if (weaponGameplayData.MaxRange < MaxRange)
            MaxRange = weaponGameplayData.MaxRange;
          if (weaponGameplayData.MinRange > num)
            num = weaponGameplayData.MinRange;
        }
      }
      for (int index3 = 0; index3 < obj0.딦().Count; ++index3)
      {
        GameTileComponent gameTileComponent1 = obj0.딦()[index3];
        GameTileComponent[] gameTileComponentArray;
        int[] numArray;
        this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY, 100000, (땓.딲) null, -1, -1, out gameTileComponentArray, out numArray);
        for (int index4 = 0; index4 < gameTileComponentArray.Length; ++index4)
        {
          GameTileComponent gameTileComponent2 = gameTileComponentArray[index4];
          if (numArray[index4] < this.떔()[gameTileComponent2.TileIndexX, gameTileComponent2.TileIndexY])
            this.떔()[gameTileComponent2.TileIndexX, gameTileComponent2.TileIndexY] = numArray[index4];
        }
      }
      List<int> visBlockingTiles = this.딣().땓().GatherBlockingTiles(this.딣().땼(), this.딣().땼().떂());
      for (int StartX = 0; StartX < this.딣().땓().SizeX; ++StartX)
      {
        for (int StartY = 0; StartY < this.딣().땓().SizeY; ++StartY)
        {
          for (int index = 0; index < obj0.딦().Count; ++index)
          {
            if (this.딣().땓().get_VisMap().TileIsVisible(this.딣().땼(), this.딣().땼().떂(), 1, StartX, StartY, obj0.딦()[index].TileIndexX, obj0.딦()[index].TileIndexY, MaxRange, visBlockingTiles))
              ++this.딳()[StartX, StartY];
          }
        }
      }
      this.땄(obj0);
    }

    private void 땄([In] 딶.딮 obj0)
    {
      this.딟 = new List<딽>();
      for (int index = 0; index < obj0.딦().Count; ++index)
      {
        GameTileComponent gameTileComponent1 = obj0.딦()[index];
        foreach (GameTileComponent gameTileComponent2 in this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY, 1, (땓.딲) null, -1, -1))
        {
          if (!this.딟(obj0, gameTileComponent2))
            this.딟.Add(new 딽(gameTileComponent2, gameTileComponent1));
        }
      }
    }

    private bool 딟([In] 딶.딮 obj0, [In] GameTileComponent obj1) => obj0.딦().Contains(obj1);

    public void 딟()
    {
      for (int index = 0; index < this.땔().Count; ++index)
        this.땔()[index].땄(this);
      for (int index = 0; index < this.땻(); ++index)
        this.땁()[index].딟 = true;
      this.땄();
      this.딧 = true;
      this.딢 = true;
      this.땃 = false;
      this.딟 = (딡) null;
      foreach (Object @object in this.딟)
        Object.Destroy(@object);
      this.딟.Clear();
      if (this.딶)
      {
        // ISSUE: reference to a compiler-generated method
        this.땄(true);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.땄(false);
      }
      this.딟.Clear();
    }

    public void 땄()
    {
      this.딟 = 떀.딟;
      this.딢 = 0;
      this.땃 = 0;
      this.딶 = 0;
      this.땓 = 0;
      this.땺 = 0;
      this.땥 = -1;
      this.땄 = true;
      this.딟 = new 땅();
    }

    public void 딧()
    {
      딶.땯 땯 = this.딣().딷();
      bool flag = false;
      for (int index = 0; index < 땯.떎(); ++index)
      {
        땓.땦 땦 = 땯.딟(index);
        if (땦.땴().땄 == this.딟)
        {
          if (this.딟(땦))
          {
            if (!this.땄(땦))
            {
              this.땥(new 딡(땦));
              flag = true;
            }
          }
          else
            flag |= this.딢(땦);
        }
        else if (this.땃(땦))
        {
          if (!this.딶(땦))
          {
            this.떎(new 딡(땦));
            flag = true;
          }
        }
        else
          flag |= this.땓(땦);
      }
      if (!flag)
        return;
      for (int index = 0; index < this.땔().Count; ++index)
        this.땔()[index].딟 = true;
      for (int index = 0; index < this.땻(); ++index)
        this.땁()[index].딟 = true;
    }

    private void 딢()
    {
      for (int index1 = 0; index1 < this.땔().Count; ++index1)
      {
        for (int index2 = 0; index2 < this.땔()[index1].땄.Count; ++index2)
          this.땔()[index1].딟.Add(this.땔()[index1].땄[index2]);
        this.땔()[index1].땄.Clear();
        for (int index3 = 0; index3 < this.땔()[index1].딟.Count; ++index3)
        {
          if (!this.땔()[index1].딟[index3].딟(this.딣().땼(), this.딣().땼().떂(), this.땔()[index1]))
          {
            this.땔()[index1].땄.Add(this.땔()[index1].딟[index3]);
            this.땔()[index1].딟.RemoveAt(index3);
          }
        }
      }
    }

    public bool 땃()
    {
      bool flag1;
      do
      {
        flag1 = false;
        switch (this.딟)
        {
          case 떀.딟:
            float realtimeSinceStartup1 = Time.realtimeSinceStartup;
            if (this.땄)
            {
              this.딝();
              this.땄 = false;
            }
            if (this.땺 != -1)
            {
              this.땺 = this.딟(this.땁(), true, this.땺, false);
              if (this.땺 == -1)
                this.땥 = 0;
            }
            if (this.땥 != -1)
            {
              if (this.딢)
              {
                Array.Clear((Array) this.땘(), 0, this.땘().Length);
                this.딢 = false;
              }
              this.땥 = this.딟(this.땔(), false, this.땥, true);
              if (this.땥 == -1)
              {
                this.떂();
                this.떎();
                this.딟 = 떀.딧;
                if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup1 < (double) this.땄 * 0.25)
                {
                  flag1 = true;
                  break;
                }
                break;
              }
              break;
            }
            break;
          case 떀.땄:
            if (this.땽())
            {
              this.땤();
              this.딟 = 떀.딢;
              break;
            }
            break;
          case 떀.딧:
            float realtimeSinceStartup2 = Time.realtimeSinceStartup;
            bool flag2 = true;
            if (this.딧)
              flag2 = this.땭();
            else if (this.땃)
              flag2 = this.딦();
            if (flag2)
            {
              this.딟 = 떀.땄;
              if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup2 < (double) this.땄 * 0.25)
              {
                flag1 = true;
                break;
              }
              break;
            }
            break;
        }
      }
      while (flag1);
      return this.딟 == 떀.딢;
    }

    public 땕 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] 땝 obj3)
    {
      int index1 = this.딧(obj0);
      딡 딡 = this.땔()[index1];
      int index2 = -1;
      GameTileComponent gameTileComponent = (GameTileComponent) null;
      switch (obj3)
      {
        case 땝.딟:
          index2 = 딡.딟.땓;
          if (index2 == -1)
            return (땕) null;
          gameTileComponent = 딡.딟[index2];
          break;
        case 땝.땄:
          gameTileComponent = 딡.딟.땄;
          index2 = 딡.딟.땄;
          break;
        case 땝.딧:
          gameTileComponent = 딡.딟.땄;
          index2 = 딡.딟.딟;
          break;
        case 땝.딢:
          gameTileComponent = 딡.딟[딡.딟.딟];
          index2 = 딡.딟.딟;
          break;
      }
      땕 땕 = new 땕();
      if (obj1 != -1)
        땕.딟 = this.땁()[obj1].딟.땔();
      땕.땄 = gameTileComponent.TileIndexX;
      땕.딧 = gameTileComponent.TileIndexY;
      땕.땓 = index2;
      return 땕;
    }

    private bool 딟([In] 딢.딴 obj0) => 땓.땎.딝(obj0) || obj0 == 딢.딴.땷 || obj0 == 딢.딴.땁 || obj0 == 딢.딴.딝 || obj0 == 딢.딴.떌 || obj0 == 딢.딴.땋 || obj0 == 딢.딴.떎;

    public 따 딟([In] int obj0, [In] bool obj1)
    {
      int index = this.딧(obj0);
      딡 딡 = this.땔()[index];
      따 따;
      if (this.딟(딡, obj1))
      {
        따 = 딡.딟;
      }
      else
      {
        List<딚> 딚List = this.땄(딡);
        딡.딟 = this.딟(딡, obj1, 딚List);
        따 = !this.딟(딡, 딡.딟.땴()) ? 딡.딟 : new 따(딡);
        if (딡.딟.딟 == -1)
          ;
      }
      return 따;
    }

    private bool 딟([In] 딡 obj0, [In] bool obj1) => false;

    private void 딟(
      [In] int obj0,
      [In] 딡 obj1,
      [In] 땓.땊 obj2,
      [In] int obj3,
      [In] 딩 obj4,
      [In] 땓.땊 obj5,
      [In] GameTileComponent obj6,
      [In] 딡 obj7,
      [In] WeaponGameplayData obj8,
      [In] int obj9,
      [In] int obj10,
      [In] int obj11,
      [In] bool obj12,
      [In] ref 따 obj13,
      [In] List<int> obj14)
    {
      int num1 = (int) 딲.딟(this.딣(), this, obj7, obj1, obj8, this.땁(), obj5, obj4, obj6, obj9, obj2, obj14);
      if (num1 == 0)
        return;
      int 땄 = obj4.땄;
      int num2 = obj7.딟[obj3] * obj7.땄;
      int num3 = obj5.딢 - num2 - obj8.RequiredActionPoints * obj9;
      bool flag1 = this.딟(obj7);
      if (flag1 && obj4.땄 > num3)
        return;
      GameTileComponent gameTileComponent;
      int num4;
      if (num3 == 0)
      {
        gameTileComponent = obj6;
        num4 = (int) this.땘()[obj6.TileIndexX, obj6.TileIndexY, 딮.딟];
      }
      else
        num4 = this.딟(num3, obj6, obj7.땄, obj5, out gameTileComponent);
      int num5 = num4 + obj11;
      if (obj12 && obj9 == obj10)
        num5 -= (int) this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, obj0];
      bool flag2 = num5 >= obj5.딧;
      if (!this.딸() && (!obj12 || obj9 != obj10) && flag2 && (!flag1 || this.딝 <= obj5.딧))
        return;
      float num6 = (float) num1 / Mathf.Max(1f, (float) num5);
      if (!this.딟(obj13, num6, 땄))
        return;
      obj13.딟 = obj0;
      obj13.딶 = num5;
      obj13.땃 = num1;
      obj13.땓 = obj3;
      obj13.땄 = obj9;
      obj13.딟 = obj12 && obj9 == obj10;
      obj13.딟 = num6;
      obj13.땺 = 땄;
      obj13.땥 = obj11;
      obj13.딝 = num3;
    }

    private bool 딟([In] 딡 obj0) => this.땷() == 땞.땄 && this.땓(obj0) && this.딶() == 1;

    private bool 딟([In] 딡 obj0, [In] 땓.땊 obj1, [In] GameTileComponent obj2, [In] int obj3)
    {
      bool flag = false;
      List<GameTileComponent> gameTileComponentList = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), obj1.땃, obj1.딶, obj2.TileIndexX, obj2.TileIndexY, this.딣().땼().땻()[obj1.땥()]);
      if (gameTileComponentList != null)
        flag = obj0.딟[obj3] * obj0.땄 == Math.Max(0, gameTileComponentList.Count - 1) * obj0.땄;
      return flag;
    }

    private 따 딟([In] 딡 obj0, [In] bool obj1, [In] List<딚> obj2)
    {
      따 따1 = new 따(obj0);
      따 따2 = new 따(obj0);
      땓.땊 땊1 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      WeaponGameplayData 딟 = obj0.딟;
      List<int> intList = this.딣().땼().땹().GatherBlockingTiles(this.딣().땼(), this.딣().땼().떂());
      bool flag = obj2.Count > 0;
      for (int index1 = 0; index1 < obj0.딟.Length; ++index1)
      {
        GameTileComponent gameTileComponent = obj0.딟[index1];
        if (!this.딟(this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊1, true) && (!obj1 || this.딟(obj0, 땊1, gameTileComponent, index1)))
        {
          int num1 = obj0.딟[index1] * obj0.땄;
          int num2 = (땊1.딢 - num1) / Mathf.Max(1, 딟.RequiredActionPoints);
          if (num2 != 0)
          {
            for (int index2 = 0; index2 < this.땻(); ++index2)
            {
              int index3 = this.딟(index2, obj2);
              if (!flag || index3 != -1)
              {
                따 따3 = !this.땁()[index2].딶 ? 따2 : 따1;
                int num3 = index3 == -1 ? -1 : obj2[index3].땄;
                땓.땊 땊2 = this.딣().땼().떎()[this.땁()[index2].딟.땔()];
                int num4 = this.딟(땊1, gameTileComponent, intList);
                for (int index4 = 1; index4 <= num2; ++index4)
                {
                  딩 딩 = obj0.딟[index1];
                  this.딟(index2, this.땁()[index2], 땊2, index1, 딩, 땊1, gameTileComponent, obj0, 딟, index4, num3, num4, flag, ref 따3, intList);
                }
              }
            }
          }
        }
      }
      return 따1.딟 != -1 ? 따1 : 따2;
    }

    private int 딟([In] int obj0, [In] List<딚> obj1)
    {
      for (int index = 0; index < obj1.Count; ++index)
      {
        if (obj1[index].딟 == obj0)
          return index;
      }
      return -1;
    }

    private int 딟(
      [In] int obj0,
      [In] GameTileComponent obj1,
      [In] int obj2,
      [In] 땓.땊 obj3,
      out GameTileComponent _param5)
    {
      GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), obj1.TileIndexX, obj1.TileIndexY, obj0 / obj2, this.딣().땼().땻()[obj3.땥()], obj3.땄, -1);
      int num = 0;
      int index = this.딟(gameTileComponentArray, out num);
      _param5 = index == -1 ? (GameTileComponent) null : gameTileComponentArray[index];
      return num;
    }

    public bool 딟([In] 딡 obj0, [In] 땓.땊 obj1) => false;

    public int 딟([In] GameTileComponent[] obj0, out int _param2)
    {
      _param2 = int.MaxValue;
      int num1 = -1;
      for (int index = 0; index < obj0.Length; ++index)
      {
        int num2 = (int) this.땘()[obj0[index].TileIndexX, obj0[index].TileIndexY, 딮.딟];
        if (num2 < _param2)
        {
          _param2 = num2;
          num1 = index;
        }
      }
      return num1;
    }

    private bool 딟([In] 따 obj0, [In] float obj1, [In] int obj2) => (double) obj1 > (double) obj0.딟;

    private int 딟([In] 땓.땊 obj0, [In] GameTileComponent obj1, [In] List<int> obj2)
    {
      if (this.딟.Count == 0)
        return 0;
      GameTileComponent gameTileComponent = this.딣().땓().get_Tiles()[obj0.땃, obj0.딶];
      if (Object.op_Equality((Object) gameTileComponent, (Object) obj1))
        return 0;
      float num1 = 0.0f;
      while (true)
      {
        int num2 = obj1.TileIndexX != gameTileComponent.TileIndexX ? (obj1.TileIndexX <= gameTileComponent.TileIndexX ? -1 : 1) : 0;
        int num3 = obj1.TileIndexY != gameTileComponent.TileIndexY ? (obj1.TileIndexY <= gameTileComponent.TileIndexY ? -1 : 1) : 0;
        float num4 = 0.0f;
        for (int index1 = 0; index1 < this.딟.Count; ++index1)
        {
          땓.땊 땊1 = this.딣().땼().떎()[this.딟[index1].딟.땔()];
          땓.딲 딲 = this.딣().땼().땻()[this.딟[index1].딟.땔()];
          if (딲.딟(땊1, false))
          {
            WeaponGameplayData weaponGameplayData = 딲.딢().딟(this.딣().땼());
            float num5 = (weaponGameplayData.딟(this.딣().땼().땞(), 땊1) + 0.5f * weaponGameplayData.DamageSpread) * (float) weaponGameplayData.ShotsPerAttack;
            int num6 = 땓.땊.딟(땊1.땃, 땊1.딶, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY);
            if (num6 >= weaponGameplayData.MinRange && num6 <= weaponGameplayData.MaxRange && this.딣().땓().get_VisMap().TileIsVisible(this.딣().땼(), this.딣().땼().떂(), 땊1.땄, 땊1.땃, 땊1.딶, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, weaponGameplayData.MaxRange, obj2))
            {
              if (weaponGameplayData.SplashRange > 0)
              {
                for (int index2 = 0; index2 < this.땔().Count; ++index2)
                {
                  땓.땊 땊2 = this.땔()[index2].딟.땴();
                  int num7 = 땊2 == obj0 ? 0 : 땊2.딟(gameTileComponent.TileIndexX, gameTileComponent.TileIndexY);
                  float num8 = weaponGameplayData.딟((float) num7 / (float) weaponGameplayData.SplashRange);
                  num4 += num5 * num8;
                }
                break;
              }
              num4 = num5 * 땫.딟(this.딣().땼(), weaponGameplayData, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊1.땃, 땊1.딶) * weaponGameplayData.딟(this.딣().땼(), 땊1.땃, 땊1.딶, gameTileComponent.TileIndexX, gameTileComponent.TileIndexY);
              break;
            }
          }
        }
        if ((double) num4 > (double) num1)
          num1 = num4;
        if (!Object.op_Equality((Object) gameTileComponent, (Object) obj1))
        {
          int index3 = gameTileComponent.TileIndexX + num2;
          int index4 = gameTileComponent.TileIndexY + num3;
          if (index3 >= 0 && index3 < this.딣().땓().SizeX && index4 >= 0 && index4 < this.딣().땓().SizeY)
            gameTileComponent = this.딣().땓().get_Tiles()[index3, index4];
          else
            break;
        }
        else
          break;
      }
      return (int) num1;
    }

    private List<딚> 땄([In] 딡 obj0)
    {
      bool flag = false;
      List<딚> 딚List = new List<딚>();
      for (int index1 = 0; index1 < this.땁().Count; ++index1)
      {
        int num1 = 0;
        int num2 = 0;
        for (int index2 = 0; index2 < this.땔().Count; ++index2)
        {
          int num3 = 0;
          for (int index3 = 0; index3 < 딾.딟; ++index3)
          {
            int 딟 = this.땔()[index2].딟.딟.딟[index1].딟[index3].딟;
            if (딟 > num3)
            {
              num3 = 딟;
              if (this.땔()[index2] == obj0)
                num2 = index3;
            }
          }
          if (this.땔()[index2] == obj0 && num3 == 0)
          {
            num1 = 0;
            break;
          }
          num1 += num3;
        }
        if (num1 != 0 && (!flag || this.땁()[index1].딶) && num1 >= this.땁()[index1].딟.땴().딧 && this.딧(this.땁()[index1]))
        {
          딚List.Add(new 딚() { 딟 = index1, 땄 = num2 });
          flag = this.땁()[index1].딶;
        }
      }
      if (flag)
      {
        for (int index = 0; index < 딚List.Count; ++index)
        {
          if (!this.땁()[딚List[index].딟].딶)
            딚List.RemoveAt(index);
        }
      }
      return 딚List;
    }

    private bool 딧([In] 딡 obj0)
    {
      if (!(this.딣().땼().땻()[obj0.딟.땔()] is 딶.땘))
        return true;
      땓.땊 땊1 = this.딣().땼().떎()[obj0.딟.땔()];
      for (int index = 0; index < this.땁().Count; ++index)
      {
        if (this.땁()[index] != obj0)
        {
          땓.땊 땊2 = this.딣().땼().떎()[this.땁()[index].딟.땔()];
          if (땓.땊.딟(땊1.땃, 땊1.딶, 땊2.땃, 땊2.딶) < this.떂 && this.딣().땼().땻()[this.땁()[index].딟.땔()].딱() - 땊2.딧 >= GlobalAppData.딢().떏().HealAmount)
            return true;
        }
      }
      return false;
    }

    private int 딟([In] int obj0)
    {
      int num1 = 0;
      int num2 = obj0;
      for (int index = 0; index < this.땔().Count; ++index)
      {
        땓.땊 땊 = this.딣().땼().떂().땺()[this.땔()[index].딟.땔()];
        if (num2 > 땊.딧)
        {
          num2 -= 땊.딧;
          ++num1;
        }
      }
      return num1;
    }

    public int 딟([In] int obj0, out int _param2)
    {
      int index1 = -1;
      int num1 = int.MaxValue;
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0];
      int index2 = this.딧(obj0);
      딡 딡 = this.땔()[index2];
      _param2 = this.떔()[땊.땃, 땊.딶];
      if (_param2 != 딵.떎)
        _param2 *= 딡.땄;
      for (int index3 = 0; index3 < 딡.딟.Length; ++index3)
      {
        GameTileComponent gameTileComponent = 딡.딟[index3];
        if (!this.딟(this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊, true) && (!딡.딟[4] || this.딟(딡, 땊, gameTileComponent, index3)) && 딡.딟[index3] * 딡.땄 <= 땊.딢)
        {
          bool flag = false;
          딩 딩 = 딡.딟[index3];
          short num2 = this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟];
          if (this.땷() == 땞.딟)
          {
            if (this.딟(_param2, num1, 딩, gameTileComponent))
              flag = this.딸() || (딡.딟 != 땪.딧 ? (double) num2 < (double) 땊.딧 * 0.5 : (double) num2 < (double) 땊.딧);
          }
          else if (this.땷() == 땞.땄 && this.딟(_param2, num1, 딩, gameTileComponent))
            flag = true;
          if (flag)
          {
            _param2 = 딩.땄;
            num1 = (int) num2;
            index1 = index3;
          }
        }
      }
      if (index1 != -1 && 땊.땃 == 딡.딟[index1].TileIndexX && 땊.딶 == 딡.딟[index1].TileIndexY)
        index1 = -1;
      return index1;
    }

    public void 딢([In] 딡 obj0)
    {
    }

    private bool 딟([In] int obj0, [In] int obj1, [In] 딩 obj2, [In] GameTileComponent obj3) => obj2.땄 < obj0 || obj2.땄 == obj0 && (int) this.땘()[obj3.TileIndexX, obj3.TileIndexY, 딮.딟] < obj1;

    public 딨 딟([In] int obj0, [In] int obj1)
    {
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0];
      int index1 = this.딧(obj0);
      딡 딡 = this.땔()[index1];
      딢.딴 딴 = !this.딣().땼().땻()[obj0].땄(딢.딴.때) ? 딢.딴.땴 : 딢.딴.때;
      int index2 = 떊.땄(this.딣().땼(), this.딣().땼().떂(), 딡.딟.땔(), 딴);
      if (index2 == -1)
        return (딨) null;
      딨 딨 = new 딨();
      int num1 = (int) ((double) obj1 * (double) this.딟);
      딶.땉 땉 = this.딣().땼().땻()[index2] as 딶.땉;
      for (int index3 = 0; index3 < 딡.딟.Length; ++index3)
      {
        GameTileComponent gameTileComponent1 = 딡.딟[index3];
        if (!this.딟(this.딣().땼().떂(), gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY, 땊, true))
        {
          int num2 = (int) this.딳()[gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY];
          if (this.땄(num2, num1))
          {
            int num3 = int.MaxValue;
            GameTileComponent gameTileComponent2 = (GameTileComponent) null;
            GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY, 땉.딝(), this.딣().땼().땻()[땊.땥()], 땊.땄, -1);
            for (int index4 = 0; index4 < gameTileComponentArray.Length; ++index4)
            {
              if (!this.딟(this.딣().땼().떂(), gameTileComponentArray[index4].TileIndexX, gameTileComponentArray[index4].TileIndexY, 땊, true))
              {
                int num4 = -1;
                int num5 = 딡.딟(gameTileComponentArray[index4], ref num4);
                if (num5 != 딵.떎)
                {
                  int num6 = num5 * 딡.땄;
                  bool flag = num6 <= 땊.딢 - 땉.땺();
                  if ((gameTileComponentArray[index4].TileIndexX != gameTileComponent1.TileIndexX || gameTileComponentArray[index4].TileIndexY != gameTileComponent1.TileIndexY) && flag && num6 < num3)
                  {
                    num3 = num6;
                    gameTileComponent2 = gameTileComponentArray[index4];
                  }
                }
              }
            }
            if (Object.op_Inequality((Object) gameTileComponent2, (Object) null))
            {
              num1 = num2;
              딨.딟 = index3;
              딨.딟 = gameTileComponent2;
            }
          }
        }
      }
      return 딨;
    }

    private bool 땄([In] int obj0, [In] int obj1)
    {
      if (obj0 > obj1)
        return true;
      return obj1 == obj0 && (double) this.딣().땼().떂().땓().딟(0.0f, 1f) < 0.5;
    }

    public 딨 땄([In] int obj0)
    {
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0];
      int index1 = this.딧(obj0);
      딡 딡 = this.땔()[index1];
      int index2 = 떊.땄(this.딣().땼(), this.딣().땼().떂(), 딡.딟.땔(), 딢.딴.딥);
      if (index2 == -1)
        return (딨) null;
      if (this.떔() == null)
        return (딨) null;
      딨 딨 = new 딨();
      int maxValue = int.MaxValue;
      int num1 = int.MaxValue;
      딶.땉 땉 = this.딣().땼().땻()[index2] as 딶.땉;
      for (int index3 = 0; index3 < 딡.딟.Length; ++index3)
      {
        GameTileComponent gameTileComponent = 딡.딟[index3];
        if (!this.딟(this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊, true))
        {
          int num2 = (int) this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟];
          int num3 = this.떔()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY];
          GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땉.딝(), this.딣().땼().땻()[땊.땥()], 땊.땄, -1);
          for (int index4 = 0; index4 < gameTileComponentArray.Length; ++index4)
          {
            if (!this.딟(this.딣().땼().떂(), gameTileComponentArray[index4].TileIndexX, gameTileComponentArray[index4].TileIndexY, 땊, true))
            {
              int num4 = -1;
              int num5 = 딡.딟(gameTileComponentArray[index4], ref num4);
              if (num5 != 딵.떎)
              {
                int num6 = num5 * 딡.땄;
                if (땊.딢 - 땉.땺() - num6 >= 0 && (gameTileComponentArray[index4].TileIndexX != gameTileComponent.TileIndexX || gameTileComponentArray[index4].TileIndexY != gameTileComponent.TileIndexY))
                {
                  int num7 = (int) this.땘()[gameTileComponentArray[index4].TileIndexX, gameTileComponentArray[index4].TileIndexY, 딮.딟];
                  if (num3 <= this.땭 && num7 < num1 && num2 < maxValue)
                  {
                    딨.딟 = index3;
                    딨.딟 = gameTileComponentArray[index4];
                    num1 = num7;
                    num2 = maxValue;
                  }
                }
              }
            }
          }
        }
      }
      return 딨;
    }

    private bool 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      int num = 6;
      if (obj0 > num)
        return false;
      if (obj1 < obj3)
        return true;
      return obj1 == obj3 && obj0 < obj2;
    }

    public GameTileComponent 땄([In] 딡 obj0, [In] bool obj1)
    {
      if (obj0.딟 == null || Object.op_Equality((Object) obj0.딟.땄, (Object) null) || Object.op_Equality((Object) obj0.딟.딟, (Object) null))
        return (GameTileComponent) null;
      if (this.땃(obj0))
        return (GameTileComponent) null;
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      if (this.딟(this.딣().땼().떂(), obj0.딟.땄.TileIndexX, obj0.딟.땄.TileIndexY, 땊, true) || obj1 && !this.딟(obj0, 땊, obj0.딟.땄, obj0.딟.땄))
        return (GameTileComponent) null;
      땓.딲 딲 = this.딣().땼().땻()[obj0.딟.땔()];
      if (!this.딟(obj0, 딲))
        return (GameTileComponent) null;
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(obj0.딟.딟, 딲);
      int num1 = obj0.딟[obj0.딟.땄] * obj0.땄;
      int num2 = 땊.딢 - num1 - weaponGameplayData.RequiredActionPoints;
      short maxValue = short.MaxValue;
      GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), obj0.딟.땄.TileIndexX, obj0.딟.땄.TileIndexY, num2, this.딣().땼().땻()[땊.땥()], 땊.땄, -1);
      for (int index = 0; index < gameTileComponentArray.Length; ++index)
      {
        if ((int) this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟] < (int) maxValue)
          maxValue = this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟];
      }
      return obj0.딟 != 땪.딶 && (int) maxValue >= 땊.딧 ? (GameTileComponent) null : obj0.딟.딟;
    }

    private bool 딟([In] 딡 obj0, [In] 땓.딲 obj1)
    {
      if (obj0.딟.딧 == -1)
        return false;
      AbilityGameplayData abilityGameplayData = GlobalAppData.딢().딟(obj0.딟.딟);
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(obj0.딟.딟, obj1);
      float num1 = 0.0f;
      GameTileComponent[] 딟 = obj0.딟[obj0.딟.딧].딟;
      if (weaponGameplayData.LineRange > 0)
      {
        for (int index = 0; index < 딟.Length - 1; ++index)
        {
          if (Object.op_Equality((Object) 딟[index], (Object) obj0.딟.땄))
          {
            num1 = 땾.딟(this, weaponGameplayData, abilityGameplayData, 딟[index], 딟[index + 1]);
            break;
          }
        }
      }
      else
      {
        땓.땊 땊 = this.딣().땼().떎()[obj0.딟.땔()];
        float num2 = (weaponGameplayData.딟(this.딣().땼().땞(), 땊) + weaponGameplayData.DamageSpread) * weaponGameplayData.Accuracy * (float) weaponGameplayData.ShotsPerAttack;
        int num3 = 0;
        num1 = 땾.딟(this, weaponGameplayData, abilityGameplayData, obj0.딟.딟, num2, obj0.딟.딟, ref num3);
      }
      return (double) num1 > 0.0;
    }

    private bool 땃([In] 딡 obj0)
    {
      int num1 = 0;
      int index1 = 0;
      int index2 = -1;
      for (int index3 = 0; index3 < this.땻(); ++index3)
      {
        for (int index4 = 0; index4 < 딾.딟; ++index4)
        {
          int 딟 = obj0.딟.딟.딟[index3].딟[index4].딟;
          if (딟 > num1)
          {
            num1 = 딟;
            index1 = index4;
            index2 = index3;
          }
        }
      }
      if (index1 > 0)
      {
        땓.딲 딲 = this.딣().땼().땻()[obj0.딟.땔()];
        WeaponGameplayData weaponGameplayData1 = 딲.딢().딟(this.딣().땼());
        int index5 = obj0.딟.딟[index2, index1];
        if (index5 != -1)
        {
          int num2 = obj0.딟[index5] * obj0.땄 + index1 * weaponGameplayData1.RequiredActionPoints;
          float num3 = (float) num1 / (float) num2;
          WeaponGameplayData weaponGameplayData2 = 땓.땎.딢(obj0.딟.딟, 딲).딟(this.딣().땼());
          int num4 = obj0.딟[obj0.딟.땄] * obj0.땄;
          float num5 = (float) obj0.딟.딟 / (float) (weaponGameplayData2.RequiredActionPoints + num4);
          return (double) num3 > (double) num5;
        }
      }
      return false;
    }

    public bool 딶([In] 딡 obj0)
    {
      bool flag = false;
      if (this.딣().땼().땻()[obj0.딟.땔()] is 땓.떀 떀)
      {
        for (int index = 0; index < 떀.떓().Count; ++index)
        {
          if (this.딟(떀.떓()[index]))
          {
            flag = true;
            break;
          }
        }
        for (int index = 0; index < 떀.땁().Abilities.Length; ++index)
        {
          if (this.딟(떀.땁().Abilities[index]))
          {
            flag = true;
            break;
          }
        }
      }
      return flag;
    }

    public GameTileComponent 딧([In] 딡 obj0, [In] bool obj1)
    {
      if (Object.op_Equality((Object) obj0.딟.땄, (Object) null) || obj0.딟.딟 == -1 || Object.op_Equality((Object) obj0.딟.딟, (Object) null))
        return (GameTileComponent) null;
      int 딟 = obj0.딟.딟;
      GameTileComponent gameTileComponent = obj0.딟[딟];
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      if (this.딟(this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 땊, true) || obj1 && !this.딟(obj0, 땊, gameTileComponent, 딟))
        return (GameTileComponent) null;
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(딢.딴.땳, this.딣().땼().땻()[obj0.딟.땔()]);
      int num1 = obj0.딟[딟] * obj0.땄;
      int num2 = 땊.딢 - num1 - weaponGameplayData.RequiredActionPoints;
      short maxValue = short.MaxValue;
      GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, num2, this.딣().땼().땻()[땊.땥()], 땊.땄, -1);
      for (int index = 0; index < gameTileComponentArray.Length; ++index)
      {
        if ((int) this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟] < (int) maxValue)
          maxValue = this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟];
      }
      return (int) maxValue >= 땊.딧 ? (GameTileComponent) null : obj0.딟.딟;
    }

    public GameTileComponent 딢([In] 딡 obj0, [In] bool obj1)
    {
      if (obj0.딟 == null || Object.op_Equality((Object) obj0.딟.땄, (Object) null) || Object.op_Equality((Object) obj0.딟.딟, (Object) null))
        return (GameTileComponent) null;
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      if (this.딟(this.딣().땼().떂(), obj0.딟.땄.TileIndexX, obj0.딟.땄.TileIndexY, 땊, true) || obj1 && !this.딟(obj0, 땊, obj0.딟.땄, obj0.딟.땄))
        return (GameTileComponent) null;
      땓.딲 딲 = this.딣().땼().땻()[obj0.딟.땔()];
      if (!this.땄(obj0, 딲))
        return (GameTileComponent) null;
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(obj0.딟.딟, 딲);
      int num1 = obj0.딟[obj0.딟.땄] * obj0.땄;
      int num2 = 땊.딢 - num1 - weaponGameplayData.RequiredActionPoints;
      short maxValue = short.MaxValue;
      GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), obj0.딟.땄.TileIndexX, obj0.딟.땄.TileIndexY, num2, this.딣().땼().땻()[땊.땥()], 땊.땄, -1);
      for (int index = 0; index < gameTileComponentArray.Length; ++index)
      {
        if ((int) this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟] < (int) maxValue)
          maxValue = this.땘()[gameTileComponentArray[index].TileIndexX, gameTileComponentArray[index].TileIndexY, 딮.딟];
      }
      return (int) maxValue >= 땊.딧 ? (GameTileComponent) null : obj0.딟.딟;
    }

    private bool 땄([In] 딡 obj0, [In] 땓.딲 obj1)
    {
      if (obj0.딟.딧 == -1)
        return false;
      AbilityGameplayData abilityGameplayData = GlobalAppData.딢().딟(obj0.딟.딟);
      WeaponGameplayData weaponGameplayData = 땓.땎.딧(obj0.딟.딟, obj1);
      int num1 = 0;
      double num2 = (double) 땾.딟(this, weaponGameplayData, abilityGameplayData, obj0.딟.딟, 0.0f, obj0.딟.딟, ref num1);
      return num1 > 0;
    }

    public int 딶() => this.딟(this.땔());

    public int 땓() => this.딟(this.땁());

    public int 딟([In] List<딡> obj0)
    {
      int num = 0;
      if (this.딣().땼().떔() is 딶.딮 딮)
      {
        for (int index = 0; index < obj0.Count; ++index)
        {
          if (this.딟(obj0[index], 딮))
            ++num;
        }
      }
      return num;
    }

    public bool 땓([In] 딡 obj0) => this.딣().땼().떔() is 딶.딮 딮 && this.딟(obj0, 딮);

    public bool 딟([In] 딡 obj0, [In] 딶.딮 obj1)
    {
      if (!(this.딣().땼().땻()[obj0.딟.땔()] is 땓.떀))
        return false;
      땓.땊 땊 = this.딣().땼().떎()[obj0.딟.땔()];
      for (int index = 0; index < obj1.딦().Count; ++index)
      {
        GameTileComponent gameTileComponent = obj1.딦()[index];
        if (땊.땃 == gameTileComponent.TileIndexX && 땊.딶 == gameTileComponent.TileIndexY)
          return true;
      }
      return false;
    }

    public bool 땺()
    {
      this.땩();
      if (this.딟.딟 == null || this.딟.딟.땄)
        this.딟 = this.딟(this.땷());
      bool flag = true;
      if (this.딟.딟)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(true);
        flag = false;
      }
      else if (this.딟.딟 != null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(true);
        if (this.딟.딟.땄(this.딣()) != 땃.땻.땄)
          flag = false;
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(false);
      }
      this.땳();
      return flag;
    }

    private 땅 딟([In] 땞 obj0)
    {
      땅 땅 = new 땅();
      딡 딡1 = (딡) null;
      if (딡1 == null)
      {
        딡 딡2 = this.땂();
        if (딡2 != null)
          딡1 = 딡2;
      }
      if (this.땄(obj0))
        딡1 = this.떏();
      if (딡1 == null || 딡1.땄 != null && 딡1.땄.딟 != null)
      {
        딡 딡3 = this.땲();
        if (딡3 != null)
          딡1 = 딡3;
      }
      if (this.땭(딡1))
      {
        딡 딡4 = this.땋();
        if (딡4 != null)
          딡1 = 딡4;
      }
      if (this.땭(딡1))
      {
        딡 딡5 = this.땢();
        if (딡5 != null)
          딡1 = 딡5;
      }
      if (this.땭(딡1))
      {
        딡 딡6 = this.딷();
        if (딡6 != null)
          딡1 = 딡6;
      }
      if (this.땭(딡1))
      {
        딡 딡7 = this.떁();
        if (딡7 != null)
          딡1 = 딡7;
      }
      if (this.땭(딡1))
      {
        딡 딡8 = this.딱();
        if (딡8 != null)
          딡1 = 딡8;
      }
      if (this.땭(딡1))
      {
        딡 딡9 = this.때();
        if (딡9 != null)
          딡1 = 딡9;
      }
      if (this.딟 == null && this.땭(딡1))
      {
        딡 딡10 = this.땟();
        if (딡10 != null)
        {
          딡1 = 딡10;
          if (!딡10.딢)
          {
            땅.딟 = true;
            this.딦(딡10);
          }
        }
      }
      if (딡1 == null)
        딡1 = this.떏();
      if (딡1 == null)
      {
        딡 딡11 = this.땼();
        if (딡11 != null)
        {
          딡1 = 딡11;
          딡1.땄 = true;
        }
      }
      땅.딟 = 딡1;
      return 땅;
    }

    public bool 땥()
    {
      for (int index = 0; index < this.땔().Count; ++index)
      {
        if (!this.땔()[index].땄 && !this.땔()[index].딧)
          return false;
      }
      return true;
    }

    public bool 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] 땓.땊 obj3, [In] bool obj4)
    {
      if (obj4 && obj3.땃 == obj1 && obj3.딶 == obj2)
        return false;
      if (this.딣().땼().땄(obj0, obj3.땥(), obj1, obj2, obj3.땄) < 0 || this.딣().땼().딟(obj0, obj3.땥(), obj1, obj2, obj3.땄, -1))
        return true;
      for (int index = 0; index < this.땻(); ++index)
      {
        if (this.땁()[index].딟.땴().땃 == obj1 && this.땁()[index].딟.땴().딶 == obj2)
          return true;
      }
      return false;
    }

    public void 딟([In] 딶.딡 obj0)
    {
    }

    private bool 땄([In] 땞 obj0) => obj0 == 땞.땄 && this.딶() == 0;

    private void 딝()
    {
      this.딢();
      for (int index = 0; index < this.땔().Count; ++index)
      {
        this.땔()[index].딟(this);
        this.땺(this.땔()[index]);
      }
      for (int index = 0; index < this.땻(); ++index)
        this.땺(this.땁()[index]);
    }

    private void 땺([In] 딡 obj0)
    {
      UnitWeapon unitWeapon = this.딣().땼().땻()[obj0.딟.땔()].딢();
      if (!Object.op_Inequality((Object) unitWeapon, (Object) null))
        return;
      WeaponGameplayData weaponGameplayData = unitWeapon.딟(this.딣().땼());
      obj0.딟 = weaponGameplayData;
    }

    private int 딟([In] List<딡> obj0, [In] bool obj1, [In] int obj2, [In] bool obj3)
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      for (int index = obj2; index < obj0.Count; ++index)
      {
        if (obj0[index].딟)
        {
          int num1 = 0;
          땓.땊 땊 = this.딣().땼().떂().땺()[obj0[index].딟.땔()];
          if (obj0[index].딟 != 땪.땃 && obj0[index].딟 != 땪.딶)
          {
            땓.딲 딲 = this.딣().땼().땻()[obj0[index].딟.땔()];
            if (obj1)
            {
              int num2 = !Object.op_Inequality((Object) obj0[index].딟, (Object) null) ? 0 : obj0[index].딟.RequiredActionPoints;
              num1 = 딲.딟(땊) - num2;
            }
            else
              num1 = 땊.딢;
          }
          this.딟(obj0[index], 땊, num1 / obj0[index].땄, obj3);
          if (index < obj0.Count - 1 && (double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄)
            return index + 1;
        }
      }
      return -1;
    }

    private void 딟([In] 딡 obj0, [In] 땓.땊 obj1, [In] int obj2, [In] bool obj3)
    {
      this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), obj1.땃, obj1.딶, obj2, this.딣().땼().땻()[obj1.땥()], obj1.땄, -1, out obj0.딟, out obj0.딟);
      if (!obj3)
        return;
      if (obj0.딟.Length > obj0.딟.Count)
      {
        int num = obj0.딟.Length - obj0.딟.Count;
        for (int index = 0; index < num; ++index)
          obj0.딟.Add(new 딩());
      }
      for (int index = 0; index < obj0.딟.Length; ++index)
        obj0.딟[index].딟();
      for (int index = 0; index < obj0.딟.Length; ++index)
      {
        GameTileComponent gameTileComponent = obj0.딟[index];
        this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟 + 1] = (short) -1;
      }
    }

    private void 떎()
    {
      if (!(this.딣().땼().떔() is 딶.딮 딮))
        return;
      for (int index = 0; index < 딮.딦().Count; ++index)
      {
        GameTileComponent gameTileComponent = 딮.딦()[index];
        this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟 + 1] = (short) -1;
      }
    }

    private void 떂()
    {
      for (int index = 0; index < this.땔().Count; ++index)
      {
        땓.땊 땊 = this.딣().땼().떂().땺()[this.땔()[index].딟.땔()];
        this.땔()[index].딟.딟 = 땊.땃;
        this.땔()[index].딟.땄 = 땊.딶;
        this.땔()[index].딟.딧 = 땊.딢;
      }
      for (int index = 0; index < this.땻(); ++index)
      {
        땓.땊 땊 = this.딣().땼().떂().땺()[this.땁()[index].딟.땔()];
        this.땁()[index].딟.딟 = 땊.땃;
        this.땁()[index].딟.땄 = 땊.딶;
        this.땁()[index].딟.딧 = 땊.딢;
      }
    }

    private bool 땭()
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      List<int> intList = this.딣().땼().땹().GatherBlockingTiles(this.딣().땼(), this.딣().땼().떂());
      for (int 땓 = this.땓; 땓 < this.딣().땓().SizeY; ++땓)
      {
        for (int 딶 = this.딶; 딶 < this.딣().땓().SizeX; ++딶)
        {
          GameTileComponent gameTileComponent = this.딣().땓().get_Tiles()[딶, 땓];
          if (this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟 + 1] < (short) 0)
            this.딟(gameTileComponent, intList);
          if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄)
          {
            this.땓 = 땓;
            if (딶 < this.딣().땓().SizeY - 1)
            {
              this.딶 = 딶 + 1;
              return false;
            }
          }
        }
        if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄 && 땓 < this.딣().땓().SizeX - 1)
        {
          this.땓 = 땓 + 1;
          return false;
        }
        this.딶 = 0;
      }
      this.딧 = false;
      return true;
    }

    private void 딟([In] GameTileComponent obj0, [In] List<int> obj1)
    {
      int tileIndexX1 = obj0.TileIndexX;
      int tileIndexY1 = obj0.TileIndexY;
      this.땘()[tileIndexX1, tileIndexY1, 딮.딟] = (short) 0;
      for (int index1 = 0; index1 < this.땻(); ++index1)
      {
        딡 딡 = this.땁()[index1];
        땓.땊 땊 = this.딣().땼().떂().땺()[딡.딟.땔()];
        땓.딲 딲 = this.딣().땼().땻()[딡.딟.땔()];
        WeaponGameplayData 딟 = 딡.딟;
        if (!Object.op_Equality((Object) 딟, (Object) null))
        {
          int num1 = 딲.딟(땊);
          if (땓.땊.딟(땊.땃, 땊.딶, tileIndexX1, tileIndexY1) <= 딟.MaxRange + (num1 - 딟.RequiredActionPoints) / 딡.땄)
          {
            int requiredActionPoints = 딟.RequiredActionPoints;
            int 땄 = 딡.땄;
            int minRange = 딟.MinRange;
            int maxRange = 딟.MaxRange;
            int num2 = 0;
            float num3 = 0.0f;
            for (int index2 = 0; index2 < 딡.딟.Length; ++index2)
            {
              GameTileComponent gameTileComponent = 딡.딟[index2];
              int tileIndexX2 = gameTileComponent.TileIndexX;
              int tileIndexY2 = gameTileComponent.TileIndexY;
              int num4 = 땓.땊.딟(tileIndexX2, tileIndexY2, tileIndexX1, tileIndexY1);
              if (num4 <= maxRange && num4 >= minRange)
              {
                int num5 = 딡.딟[index2] * 땄;
                int num6 = (num1 - num5) / Mathf.Max(requiredActionPoints, 1);
                if (num6 != 0 && (딟.IgnoreVisCheck || this.딣().땓().get_VisMap().TileIsVisible(this.딣().땼(), this.딣().땼().떂(), 0, tileIndexX2, tileIndexY2, tileIndexX1, tileIndexY1, 딟.MaxRange, obj1)))
                {
                  float num7 = 딲.딟(this.딣(), 딟, 땊, obj0, num6, tileIndexX2, tileIndexY2);
                  if ((double) num7 > (double) num3)
                  {
                    num3 = num7;
                    num2 = num6;
                  }
                }
              }
            }
            this.땘()[tileIndexX1, tileIndexY1, index1] = (short) num3;
            this.땘()[tileIndexX1, tileIndexY1, 딮.딟 + 2] += (short) num2;
            this.땘()[tileIndexX1, tileIndexY1, 딮.딟] += (short) num3;
          }
        }
      }
    }

    private bool 딦()
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      this.딟.Sort();
      for (int 땓 = this.땓; 땓 < this.딣().땓().SizeY; ++땓)
      {
        for (int 딶 = this.딶; 딶 < this.딣().땓().SizeX; ++딶)
        {
          GameTileComponent gameTileComponent = this.딣().땓().get_Tiles()[딶, 땓];
          if (this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟 + 1] < (short) 0)
          {
            for (int index1 = 0; index1 < this.딟.Count; ++index1)
            {
              int index2 = this.딟[index1];
              int num = (int) this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, index2];
              if (num > 0)
              {
                this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, index2] = (short) 0;
                this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟] -= (short) num;
              }
            }
            for (int index3 = this.딟.Count - 1; index3 >= 0; --index3)
            {
              for (int index4 = this.딟[index3]; index4 < this.땻() + this.딟.Count; ++index4)
                this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, index4] = this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, index4 + 1];
            }
          }
          if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄)
          {
            this.땓 = 땓;
            if (딶 < this.딣().땓().SizeY - 1)
            {
              this.딶 = 딶 + 1;
              return false;
            }
          }
        }
        if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄 && 땓 < this.딣().땓().SizeX - 1)
        {
          this.땓 = 땓 + 1;
          return false;
        }
        this.딶 = 0;
      }
      this.땃 = false;
      return true;
    }

    private void 땤()
    {
      this.딝 = int.MaxValue;
      if (!(this.딣().땼().떔() is 딶.딮 딮))
        return;
      for (int index = 0; index < 딮.딦().Count; ++index)
      {
        GameTileComponent gameTileComponent = 딮.딦()[index];
        if ((int) this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟] < this.딝)
          this.딝 = (int) this.땘()[gameTileComponent.TileIndexX, gameTileComponent.TileIndexY, 딮.딟];
      }
    }

    private bool 땽()
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      for (int 땃 = this.땃; 땃 < this.땔().Count; ++땃)
      {
        if (this.땔()[땃].딟)
        {
          if (!this.딟(this.땔()[땃], 땃))
          {
            this.땃 = 땃;
            return false;
          }
          if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄 && 땃 < this.땔().Count - 1)
          {
            this.땃 = 땃 + 1;
            return false;
          }
        }
      }
      this.땃 = 0;
      return true;
    }

    private bool 딟([In] 딡 obj0, [In] int obj1)
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      WeaponGameplayData 딟 = obj0.딟;
      땓.땊 땊 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      if (obj0.딟 == null)
        obj0.딟 = new 딠(this.딣(), this, this.딣().땼().떂(), obj0, 딟, 땊, obj0.땄, obj1, this.땁());
      else if (!obj0.딟.땄())
        obj0.딟.딟(this.딣(), this, this.딣().땼().떂(), obj0, 딟, 땊, obj0.땄, obj1, this.땁());
      for (int 딢 = this.딢; 딢 < obj0.딟.Length; ++딢)
      {
        int num = obj0.딟[딢] * obj0.땄;
        for (int index = 0; index < obj0.딟.Count; ++index)
          obj0.딟[index].딟(obj0.딟, obj0.딟[딢], obj0.딟[딢], num, 딢);
        if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup > (double) this.땄 && 딢 < obj0.딟.Length - 1)
        {
          this.딢 = 딢 + 1;
          return false;
        }
      }
      this.딢 = 0;
      return true;
    }

    private bool 딟([In] 땓.땦 obj0) => obj0.땴().땓() && obj0.땴().딧 > 0 && (this.딣().땼().땻()[obj0.땔()] is 땓.떀 || this.딣().땼().땻()[obj0.땔()] is 딶.딾 || this.딣().땼().땻()[obj0.땔()] is 딶.땕);

    private bool 땄([In] 땓.땦 obj0) => this.딧(obj0) != -1;

    public int 딧([In] 땓.땦 obj0) => this.딧(obj0.땔());

    public int 딧([In] int obj0)
    {
      for (int index = 0; index < this.땔().Count; ++index)
      {
        if (this.땔()[index].딟.땔() == obj0)
          return index;
      }
      return -1;
    }

    private bool 딢([In] 땓.땦 obj0)
    {
      int index = this.딧(obj0);
      if (index == -1)
        return false;
      this.땔().RemoveAt(index);
      return true;
    }

    private void 땥([In] 딡 obj0)
    {
      obj0.딟(this.딣());
      this.딝(obj0);
      this.땔().Add(obj0);
      땓.딲 딲 = this.딣().땼().땻()[obj0.딟.땔()];
      obj0.땄 = 딲.땥();
      int num1 = 0;
      int num2 = 딲.딟(obj0.딟.땴()) / obj0.땄;
      for (int index = 0; index <= num2; ++index)
        num1 += index;
      int capacity = num1 * 4 + 1;
      obj0.딟 = new List<딩>(capacity);
      for (int index = 0; index < obj0.딟.Capacity; ++index)
        obj0.딟.Add(new 딩());
      obj0.땥 = Random.Range(0, 딵.딧) >= this.땄;
    }

    private void 딝([In] 딡 obj0)
    {
      if (this.딣().땼().땻()[obj0.딟.땔()] is 땓.떀 떀)
      {
        땓.땅 classType = 떀.땁().ClassType;
        UnitBodyType unitBodyType = 떀.땷();
        switch (classType)
        {
          case 땓.땅.땄:
            obj0.딟 = 땪.땄;
            break;
          case 땓.땅.땃:
            obj0.딟 = 땪.딟;
            break;
          default:
            int num1 = 0;
            int num2 = int.MaxValue;
            foreach (UnitBodyType bodyType in GlobalAppData.딟.BodyTypes)
            {
              if (bodyType.MaxHealth > num1)
                num1 = bodyType.MaxHealth;
              if (bodyType.MaxHealth < num2)
                num2 = bodyType.MaxHealth;
            }
            obj0.딟 = unitBodyType.MaxHealth != num1 ? 땪.딢 : 땪.딧;
            break;
        }
      }
      if (this.딣().땼().땻()[obj0.딟.땔()] is 딶.딚)
        obj0.딟 = 땪.땃;
      if (this.딣().땼().땻()[obj0.딟.땔()] is 딶.따)
        obj0.딟 = 땪.딶;
      if (!(this.딣().땼().땻()[obj0.딟.땔()] is 딶.딾))
        return;
      obj0.딟 = 땪.땓;
    }

    private void 떎([In] 딡 obj0)
    {
      땓.딲 딲 = this.딣().땼().땻()[obj0.딟.땔()];
      if (!딲.땽())
        return;
      this.딧 = true;
      this.딢 = true;
      this.땃 = false;
      this.딝(obj0);
      this.땁().Add(obj0);
      obj0.땄 = 딲.땥();
      if (딲 is 딶.땕)
        this.딟.Add(obj0);
      if (딲 is 딶.땘)
        return;
      obj0.딶 = true;
    }

    private bool 땃([In] 땓.땦 obj0) => obj0.땴().땓() && obj0.땴().딧 > 0 && this.딣().땼().땻()[obj0.땔()].땽() && this.딣().땼().딟(this.딣().땼().떂(), obj0.땔(), obj0.땴().땃, obj0.땴().딶, this.딟, false);

    private bool 딶([In] 땓.땦 obj0)
    {
      for (int index = 0; index < this.땻(); ++index)
      {
        if (this.땁()[index].딟 == obj0)
          return true;
      }
      return false;
    }

    private bool 땓([In] 땓.땦 obj0)
    {
      bool flag = false;
      for (int index = 0; index < this.땻(); ++index)
      {
        if (this.땁()[index].딟 == obj0)
        {
          this.땃 = true;
          this.땁().RemoveAt(index);
          flag = true;
          this.딟.Add(index);
          break;
        }
      }
      return flag;
    }

    private 딡 땋() => this.딟.딟(this);

    private 딡 땲() => this.딟.딟(this);

    private 딡 떏() => this.딟.딟(this);

    private 딡 땼() => this.딟.딟(this);

    private 딡 땢() => this.딟.딟(this);

    private 딡 딷() => this.딟.딟(this);

    private 딡 떁() => this.딟.딟(this);

    private 딡 땟() => this.딟.딟(this);

    private 딡 땂() => this.딟.딟(this);

    private 딡 딱() => this.딟.딟(this);

    private 딡 때() => this.딟.딟(this);

    private void 땩()
    {
      this.딟[0] = this.땴();
      this.딟[1] = this.딗();
      // ISSUE: reference to a compiler-generated method
      this.딧(this.땠());
    }

    private 땞 땠()
    {
      땞 땞 = 땞.딧;
      int num = -1;
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if (this.딟[index] > num)
        {
          num = this.딟[index];
          땞 = (땞) index;
        }
      }
      return 땞;
    }

    private int 땴() => 100;

    private int 딗()
    {
      int num1 = 50;
      int num2 = this.딣().떁().딢();
      if (this.딣().떁().딧(this.딟 != 0 ? 0 : 1) >= num2 - 3)
        num1 = 150;
      return num1;
    }

    private void 땳()
    {
      bool flag = false;
      for (int index = 0; index < this.땻(); ++index)
        flag |= this.땁()[index].딟(this.딣().땼().떂(), false);
      for (int index = 0; index < this.땔().Count; ++index)
      {
        딡 딡 = this.땔()[index];
        딡.땄 = ((딡.땄 ? 1 : 0) | (this.딛() ? 0 : (!this.땔()[index].딧 ? 1 : 0))) != 0;
        if (flag)
          this.땔()[index].딟 = true;
        else
          this.땔()[index].딟(this.딣().땼().떂(), true);
      }
    }

    public 땇 딟([In] 딡 obj0, [In] 딢.딴 obj1)
    {
      땓.땊 땊1 = this.딣().땼().떂().땺()[obj0.딟.땔()];
      int index1 = 딶.딢.딟(this.딣().땼(), this.딣().땼().떂(), obj0.딟.땔(), obj1);
      if (index1 == -1)
        return (땇) null;
      딶.땚 땚 = this.딣().땼().땻()[index1] as 딶.땚;
      땇 땇 = new 땇();
      int num1 = int.MaxValue;
      for (int index2 = 0; index2 < this.땔().Count; ++index2)
      {
        땓.딲 딲 = this.딣().땼().땻()[this.땔()[index2].딟.땔()];
        땓.땊 땊2 = this.딣().땼().떂().땺()[this.땔()[index2].딟.땔()];
        if (딲.딝() && 땚.딟(this.딣().땼().떂(), this.땔()[index2].딟.땔()) && 땊2.딧 < 딲.딱() - this.딣().땼().땞().딟(딢.딴.떏).HealAmount && 땊2.딧 < num1)
        {
          int num2 = int.MaxValue;
          int index3 = -1;
          GameTileComponent[] gameTileComponentArray = this.딣().땓().get_TileNetwork().딟(this.딣().땼(), this.딣().땼().떂(), 땊2.땃, 땊2.딶, this.딣().땼().땞().땃().MaxRange, this.딣().땼().땻()[땊1.땥()], 땊1.땄, -1);
          for (int index4 = 0; index4 < gameTileComponentArray.Length; ++index4)
          {
            if (!this.딟(this.딣().땼().떂(), gameTileComponentArray[index4].TileIndexX, gameTileComponentArray[index4].TileIndexY, 땊1, true))
            {
              int num3 = -1;
              int num4 = obj0.딟(gameTileComponentArray[index4], ref num3);
              if (num4 != 딵.떎)
              {
                int num5 = num4 * obj0.땄;
                if (num5 <= 땊1.딢 - 땚.땃() && num5 < num2)
                {
                  num2 = num5;
                  index3 = index4;
                }
              }
            }
          }
          if (index3 != -1)
          {
            num1 = 땊2.딧;
            땇.딟 = gameTileComponentArray[index3];
            땇.딟 = this.땔()[index2];
          }
        }
      }
      return 땇;
    }

    [SpecialName]
    public int 땻() => Mathf.Min(this.땁().Count, 딮.딟);

    public string 딟([In] int obj0, [In] List<딡> obj1) => obj0 < 0 ? (string) null : this.떂(obj1[obj0]);

    public string 떂([In] 딡 obj0)
    {
      int index = obj0.딟.땔();
      string str = index.ToString() + " - ";
      땓.딲 딲 = this.딣().땼().땻()[index];
      return !(딲 is 땓.떀 떀) ? str + 딲.ToString() : str + 떀.땁().ClassType.ToString();
    }

    private bool 땭([In] 딡 obj0) => obj0 == null || obj0.딟 != null && (obj0.딟 == null || obj0.딟.딟 != -1) && !obj0.딟.딟;

    private void 딦([In] 딡 obj0)
    {
      this.딟 = obj0;
      obj0.딧 = true;
      obj0.딢 = false;
    }

    public void 딥()
    {
      if (this.딟 == null)
        return;
      this.딟.딢 = true;
      this.딟.딧 = false;
      this.딟 = (딡) null;
    }

    public bool 떓() => this.딟 != null;

    [CompilerGenerated]
    [SpecialName]
    public bool 딛() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public 딶.딡 딣() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딡> 땔() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public List<딡> 땁() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public 땞 땷() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 딸() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public short[,,] 땘() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int[,] 떔() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public short[,] 딳() => this.딟;
  }
}
