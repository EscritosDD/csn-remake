// Decompiled with JetBrains decompiler
// Type: 땓.딫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 딟;

namespace 땓
{
  public class 딫 : 땶
  {
    private bool 딟;
    private Material 딟;
    public static 땫 딟;

    public 딫([In] Uri obj0)
    {
      if (딫.딟 == null)
        딫.딟 = new 땫(512, (딟.땇) GlobalAppData.떏());
      string str = "http://graph.facebook.com/" + obj0.Host + "/picture?type=normal";
      딫.딟.딟(str, new Action(this.딢), new Action<Texture2D>(this.딟));
    }

    private void 딢() => this.딟 = true;

    private void 딟([In] Texture2D obj0)
    {
      this.딟 = true;
      this.딟 = new Material(GlobalAppData.딟.GameAssets.FacebookMaterial);
      this.딟.mainTexture = (Texture) obj0;
      if (((Texture) obj0).width > ((Texture) obj0).height)
      {
        float num1 = (float) ((Texture) obj0).height / (float) ((Texture) obj0).width;
        float num2 = (float) (((double) ((Texture) obj0).width / (double) ((Texture) obj0).height - 1.0) * 0.5);
        this.딟.mainTextureScale = new Vector2(num1, 1f);
        this.딟.mainTextureOffset = new Vector2(num2, 0.0f);
      }
      else
      {
        if (((Texture) obj0).height <= ((Texture) obj0).width)
          return;
        float num3 = (float) ((Texture) obj0).width / (float) ((Texture) obj0).height;
        float num4 = (float) (((double) ((Texture) obj0).height / (double) ((Texture) obj0).width - 1.0) * 0.5);
        this.딟.mainTextureScale = new Vector2(1f, num3);
        this.딟.mainTextureOffset = new Vector2(0.0f, num4);
      }
    }

    [SpecialName]
    public override bool 딟() => this.딟;

    [SpecialName]
    public override bool 땄() => Object.op_Inequality((Object) this.딟, (Object) null);

    [SpecialName]
    public override Material 딧() => this.딟;
  }
}
