// Decompiled with JetBrains decompiler
// Type: RageSvgGradient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class RageSvgGradient : ScriptableObject
{
  public string Id = string.Empty;
  public RageSvgGradient.때 Type;
  public float X1;
  public float X2;
  public float Y1;
  public float Y2;
  public Color StartColor;
  public Color EndColor;

  private RageSvgGradient()
  {
    this.Type = RageSvgGradient.때.딟;
    this.X1 = this.X2 = this.Y1 = this.Y2 = 0.0f;
    this.Id = string.Empty;
    this.StartColor = this.EndColor = Color.black;
  }

  public void 딟([In] RageSvgGradient obj0)
  {
    this.Id = obj0.Id;
    this.Type = obj0.Type;
    this.X1 = obj0.X1;
    this.X2 = obj0.X2;
    this.Y1 = obj0.Y1;
    this.Y2 = obj0.Y2;
    this.StartColor = obj0.StartColor;
    this.EndColor = obj0.EndColor;
  }

  public static RageSvgGradient 딟() => (RageSvgGradient) ScriptableObject.CreateInstance(typeof (RageSvgGradient));

  public void 딟([In] Vector2 obj0)
  {
    this.X1 = (float) obj0.x;
    this.Y1 = (float) -obj0.y;
  }

  public void 땄([In] Vector2 obj0)
  {
    this.X2 = (float) obj0.x;
    this.Y2 = (float) -obj0.y;
  }

  public enum 때
  {
    딟,
    땄,
  }
}
