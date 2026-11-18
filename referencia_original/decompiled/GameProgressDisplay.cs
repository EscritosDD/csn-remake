// Decompiled with JetBrains decompiler
// Type: GameProgressDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Game Progress Display")]
public class GameProgressDisplay : MonoBehaviour
{
  private 딶.땖 딟;
  private int 딟;
  private bool 딟;
  private bool 땄;
  public int BarWidth = 184;
  public int BarHeight = 8;
  public GameObject Bar;
  public GameObject[] Pips;

  public void Init(딶.땖 GameState, int TeamIndex, bool GrowToRight)
  {
    this.딟 = GameState;
    this.딟 = TeamIndex;
    this.딟 = GrowToRight;
    this.땄 = true;
    int num1 = TeamIndex != 0 ? GameState.딸() : GameState.땁();
    int num2 = num1 + (TeamIndex != 0 ? GameState.땘() : GameState.땷());
    for (int index = num1; index < num2; ++index)
    {
      if (GameState.땻()[index] is 땓.떀 떀1)
        GlobalAppData.땼().딟((땓.딲) 떀1, (땓.땾) 0);
    }
  }

  private void Update()
  {
    if (!this.땄 || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    this.땄 = false;
    this.UpdateHealthDisplay(this.딟, this.딟, this.딟);
    this.UpdateGameDisplay(this.딟, this.딟);
  }

  private void UpdateGameDisplay(딶.땖 GameState, int TeamIndex)
  {
    int num = GameState.땺(TeamIndex);
    for (int index1 = 0; index1 < this.Pips.Length; ++index1)
    {
      int index2 = index1;
      if (!this.딟)
        index2 = this.Pips.Length - 1 - index1;
      this.Pips[index2].renderer.material.color = num <= index1 ? Color.white : (TeamIndex != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue);
    }
  }

  private void UpdateHealthDisplay(딶.땖 GameState, int TeamIndex, bool GrowToRight)
  {
    float num1 = GameState.땓(TeamIndex);
    float num2 = (float) this.BarWidth / 320f;
    float num3 = (float) this.BarHeight / 320f;
    float num4 = num2 * num1;
    float num5 = num3 * -0.5f;
    float num6 = num3 * 0.5f;
    float num7;
    float num8;
    if (GrowToRight)
    {
      num7 = num2 * -0.5f;
      num8 = num7 + num4;
    }
    else
    {
      num8 = num2 * 0.5f;
      num7 = num8 - num4;
    }
    Mesh mesh = new Mesh();
    Vector3[] vector3Array = new Vector3[4]
    {
      new Vector3(num7, 0.0f, num5),
      new Vector3(num8, 0.0f, num5),
      new Vector3(num8, 0.0f, num6),
      new Vector3(num7, 0.0f, num6)
    };
    Vector2[] vector2Array = new Vector2[4]
    {
      new Vector2(0.0f, 0.0f),
      new Vector2(1f, 0.0f),
      new Vector2(1f, 1f),
      new Vector2(0.0f, 1f)
    };
    int[] numArray = new int[6]{ 0, 2, 1, 0, 3, 2 };
    mesh.vertices = vector3Array;
    mesh.triangles = numArray;
    mesh.uv = vector2Array;
    this.Bar.GetComponent<MeshFilter>().mesh = mesh;
    this.Bar.renderer.material.color = TeamIndex != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
  }
}
