// Decompiled with JetBrains decompiler
// Type: TutorialArrowAnimationHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class TutorialArrowAnimationHandler : MonoBehaviour
{
  private Vector3 딟;
  private float 딟;
  private TutorialArrowAnimationHandler.딱 딟;
  private float 땄;
  private 땿 딟 = new 땿();
  public GameObject Arrow;
  public float QuickPulseTime;
  public float SlowPulseTime;
  public float Movement;
  public float AnimationDelay;

  private void Start()
  {
    this.딟 = this.Arrow.transform.localPosition;
    this.딟 = (float) this.딟.y + this.Movement;
    this.딟 = TutorialArrowAnimationHandler.딱.딟;
  }

  private void Update()
  {
    this.딟.딟();
    if (this.딟.땄())
    {
      this.땄 += Time.deltaTime;
      if (this.딟 == TutorialArrowAnimationHandler.딱.딟)
      {
        this.땄 /= this.QuickPulseTime;
        this.땄 = Mathf.Clamp01(this.땄);
        this.AnimateArrow((float) this.딟.y, this.딟, this.땄);
      }
      else
      {
        this.땄 /= this.SlowPulseTime;
        this.땄 = Mathf.Clamp01(this.땄);
        this.AnimateArrow(this.딟, (float) this.딟.y, this.땄);
      }
    }
    if ((double) this.땄 != 1.0)
      return;
    if (this.딟 == TutorialArrowAnimationHandler.딱.딟)
    {
      this.딟 = TutorialArrowAnimationHandler.딱.땄;
      this.땄 = 0.0f;
    }
    else
    {
      this.딟.딟(this.AnimationDelay);
      this.딟 = TutorialArrowAnimationHandler.딱.딟;
      this.땄 = 0.0f;
    }
  }

  private void AnimateArrow(float StartY, float EndY, float Timer)
  {
    Vector3 딟 = this.딟;
    float num = Mathf.Lerp(StartY, EndY, Timer);
    딟.y = (__Null) (double) num;
    this.Arrow.transform.localPosition = 딟;
  }

  private enum 딱
  {
    딟,
    땄,
  }
}
