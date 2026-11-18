// Decompiled with JetBrains decompiler
// Type: GameGridComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Game/Grid")]
public class GameGridComponent : MonoBehaviour
{
  public int SizeX;
  public int SizeY;
  public Transform GameTilePrefab;
  public PlayerAchievement WinAchievement;
  public bool ShowCollision;
  public bool ShowHeight;
  public bool ShowSpawns;
  public bool ShowVis;
  public bool ShowControlPoints;
  public bool ShowAIDeployPoints;
  public bool ShowAttackableTiles;
  public int ShowAttackableTilesDistance = 20;
  public float CameraBorderSpringLength = 2f;
  public int CameraXMinPadding = 2;
  public int CameraXMaxPadding = 2;
  public int CameraYMinPadding = 2;
  public int CameraYMaxPadding = 2;
  private BitArray 딟;

  public Vector3 GetTileCentre(int x, int y) => this.GetTileCentre(x, y, this.get_Tiles()[x, y].Height);

  public Bounds GetTileBounds(int x, int y) => this.GetTileBounds(x, y, this.get_Tiles()[x, y].Height);

  public GameTileComponent GetTile(int x, int y) => x >= 0 && x < this.SizeX && y >= 0 && y < this.SizeY ? this.get_Tiles()[x, y] : (GameTileComponent) null;

  public bool TestLineOfSight(
    딶.땖 GameState,
    딶.땙 Turn,
    int StartX,
    int StartY,
    int EndX,
    int EndY,
    int Range)
  {
    if (Range > 0 && Mathf.Max(Mathf.Abs(EndX - StartX), Mathf.Abs(EndY - StartY)) > Range || this.get_Tiles()[EndX, EndY].VisBlocker)
      return false;
    Vector3 tileCentre1 = this.GetTileCentre(StartX, StartY);
    Vector3 tileCentre2 = this.GetTileCentre(EndX, EndY);
    Vector2 Start;
    // ISSUE: explicit constructor call
    ((Vector2) ref Start).\u002Ector((float) tileCentre1.x, (float) tileCentre1.z);
    Vector2 End;
    // ISSUE: explicit constructor call
    ((Vector2) ref End).\u002Ector((float) tileCentre2.x, (float) tileCentre2.z);
    Vector2 vector2 = Vector2.op_Subtraction(End, Start);
    float magnitude = ((Vector2) ref vector2).magnitude;
    ((Vector2) ref vector2).Normalize();
    GameTileComponent gameTileComponent1 = (GameTileComponent) null;
    List<int> intList = this.GatherBlockingTiles(GameState, Turn);
    bool flag = false;
    float num1 = 0.0f;
    while (!flag)
    {
      if ((double) num1 > (double) magnitude)
      {
        num1 = magnitude;
        flag = true;
      }
      GameTileComponent gameTileComponent2 = this.PickTile(Vector2.op_Addition(Start, Vector2.op_Multiply(vector2, num1)));
      if (Object.op_Inequality((Object) gameTileComponent1, (Object) gameTileComponent2))
      {
        gameTileComponent1 = gameTileComponent2;
        if (gameTileComponent2.VisBlocker || gameTileComponent2.BlocksLine(Start, End))
          return false;
        if (gameTileComponent2.TileIndexX == EndX && gameTileComponent2.TileIndexY == EndY)
          return true;
        if (intList != null)
        {
          int num2 = gameTileComponent2.TileIndexX + gameTileComponent2.TileIndexY * this.SizeX;
          if (intList.Contains(num2))
            return false;
        }
      }
      num1 += 0.25f;
    }
    return true;
  }

  public List<int> GatherBlockingTiles(딶.땖 GameState, 딶.땙 Turn)
  {
    List<int> intList = (List<int>) null;
    if (GameState != null && Turn != null)
    {
      int sizeX = GameState.땹().SizeX;
      for (int index = 0; index < Turn.땺().Count; ++index)
      {
        땓.땊 땊 = Turn.땺()[index];
        if (GameState.땻()[index].땄(땊))
        {
          if (intList == null)
            intList = new List<int>();
          intList.Add(땊.땃 + 땊.딶 * sizeX);
        }
      }
    }
    return intList;
  }

  public bool TestDynamicLineOfSight(
    딶.땖 GameState,
    딶.땙 Turn,
    int StartX,
    int StartY,
    int EndX,
    int EndY,
    List<int> visBlockingTiles)
  {
    Vector3 tileCentre1 = this.GetTileCentre(StartX, StartY);
    Vector3 tileCentre2 = this.GetTileCentre(EndX, EndY);
    Vector2 vector2_1;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2_1).\u002Ector((float) tileCentre1.x, (float) tileCentre1.z);
    Vector2 vector2_2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2_2).\u002Ector((float) tileCentre2.x, (float) tileCentre2.z);
    Vector2 vector2_3 = Vector2.op_Subtraction(vector2_2, vector2_1);
    float magnitude = ((Vector2) ref vector2_3).magnitude;
    ((Vector2) ref vector2_3).Normalize();
    GameTileComponent gameTileComponent1 = (GameTileComponent) null;
    bool flag = false;
    float num1 = 0.0f;
    while (!flag)
    {
      if ((double) num1 > (double) magnitude)
      {
        num1 = magnitude;
        flag = true;
      }
      GameTileComponent gameTileComponent2 = this.PickTile(Vector2.op_Addition(vector2_1, Vector2.op_Multiply(vector2_3, num1)));
      if (Object.op_Inequality((Object) gameTileComponent1, (Object) gameTileComponent2))
      {
        gameTileComponent1 = gameTileComponent2;
        if (gameTileComponent2.TileIndexX == EndX && gameTileComponent2.TileIndexY == EndY)
          return true;
        if (visBlockingTiles != null)
        {
          int num2 = gameTileComponent2.TileIndexX + gameTileComponent2.TileIndexY * this.SizeX;
          if (visBlockingTiles.Contains(num2))
            return false;
        }
      }
      num1 += 0.25f;
    }
    return true;
  }

  public GameTileComponent PickTile(Vector2 Position2D)
  {
    int index1 = Mathf.RoundToInt((float) (Position2D.x + (double) (this.SizeX - 1) * 0.5));
    int index2 = Mathf.RoundToInt((float) (Position2D.y + (double) (this.SizeY - 1) * 0.5));
    return index1 < 0 || index1 >= this.SizeX || index2 < 0 || index2 >= this.SizeY ? (GameTileComponent) null : this.get_Tiles()[index1, index2];
  }

  public Vector3 GetTileCentre(int x, int y, int z) => new Vector3((float) x - (float) (this.SizeX - 1) * 0.5f, (float) z * (1f / 32f), (float) y - (float) (this.SizeY - 1) * 0.5f);

  private Bounds GetTileBounds(int x, int y, int z) => new Bounds(this.GetTileCentre(x, y, z), new Vector3(1f, 2048f, 1f));

  public void Init() => this.InitCommon();

  public void InitCommon()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Tiles(new GameTileComponent[this.SizeX, this.SizeY]);
    GameTileComponent[] componentsInChildren = ((Component) this).GetComponentsInChildren<GameTileComponent>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
      this.get_Tiles()[componentsInChildren[index].TileIndexX, componentsInChildren[index].TileIndexY] = componentsInChildren[index];
    // ISSUE: reference to a compiler-generated method
    this.set_TileNetwork(new 딶.땠(this));
  }

  public void InitAI(GameObject BundleCoverMap, GameObject BundleVismap)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_CoverMap(BundleCoverMap.GetComponent<CoverMap>());
    this.get_CoverMap().Setup(this);
    // ISSUE: reference to a compiler-generated method
    this.set_VisMap(BundleVismap.GetComponent<VisibilityMap>());
    this.get_VisMap().Setup(this);
  }

  public void BuildVisMap(ref VisibilityMap BuiltVisMap)
  {
  }

  public void BuildCoverMap(ref CoverMap BuiltCoverMap)
  {
  }

  public 딶.딥 GetCoverType(int AttackerX, int AttackerY, int DefenderX, int DefenderY) => Object.op_Inequality((Object) this.get_CoverMap(), (Object) null) && this.get_CoverMap().IsValid() ? (딶.딥) this.get_CoverMap().GetCoverType(AttackerX, AttackerY, DefenderX, DefenderY) : this.get_Tiles()[DefenderX, DefenderY].GetCoverType(this.get_Tiles()[AttackerX, AttackerY]);

  public bool TileCanBeAttacked(GameTileComponent tile) => this.딟 == null || this.딟.Get(tile.TileIndexX + tile.TileIndexY * this.SizeX);

  public void SetUpNonAttackableTiles(GameTileComponent startTile, 딶.땖 gameState, 딶.땙 turn)
  {
    this.딟 = new BitArray(this.SizeX * this.SizeY);
    this.딟.SetAll(false);
    GameTileComponent[] gameTileComponentArray = this.get_TileNetwork().딟(gameState, turn, startTile.TileIndexX, startTile.TileIndexY, 100000, (땓.딲) null, -1, -1);
    for (int index = 0; index < gameTileComponentArray.Length; ++index)
      this.딟.Set(gameTileComponentArray[index].TileIndexX + gameTileComponentArray[index].TileIndexY * this.SizeX, true);
  }

  [CompilerGenerated]
  [SpecialName]
  public GameTileComponent[,] get_Tiles() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public 딶.땠 get_TileNetwork() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public VisibilityMap get_VisMap() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public CoverMap get_CoverMap() => this.딟;
}
