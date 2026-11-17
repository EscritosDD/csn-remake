// Decompiled with JetBrains decompiler
// Type: TextPulse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class TextPulse : MonoBehaviour
{
  public GuiText3D Text;
  public float PulseTime;
  public float PulsePause;
  public float MinScale = 1f;
  public float MaxScale = 2f;
  private float 딟;
  private bool 딟;
  private 땿 딟 = new 땿();

  public void Update()
  {
    this.딟.딟();
    if (!this.딟.땄())
      return;
    if (!this.딟)
    {
      this.딟 += Time.deltaTime / this.PulseTime;
      this.딟 = Mathf.Clamp01(this.딟);
      float num = Mathf.Lerp(this.MinScale, this.MaxScale, this.딟);
      ((Component) this.Text).transform.localScale = new Vector3(num, 1f, num);
      if ((double) this.딟 == 1.0)
        this.딟 = true;
    }
    if (!this.딟)
      return;
    this.딟 -= Time.deltaTime / this.PulseTime;
    this.딟 = Mathf.Clamp01(this.딟);
    float num1 = Mathf.Lerp(this.MinScale, this.MaxScale, this.딟);
    ((Component) this.Text).transform.localScale = new Vector3(num1, 1f, num1);
    if ((double) this.딟 != 0.0)
      return;
    this.딟 = false;
    this.딟.딟(this.PulsePause);
  }
}
