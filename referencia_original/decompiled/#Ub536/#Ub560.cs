// Decompiled with JetBrains decompiler
// Type: 딶.땠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땠
  {
    private int[] 딟;
    private int[] 땄;
    private int[] 딧;
    private int[] 딢;
    private int[] 땃;
    private 땠.딗[] 딟;
    private 땠.땻[] 딟;
    private BitArray 딟;
    private BitArray 땄;
    private List<땠.땻> 딟;
    private int 딟;
    private int 땄;
    private 땠.땴[] 딟;
    private List<땠.땳> 딟 = new List<땠.땳>();

    public 땠([In] GameGridComponent obj0)
    {
      this.딟 = obj0.SizeX;
      this.땄 = obj0.SizeY;
      this.딟 = new 땠.땴[this.딟 * this.땄];
      for (int index1 = 0; index1 < obj0.SizeY; ++index1)
      {
        for (int index2 = 0; index2 < obj0.SizeX; ++index2)
        {
          땠.땻 땻 = new 땠.땻(index2, index1, this.딟);
          this.딟[땻.딟()].딟 = (ushort) this.딟.Count;
          this.딟[땻.딟()].딟 = obj0.get_Tiles()[index2, index1];
          if (index1 > 0 && !obj0.get_Tiles()[index2, index1].SolidSouth && !obj0.get_Tiles()[index2, index1 - 1].SolidNorth)
          {
            땠.땳 땳;
            땳.딟 = new 땠.땻(index2, index1 - 1, this.딟);
            땳.딟 = 1;
            this.딟.Add(땳);
          }
          if (index1 < obj0.SizeY - 1 && !obj0.get_Tiles()[index2, index1].SolidNorth && !obj0.get_Tiles()[index2, index1 + 1].SolidSouth)
          {
            땠.땳 땳;
            땳.딟 = new 땠.땻(index2, index1 + 1, this.딟);
            땳.딟 = 1;
            this.딟.Add(땳);
          }
          if (index2 > 0 && !obj0.get_Tiles()[index2, index1].SolidWest && !obj0.get_Tiles()[index2 - 1, index1].SolidEast)
          {
            땠.땳 땳;
            땳.딟 = new 땠.땻(index2 - 1, index1, this.딟);
            땳.딟 = 1;
            this.딟.Add(땳);
          }
          if (index2 < obj0.SizeX - 1 && !obj0.get_Tiles()[index2, index1].SolidEast && !obj0.get_Tiles()[index2 + 1, index1].SolidWest)
          {
            땠.땳 땳;
            땳.딟 = new 땠.땻(index2 + 1, index1, this.딟);
            땳.딟 = 1;
            this.딟.Add(땳);
          }
          this.딟[땻.딟()].땄 = (ushort) ((uint) this.딟.Count - (uint) this.딟[땻.딟()].딟);
        }
      }
      this.딟 = new int[this.딟.Length];
      this.땄 = new int[this.딟.Length];
      this.딧 = new int[this.딟.Length];
      this.딢 = new int[this.딟.Length];
      this.땃 = new int[this.딟.Length];
      this.딟 = new 땠.땻[this.딟.Length];
      this.딟 = new 땠.딗[this.딟.Length];
      this.딟 = new BitArray(this.딟.Length);
      this.땄 = new BitArray(this.딟.Length);
      this.딟 = new List<땠.땻>();
    }

    private 땠.땻 딟([In] int[] obj0, [In] List<땠.땻> obj1)
    {
      int index1 = 0;
      int num1 = obj0[obj1[0].딟()];
      for (int index2 = 1; index2 < obj1.Count; ++index2)
      {
        int num2 = obj0[obj1[index2].딟()];
        if (num2 <= num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      땠.땻 땻 = obj1[index1];
      obj1[index1] = obj1[obj1.Count - 1];
      obj1.RemoveAt(obj1.Count - 1);
      return 땻;
    }

    private int 딟([In] 땠.땻 obj0, [In] 땠.땻 obj1)
    {
      int num1 = obj0.딟() / this.딟;
      int num2 = obj0.딟() - num1 * this.딟;
      int num3 = obj1.딟() / this.딟;
      return Mathf.Abs(obj1.딟() - num3 * this.딟 - num2) + Mathf.Abs(num3 - num1);
    }

    public List<GameTileComponent> 딟(
      [In] 땖 obj0,
      [In] 땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] 땓.딲 obj6)
    {
      return this.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, false);
    }

    public List<GameTileComponent> 딟(
      [In] 땖 obj0,
      [In] 땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] 땓.딲 obj6,
      [In] bool obj7)
    {
      if (obj2 == obj4 && obj3 == obj5)
        return new List<GameTileComponent>();
      땠.땻 땻1 = new 땠.땻(obj2, obj3, this.딟);
      땠.땻 땻2 = new 땠.땻(obj4, obj5, this.딟);
      List<땠.땻> 땻List = this.딟(obj0, obj1, 땻1, 땻2, obj6, obj7);
      if (땻List == null)
        return (List<GameTileComponent>) null;
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      gameTileComponentList.Capacity = 땻List.Count + 1;
      for (int index = 0; index < 땻List.Count; ++index)
        gameTileComponentList.Add(this.딟[땻List[index].딟()].딟);
      gameTileComponentList.Add(this.딟[땻2.딟()].딟);
      return gameTileComponentList;
    }

    private List<땠.땻> 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땠.땻 obj2, [In] 땠.땻 obj3, [In] 땓.딲 obj4, [In] bool obj5)
    {
      this.딟.SetAll(false);
      this.땄.SetAll(false);
      this.딟.Clear();
      this.딟.Add(obj2);
      this.땄.Set(obj2.딟(), true);
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index] = new 땠.땻(-1);
      this.딧[obj2.딟()] = 0;
      this.딢[obj2.딟()] = this.딟(obj2, obj3);
      this.땃[obj2.딟()] = this.딧[obj2.딟()] + this.딢[obj2.딟()];
      while (this.딟.Count > 0)
      {
        땠.땻 땻 = this.딟(this.땃, this.딟);
        if (땻.딟() == obj3.딟())
          return this.딟(this.딟, this.딟[obj3.딟()]);
        this.땄.Set(땻.딟(), false);
        this.딟.Set(땻.딟(), true);
        int 딟1 = (int) this.딟[땻.딟()].딟;
        int num1 = 딟1 + (int) this.딟[땻.딟()].땄;
        for (int index = 딟1; index < num1; ++index)
        {
          땠.땻 딟2 = this.딟[index].딟;
          if (!this.딟.Get(딟2.딟()))
          {
            GameTileComponent 딟3 = this.딟[딟2.딟()].딟;
            int num2 = obj0 == null || obj1 == null || obj4 == null ? 0 : obj0.땄(obj1, obj4.딟(), 딟3.TileIndexX, 딟3.TileIndexY, obj1.땺()[obj4.딟()].땄);
            if (obj3.딟() == 딟2.딟() && obj5)
              num2 = 0;
            if (num2 >= 0)
            {
              int num3 = this.딧[땻.딟()] + this.딟[index].딟 + num2;
              bool flag;
              if (!this.땄.Get(딟2.딟()))
              {
                this.딟.Add(딟2);
                this.땄.Set(딟2.딟(), true);
                flag = true;
              }
              else
                flag = num3 < this.딧[딟2.딟()];
              if (flag)
              {
                this.딟[딟2.딟()] = 땻;
                this.딧[딟2.딟()] = num3;
                this.딢[딟2.딟()] = this.딟(딟2, obj3);
                this.땃[딟2.딟()] = this.딧[딟2.딟()] + this.딢[딟2.딟()];
              }
            }
          }
        }
      }
      return (List<땠.땻>) null;
    }

    private List<땠.땻> 딟([In] 땠.땻[] obj0, [In] 땠.땻 obj1)
    {
      List<땠.땻> 땻List = obj0[obj1.딟()].딟() == -1 ? new List<땠.땻>() : this.딟(obj0, obj0[obj1.딟()]);
      땻List.Add(obj1);
      return 땻List;
    }

    public List<GameTileComponent> 딟([In] int obj0, [In] int obj1, [In] int obj2)
    {
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      Queue<땠.딗> 딗Queue = new Queue<땠.딗>();
      Array.Clear((Array) this.땄, 0, this.땄.Length);
      땠.딗 딗1;
      딗1.딟 = new 땠.땻(obj0, obj1, this.딟);
      딗1.딟 = obj2 + 1;
      this.딟(딗Queue, gameTileComponentList, 딗1);
      while (딗Queue.Count > 0)
      {
        땠.딗 딗2 = 딗Queue.Dequeue();
        if (this.땄[딗2.딟.딟()] == 딗2.딟)
        {
          GameTileComponent 딟 = this.딟[딗2.딟.딟()].딟;
          if (딟.TileIndexX > 0)
          {
            땠.딗 딗3;
            딗3.딟 = new 땠.땻(딟.TileIndexX - 1, 딟.TileIndexY, this.딟);
            딗3.딟 = 딗2.딟 - 1;
            this.딟(딗Queue, gameTileComponentList, 딗3);
          }
          if (딟.TileIndexY > 0)
          {
            땠.딗 딗4;
            딗4.딟 = new 땠.땻(딟.TileIndexX, 딟.TileIndexY - 1, this.딟);
            딗4.딟 = 딗2.딟 - 1;
            this.딟(딗Queue, gameTileComponentList, 딗4);
          }
          if (딟.TileIndexX < this.딟 - 1)
          {
            땠.딗 딗5;
            딗5.딟 = new 땠.땻(딟.TileIndexX + 1, 딟.TileIndexY, this.딟);
            딗5.딟 = 딗2.딟 - 1;
            this.딟(딗Queue, gameTileComponentList, 딗5);
          }
          if (딟.TileIndexY < this.땄 - 1)
          {
            땠.딗 딗6;
            딗6.딟 = new 땠.땻(딟.TileIndexX, 딟.TileIndexY + 1, this.딟);
            딗6.딟 = 딗2.딟 - 1;
            this.딟(딗Queue, gameTileComponentList, 딗6);
          }
        }
      }
      return gameTileComponentList;
    }

    private void 딟([In] Queue<땠.딗> obj0, [In] List<GameTileComponent> obj1, [In] 땠.딗 obj2)
    {
      if (obj2.딟 <= this.땄[obj2.딟.딟()])
        return;
      if (this.땄[obj2.딟.딟()] == 0)
        obj1.Add(this.딟[obj2.딟.딟()].딟);
      this.땄[obj2.딟.딟()] = obj2.딟;
      obj0.Enqueue(obj2);
    }

    public GameTileComponent[] 딟(
      [In] 땖 obj0,
      [In] 땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] 땓.딲 obj5,
      [In] int obj6,
      [In] int obj7)
    {
      this.땄(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
      GameTileComponent[] gameTileComponentArray;
      this.딟(obj7, obj4, out gameTileComponentArray, out int[] _);
      return gameTileComponentArray;
    }

    public void 딟(
      [In] 땖 obj0,
      [In] 땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] 땓.딲 obj5,
      [In] int obj6,
      [In] int obj7,
      out GameTileComponent[] _param9,
      out int[] _param10)
    {
      this.땄(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
      this.딟(obj7, obj4, out _param9, out _param10);
    }

    public GameTileComponent 딟(
      [In] 땖 obj0,
      [In] 땙 obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] 땓.딲 obj5,
      [In] int obj6)
    {
      this.땄(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
      List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
      this.딟(gameTileComponentList, obj0, obj1);
      return gameTileComponentList.Count > 0 ? gameTileComponentList[0] : (GameTileComponent) null;
    }

    private void 땄([In] 땖 obj0, [In] 땙 obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] 땓.딲 obj5, [In] int obj6)
    {
      땠.딗 딗1;
      딗1.딟 = new 땠.땻(obj2, obj3, this.딟);
      딗1.딟 = obj4 + 1;
      Array.Clear((Array) this.땄, 0, this.땄.Length);
      this.땄[딗1.딟.딟()] = 딗1.딟;
      if (obj6 != -1)
        this.딟(obj0, obj1, obj5, obj6);
      else
        Array.Clear((Array) this.딟, 0, this.딟.Length);
      int num1 = 0;
      int index1 = 0;
      this.딟[index1] = 딗1;
      int num2 = index1 + 1;
      while (num2 > 0)
      {
        땠.딗 딗2 = this.딟[num1 % this.딟.Length];
        ++num1;
        --num2;
        if (딗2.딟 > 1 && this.땄[딗2.딟.딟()] == 딗2.딟)
        {
          int 딟 = (int) this.딟[딗2.딟.딟()].딟;
          int num3 = 딟 + (int) this.딟[딗2.딟.딟()].땄;
          for (int index2 = 딟; index2 < num3; ++index2)
          {
            땠.딗 딗3;
            딗3.딟 = this.딟[index2].딟;
            딗3.딟 = 딗2.딟 - this.딟[index2].딟;
            int index3 = 딗3.딟.딟();
            if (this.딟[index3] >= 0 && 딗3.딟 > this.땄[index3])
            {
              this.땄[index3] = 딗3.딟;
              this.딟[(num1 + num2) % this.딟.Length] = 딗3;
              ++num2;
            }
          }
        }
      }
    }

    private void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.딲 obj2, [In] int obj3)
    {
      Array.Clear((Array) this.딟, 0, this.딟.Length);
      for (int index1 = 0; index1 < obj0.땻().Count; ++index1)
      {
        땓.땊 땊 = obj1.땺()[index1];
        if (땊.땓())
        {
          int index2 = new 땠.땻(땊.땃, 땊.딶, this.딟).딟();
          bool flag = obj0.땻()[index1].딟(땊, obj3);
          int num = obj0.땻()[index1].딟(obj1, obj2, obj3, obj0.땼(), flag);
          this.딟[index2] = num < 0 || this.딟[index2] == -1 ? -1 : Mathf.Max(this.딟[index2], num);
        }
      }
    }

    private void 딟([In] int obj0, [In] int obj1, out GameTileComponent[] _param3, out int[] _param4)
    {
      int length = 0;
      for (int index = 0; index < this.땄.Length; ++index)
      {
        if (this.땄[index] != 0)
        {
          if (obj0 != -1 && obj0 != obj1 - (this.땄[index] - 1))
            this.땄[index] = 0;
          else
            ++length;
        }
      }
      _param3 = new GameTileComponent[length];
      _param4 = new int[length];
      int index1 = 0;
      for (int index2 = 0; index2 < this.땄.Length; ++index2)
      {
        if (this.땄[index2] != 0)
        {
          _param3[index1] = this.딟[index2].딟;
          _param4[index1] = obj1 - (this.땄[index2] - 1);
          ++index1;
        }
      }
    }

    private void 딟([In] List<GameTileComponent> obj0, [In] 땖 obj1, [In] 땙 obj2)
    {
      int num = 0;
      int index1 = -1;
      for (int index2 = 0; index2 < this.땄.Length; ++index2)
      {
        땠.땴 땴 = this.딟[index2];
        if (this.땄[index2] != 0 && num <= this.땄[index2] && obj1.딟(obj2, new 땩(땴.딟.TileIndexX, 땴.딟.TileIndexY), -1, -1, false, false) == -1)
        {
          num = this.땄[index2];
          index1 = index2;
        }
      }
      if (index1 == -1)
        return;
      obj0.Add(this.딟[index1].딟);
    }

    private struct 땴
    {
      public ushort 딟;
      public ushort 땄;
      public GameTileComponent 딟;
    }

    private struct 딗
    {
      public 땠.땻 딟;
      public int 딟;
    }

    private struct 땳
    {
      public 땠.땻 딟;
      public int 딟;
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    private struct 땻
    {
      public 땻([In] int obj0) => this.딟(obj0);

      public 땻([In] int obj0, [In] int obj1, [In] int obj2) => this.딟(obj0 + obj1 * obj2);

      [CompilerGenerated]
      [SpecialName]
      public int 딟() => this.딟;
    }
  }
}
