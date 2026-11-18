// Decompiled with JetBrains decompiler
// Type: GameTileComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Game/Tile")]
public class GameTileComponent : MonoBehaviour
{
  public bool SolidWest;
  public bool SolidEast;
  public bool SolidNorth;
  public bool SolidSouth;
  public bool VisBlocker;
  public 딶.딥 WestCover;
  public 딶.딥 EastCover;
  public 딶.딥 NorthCover;
  public 딶.딥 SouthCover;
  public bool DisableGizmos;
  public int TileIndexX;
  public int TileIndexY;
  public int Height;
  private float 딟 = -1f;

  private void Start()
  {
    if (!Application.isPlaying)
      return;
    BoxCollider boxCollider = ((Component) this).gameObject.AddComponent<BoxCollider>();
    boxCollider.center = new Vector3(0.0f, -0.005f, 0.0f);
    boxCollider.size = new Vector3(1f, 0.01f, 1f);
    ((Object) boxCollider).hideFlags = (HideFlags) 13;
    ((Component) this).transform.position = ((Component) ((Component) this).transform.parent).GetComponent<GameGridComponent>().GetTileCentre(this.TileIndexX, this.TileIndexY, this.Height);
  }

  public void OnHoldStart()
  {
    땓.땦 unitOnTile = this.GetUnitOnTile(딢.딴.딟);
    if (unitOnTile == null)
      return;
    딶.딡.땴().딟(unitOnTile);
  }

  public void OnHoldStop()
  {
    땓.땦 unitOnTile = this.GetUnitOnTile(딢.딴.딟);
    if (unitOnTile == null)
      return;
    딶.딡.땴().땄(unitOnTile);
  }

  public 땓.땦 GetUnitOnTile(딢.딴 selectedAbility)
  {
    딶.땯 땯 = 딶.딡.땴().딷();
    if (땯 != null)
    {
      int num = 딶.딡.땴().땼().딟(딶.딡.땴().땼().떂(), this.TileIndexX, this.TileIndexY, -1, selectedAbility);
      if (num != -1)
        return 땯.딟(num);
    }
    return (땓.땦) null;
  }

  private void OnClicked()
  {
    if ((double) this.딟 > 0.0 && (double) Time.time - (double) this.딟 < 0.400000005960464)
    {
      this.OnDoubleClicked();
      this.딟 = -1f;
    }
    else
    {
      this.딟 = Time.time;
      딶.딡.땴().딟(this);
    }
  }

  private void OnDoubleClicked() => 딶.딡.땴().땄(this);

  public 딶.딥 GetCoverType(GameTileComponent AttackerTile)
  {
    GameGridComponent component = ((Component) ((Component) this).transform.parent).GetComponent<GameGridComponent>();
    GameTileComponent gameTileComponent1 = component.get_Tiles()[Mathf.Clamp(this.TileIndexX - 1, 0, component.SizeX - 1), this.TileIndexY];
    GameTileComponent gameTileComponent2 = component.get_Tiles()[Mathf.Clamp(this.TileIndexX + 1, 0, component.SizeX - 1), this.TileIndexY];
    GameTileComponent gameTileComponent3 = component.get_Tiles()[this.TileIndexX, Mathf.Clamp(this.TileIndexY + 1, 0, component.SizeY - 1)];
    GameTileComponent gameTileComponent4 = component.get_Tiles()[this.TileIndexX, Mathf.Clamp(this.TileIndexY - 1, 0, component.SizeY - 1)];
    if (this.WestCover == 딶.딥.딟 && this.NorthCover == 딶.딥.딟 && this.SouthCover == 딶.딥.딟 && this.EastCover == 딶.딥.딟 && gameTileComponent1.EastCover == 딶.딥.딟 && gameTileComponent2.WestCover == 딶.딥.딟 && gameTileComponent3.SouthCover == 딶.딥.딟 && gameTileComponent4.NorthCover == 딶.딥.딟)
      return 딶.딥.딟;
    Vector3 position1 = ((Component) this).transform.position;
    Vector2 Line1End;
    // ISSUE: explicit constructor call
    ((Vector2) ref Line1End).\u002Ector((float) position1.x, (float) position1.z);
    Vector3 position2 = ((Component) AttackerTile).transform.position;
    Vector2 Line1Start;
    // ISSUE: explicit constructor call
    ((Vector2) ref Line1Start).\u002Ector((float) position2.x, (float) position2.z);
    if (this.WestCover != 딶.딥.딟 || gameTileComponent1.EastCover != 딶.딥.딟)
    {
      Vector2 vector2_1;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_1).\u002Ector(-0.5f, -0.5f);
      Vector2 vector2_2;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_2).\u002Ector(0.0f, 1f);
      if (this.DoLinesIntersect(Line1Start, Line1End, Vector2.op_Addition(Line1End, vector2_1), Vector2.op_Addition(Vector2.op_Addition(Line1End, vector2_1), vector2_2)))
        return this.WestCover != 딶.딥.딟 ? this.WestCover : gameTileComponent1.EastCover;
    }
    if (this.EastCover != 딶.딥.딟 || gameTileComponent2.WestCover != 딶.딥.딟)
    {
      Vector2 vector2_3;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_3).\u002Ector(0.5f, -0.5f);
      Vector2 vector2_4;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_4).\u002Ector(0.0f, 1f);
      if (this.DoLinesIntersect(Line1Start, Line1End, Vector2.op_Addition(Line1End, vector2_3), Vector2.op_Addition(Vector2.op_Addition(Line1End, vector2_3), vector2_4)))
        return this.EastCover != 딶.딥.딟 ? this.EastCover : gameTileComponent2.WestCover;
    }
    if (this.NorthCover != 딶.딥.딟 || gameTileComponent3.SouthCover != 딶.딥.딟)
    {
      Vector2 vector2_5;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_5).\u002Ector(-0.5f, 0.5f);
      Vector2 vector2_6;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_6).\u002Ector(1f, 0.0f);
      if (this.DoLinesIntersect(Line1Start, Line1End, Vector2.op_Addition(Line1End, vector2_5), Vector2.op_Addition(Vector2.op_Addition(Line1End, vector2_5), vector2_6)))
        return this.NorthCover != 딶.딥.딟 ? this.NorthCover : gameTileComponent3.SouthCover;
    }
    if (this.SouthCover != 딶.딥.딟 || gameTileComponent4.NorthCover != 딶.딥.딟)
    {
      Vector2 vector2_7;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_7).\u002Ector(-0.5f, -0.5f);
      Vector2 vector2_8;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_8).\u002Ector(1f, 0.0f);
      if (this.DoLinesIntersect(Line1Start, Line1End, Vector2.op_Addition(Line1End, vector2_7), Vector2.op_Addition(Vector2.op_Addition(Line1End, vector2_7), vector2_8)))
        return this.SouthCover != 딶.딥.딟 ? this.SouthCover : gameTileComponent4.NorthCover;
    }
    return 딶.딥.딟;
  }

  public bool BlocksLine(Vector2 Start, Vector2 End)
  {
    GameGridComponent component = ((Component) ((Component) this).transform.parent).GetComponent<GameGridComponent>();
    GameTileComponent gameTileComponent1 = component.get_Tiles()[Mathf.Clamp(this.TileIndexX - 1, 0, component.SizeX - 1), this.TileIndexY];
    GameTileComponent gameTileComponent2 = component.get_Tiles()[Mathf.Clamp(this.TileIndexX + 1, 0, component.SizeX - 1), this.TileIndexY];
    GameTileComponent gameTileComponent3 = component.get_Tiles()[this.TileIndexX, Mathf.Clamp(this.TileIndexY + 1, 0, component.SizeY - 1)];
    GameTileComponent gameTileComponent4 = component.get_Tiles()[this.TileIndexX, Mathf.Clamp(this.TileIndexY - 1, 0, component.SizeY - 1)];
    if (this.WestCover != 딶.딥.딢 && this.NorthCover != 딶.딥.딢 && this.SouthCover != 딶.딥.딢 && this.EastCover != 딶.딥.딢 && gameTileComponent1.EastCover != 딶.딥.딢 && gameTileComponent2.WestCover != 딶.딥.딢 && gameTileComponent3.SouthCover != 딶.딥.딢 && gameTileComponent4.NorthCover != 딶.딥.딢)
      return false;
    Vector3 position = ((Component) this).transform.position;
    Vector2 vector2_1;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2_1).\u002Ector((float) position.x, (float) position.z);
    if (this.WestCover == 딶.딥.딢 || gameTileComponent1.EastCover == 딶.딥.딢)
    {
      Vector2 vector2_2;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_2).\u002Ector(-0.5f, -0.5f);
      Vector2 vector2_3;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_3).\u002Ector(0.0f, 1f);
      if (this.DoLinesIntersect(Start, End, Vector2.op_Addition(vector2_1, vector2_2), Vector2.op_Addition(Vector2.op_Addition(vector2_1, vector2_2), vector2_3)))
        return true;
    }
    if (this.EastCover == 딶.딥.딢 || gameTileComponent2.WestCover == 딶.딥.딢)
    {
      Vector2 vector2_4;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_4).\u002Ector(0.5f, -0.5f);
      Vector2 vector2_5;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_5).\u002Ector(0.0f, 1f);
      if (this.DoLinesIntersect(Start, End, Vector2.op_Addition(vector2_1, vector2_4), Vector2.op_Addition(Vector2.op_Addition(vector2_1, vector2_4), vector2_5)))
        return true;
    }
    if (this.NorthCover == 딶.딥.딢 || gameTileComponent3.SouthCover == 딶.딥.딢)
    {
      Vector2 vector2_6;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_6).\u002Ector(-0.5f, 0.5f);
      Vector2 vector2_7;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_7).\u002Ector(1f, 0.0f);
      if (this.DoLinesIntersect(Start, End, Vector2.op_Addition(vector2_1, vector2_6), Vector2.op_Addition(Vector2.op_Addition(vector2_1, vector2_6), vector2_7)))
        return true;
    }
    if (this.SouthCover == 딶.딥.딢 || gameTileComponent4.NorthCover == 딶.딥.딢)
    {
      Vector2 vector2_8;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_8).\u002Ector(-0.5f, -0.5f);
      Vector2 vector2_9;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_9).\u002Ector(1f, 0.0f);
      if (this.DoLinesIntersect(Start, End, Vector2.op_Addition(vector2_1, vector2_8), Vector2.op_Addition(Vector2.op_Addition(vector2_1, vector2_8), vector2_9)))
        return true;
    }
    return false;
  }

  private bool DoLinesIntersect(
    Vector2 Line1Start,
    Vector2 Line1End,
    Vector2 Line2Start,
    Vector2 Line2End)
  {
    float num1 = (float) ((Line2End.y - Line2Start.y) * (Line1End.x - Line1Start.x) - (Line2End.x - Line2Start.x) * (Line1End.y - Line1Start.y));
    if ((double) num1 == 0.0)
      return false;
    float num2 = (float) ((Line2End.x - Line2Start.x) * (Line1Start.y - Line2Start.y) - (Line2End.y - Line2Start.y) * (Line1Start.x - Line2Start.x));
    float num3 = (float) ((Line1End.x - Line1Start.x) * (Line1Start.y - Line2Start.y) - (Line1End.y - Line1Start.y) * (Line1Start.x - Line2Start.x));
    float num4 = num2 / num1;
    float num5 = num3 / num1;
    return (double) num4 >= 0.0 && (double) num4 <= 1.0 && (double) num5 >= 0.0 && (double) num5 <= 1.0;
  }
}
