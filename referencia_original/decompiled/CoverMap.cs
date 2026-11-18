// Decompiled with JetBrains decompiler
// Type: CoverMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class CoverMap : MonoBehaviour
{
  private int 딟 = 2;
  private GameGridComponent 딟;
  [SerializeField]
  private List<CoverArray> CoverData;

  public bool Build(GameGridComponent Grid)
  {
    this.Setup(Grid);
    this.CoverData = new List<CoverArray>();
    for (int StartY = 0; StartY < Grid.SizeY; ++StartY)
    {
      for (int StartX = 0; StartX < Grid.SizeX; ++StartX)
      {
        CoverArray coverArray = new CoverArray();
        coverArray.Bits = new List<int>(Grid.SizeX * Grid.SizeY / (32 / this.딟) + 1);
        this.FillCoverArray(coverArray.Bits, StartX, StartY);
        this.CoverData.Add(coverArray);
      }
    }
    return true;
  }

  public bool IsValid() => this.CoverData != null && this.CoverData.Count > 0;

  private int GetArrayIndex(int X, int Y) => (Y * this.딟.SizeX + X) / (32 / this.딟);

  private int GetStartOfCellOffset(int ArrayIndex) => ArrayIndex * 4 * 8 / this.딟;

  private int GetAmountToShift(int x, int y, int ArrayIndex) => (y * this.딟.SizeX + x - this.GetStartOfCellOffset(ArrayIndex)) * this.딟;

  private void FillCoverArray(List<int> CostArray, int StartX, int StartY)
  {
    for (int index1 = 0; index1 < this.딟.SizeY; ++index1)
    {
      for (int index2 = 0; index2 < this.딟.SizeX; ++index2)
      {
        int arrayIndex = this.GetArrayIndex(index2, index1);
        int amountToShift = this.GetAmountToShift(index2, index1, arrayIndex);
        int num = (int) this.딟.get_Tiles()[index2, index1].GetCoverType(this.딟.get_Tiles()[StartX, StartY]) << amountToShift;
        if (arrayIndex >= CostArray.Count)
        {
          CostArray.Add(num);
        }
        else
        {
          List<int> intList;
          int index3;
          (intList = CostArray)[index3 = arrayIndex] = intList[index3] | num;
        }
      }
    }
  }

  public void Setup(GameGridComponent Grid)
  {
    this.딟 = Grid;
    // ISSUE: reference to a compiler-generated method
    this.set_MaxValue((1 << this.딟) - 1);
  }

  public int GetCoverType(int AttackerX, int AttackerY, int DefenderX, int DefenderY)
  {
    int arrayIndex = this.GetArrayIndex(DefenderX, DefenderY);
    int amountToShift = this.GetAmountToShift(DefenderX, DefenderY, arrayIndex);
    uint num = (uint) (this.get_MaxValue() << amountToShift);
    return (int) (((uint) this.CoverData[AttackerY * this.딟.SizeX + AttackerX].Bits[arrayIndex] & num) >> amountToShift);
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_MaxValue() => this.땄;
}
