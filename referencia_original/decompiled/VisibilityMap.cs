// Decompiled with JetBrains decompiler
// Type: VisibilityMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using 딶;

[Serializable]
public class VisibilityMap : MonoBehaviour
{
  private GameGridComponent 딟;
  [SerializeField]
  private List<VisBitArray> VisMap;

  public void Build(GameGridComponent Grid)
  {
    this.딟 = Grid;
    this.VisMap = new List<VisBitArray>();
    for (int StartY = 0; StartY < Grid.SizeY; ++StartY)
    {
      for (int StartX = 0; StartX < Grid.SizeX; ++StartX)
      {
        VisBitArray visBitArray = new VisBitArray();
        visBitArray.Bits = new List<int>(Grid.SizeX * Grid.SizeY / 32 + 1);
        this.FillVisArray(visBitArray.Bits, StartX, StartY);
        this.VisMap.Add(visBitArray);
      }
    }
  }

  private int GetArrayIndex(int X, int Y) => (Y * this.딟.SizeX + X) / 32;

  private void FillVisArray(List<int> VisArray, int StartX, int StartY)
  {
    for (int index1 = 0; index1 < this.딟.SizeY; ++index1)
    {
      for (int index2 = 0; index2 < this.딟.SizeX; ++index2)
      {
        int num1 = !this.딟.TestLineOfSight((땖) null, (땙) null, StartX, StartY, index2, index1, -1) ? 0 : 1;
        int arrayIndex = this.GetArrayIndex(index2, index1);
        int num2 = index1 * this.딟.SizeX + index2 - arrayIndex * 4 * 8;
        int num3 = num1 << num2;
        if (arrayIndex >= VisArray.Count)
        {
          VisArray.Add(num3);
        }
        else
        {
          List<int> intList;
          int index3;
          (intList = VisArray)[index3 = arrayIndex] = intList[index3] | num3;
        }
      }
    }
  }

  public void Setup(GameGridComponent Grid) => this.딟 = Grid;

  public bool TileIsVisible(
    땖 gameState,
    땙 turn,
    int teamIndex,
    int StartX,
    int StartY,
    int EndX,
    int EndY,
    int MaxRange,
    List<int> visBlockingTiles)
  {
    if (MaxRange > 0 && Mathf.Abs(EndX - StartX) + Mathf.Abs(EndY - StartY) > MaxRange)
      return false;
    int arrayIndex = this.GetArrayIndex(EndX, EndY);
    int num = 1 << EndY * this.딟.SizeX + EndX - arrayIndex * 4 * 8;
    return (this.VisMap[StartY * this.딟.SizeX + StartX].Bits[arrayIndex] & num) != 0 && this.딟.TestDynamicLineOfSight(gameState, turn, StartX, StartY, EndX, EndY, visBlockingTiles);
  }
}
