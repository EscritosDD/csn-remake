// Decompiled with JetBrains decompiler
// Type: MenuOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class MenuOverlayHandler : MonoBehaviour
{
  private const float 딟 = 0.6f;
  private const float 땄 = 0.2f;
  private Material 딟;
  private float 딧;
  private float 딢;
  private float 땃;
  private bool 딟;

  private void OnEnable()
  {
    this.딟 = ((Component) this).renderer.material;
    this.딟.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.땃 = Time.realtimeSinceStartup;
  }

  private void Update()
  {
    float num1 = Time.realtimeSinceStartup - this.땃;
    this.땃 = Time.realtimeSinceStartup;
    if ((double) this.딧 < 1.0 && !this.딟)
    {
      this.딢 += num1 / 0.2f;
      double num2 = (double) Mathf.Clamp(this.딢, 0.0f, 1f);
      this.딧 = Mathf.Lerp(0.0f, 0.6f, this.딢);
      this.딟.color = new Color(0.0f, 0.0f, 0.0f, this.딧);
    }
    if (!this.딟)
      return;
    this.딢 += num1 / 0.2f;
    double num3 = (double) Mathf.Clamp(this.딢, 0.0f, 1f);
    this.딧 = Mathf.Lerp(0.6f, 0.0f, this.딢);
    this.딟.color = new Color(0.0f, 0.0f, 0.0f, this.딧);
    if ((double) this.딧 != 0.0)
      return;
    Object.Destroy((Object) this.딟);
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Close()
  {
    this.딢 = 0.0f;
    this.딟 = true;
  }

  public void CloseInstantly()
  {
    this.Close();
    this.딢 = 1f;
  }

  private void OnDestroy() => GlobalAppData.딟(this.딟);
}
