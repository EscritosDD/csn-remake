// Decompiled with JetBrains decompiler
// Type: StoreIconLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Linq;
using UnityEngine;
using 딟;

public class StoreIconLoader : MonoBehaviour
{
  private bool 딟;
  private bool 땄;
  private Material 딟;
  private bool 딧;
  private GameObject 딟;
  private Action 딟;
  private Action 땄;
  private string 딟;
  private 땫 딟;
  private static Texture2D 딟;
  private DateTime 딟;

  public void Init(
    Material baseMaterial,
    GameObject loadingOverlay,
    땫 imageCache,
    string url,
    Action onComplete,
    Action onFailed)
  {
    if (Object.op_Equality((Object) StoreIconLoader.딟, (Object) null))
    {
      StoreIconLoader.딟 = new Texture2D(4, 4, (TextureFormat) 1, false);
      StoreIconLoader.딟.SetPixels(Enumerable.Range(0, 16).Select<int, Color>((Func<int, Color>) delegate
      {
        return new Color(0.0f, 0.0f, 0.0f, 0.0f);
      }).ToArray<Color>());
      StoreIconLoader.딟.Apply();
    }
    this.딟 = new Material(baseMaterial);
    this.딟.mainTexture = (Texture) StoreIconLoader.딟;
    ((Component) this).gameObject.renderer.sharedMaterial = this.딟;
    ((Component) this).gameObject.AddComponent<GuiScrollListUseSharedMaterial>();
    this.딟 = imageCache;
    this.딟 = url;
    this.딟 = onComplete;
    this.땄 = onFailed;
    this.딟 = loadingOverlay;
  }

  private void StartImageDownload()
  {
    this.딟.mainTexture = (Texture) StoreIconLoader.딟;
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.SetActive(true);
    this.딟.딟(this.딟, new Action(this.OnImageDownloadFailure), new Action<Texture2D>(this.OnImageDownloadSuccess));
  }

  private void OnImageDownloadFailure()
  {
    this.딟 = false;
    if (this.딧)
      return;
    if (this.땄 != null)
      this.땄();
    this.딟 = DateTime.Now.AddSeconds(10.0);
  }

  private void OnImageDownloadSuccess(Texture2D image)
  {
    this.딟 = false;
    if (this.딧)
      return;
    this.땄 = true;
    this.딟.mainTexture = (Texture) image;
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.SetActive(false);
    if (this.딟 == null)
      return;
    this.딟();
  }

  private void Update()
  {
    if (((Component) this).gameObject.renderer.isVisible)
    {
      if (this.땄 || this.딟 || !(DateTime.Now >= this.딟))
        return;
      this.StartImageDownload();
    }
    else
    {
      if (!this.땄 || !this.딟.땄())
        return;
      this.FreeImage();
    }
  }

  private void FreeImage()
  {
    this.땄 = false;
    this.딟.mainTexture = (Texture) null;
    this.딟.딟(this.딟);
  }

  private void OnDestroy()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      Object.Destroy((Object) this.딟);
      this.딟 = (Material) null;
    }
    this.딧 = true;
  }
}
