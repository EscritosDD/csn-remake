// Decompiled with JetBrains decompiler
// Type: TacticsUserActionEditorBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;

[Serializable]
public class TacticsUserActionEditorBase
{
  public 딶.딶 Type;
  public int GameObjectIndex;
  public int OtherGameObjectIndex;
  public int TileX;
  public int TileY;
  public 딢.딴 Ability;
  public 딢.딯 Direction;
  public string StatId;

  public TacticsUserActionEditorBase 딟() => new TacticsUserActionEditorBase()
  {
    Type = this.Type,
    GameObjectIndex = this.GameObjectIndex,
    OtherGameObjectIndex = this.OtherGameObjectIndex,
    TileX = this.TileX,
    TileY = this.TileY,
    Ability = this.Ability,
    Direction = this.Direction,
    StatId = this.StatId
  };
}
