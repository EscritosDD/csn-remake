// Decompiled with JetBrains decompiler
// Type: 딶.딤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딤 : 떒
  {
    private new float 딟;
    private Vector3 딟;
    private Quaternion 딟;
    private new float 땄;
    private new bool 딟;
    private new int 딟;
    private bool 땄;

    public 딤([In] int obj0) => this.딟 = obj0;

    protected override void 딟()
    {
      base.딟 = 딡.땴().딷().딟().딟.PlayCameraAnim(this.딟 != 0 ? 딢.땷.땄 : 딢.땷.딟) + 2f;
      base.딟();
    }

    protected override void 땄()
    {
      땇 땇 = (땇) 딡.땴().딷();
      if (!this.딟)
      {
        if (땇.딟().땼().떔() is 딮 딮2)
        {
          if (Object.op_Inequality((Object) 딮2.떂(), (Object) null))
          {
            딮2.떂().PlayIntroAnim();
            땇.딟().딟.Init();
            땇.딟().땢().OpenMapNameScreen();
            this.딟 = true;
          }
        }
        else
        {
          땇.딟().딟.Init();
          this.딟 = true;
        }
      }
      CameraController 딟 = 땇.딟().딟;
      this.땄 = 딟.CameraAnimation.IsPlaying();
      if (!this.땄)
      {
        float num1 = 0.5f / 딟.CameraAnimation.cameraAnimationSpeed;
        if ((double) this.딟 == 0.0)
        {
          딟.SetupFromAnimation();
          this.딟 = Time.time + num1;
          this.딟 = ((Component) 딟.CameraAnimation).transform.position;
          this.딟 = ((Component) 딟.CameraAnimation).transform.rotation;
          this.땄 = ((Component) 딟.CameraAnimation).camera.fieldOfView;
        }
        else if ((double) Time.time > (double) this.딟)
        {
          this.땄(false);
          this.딧(true);
        }
        else
        {
          float num2 = (float) (1.0 - ((double) this.딟 - (double) Time.time) / (double) num1);
          ((Component) 딟.CameraAnimation).transform.position = Vector3.Lerp(this.딟, ((Component) 딟).transform.position, num2);
          ((Component) 딟.CameraAnimation).transform.rotation = Quaternion.Lerp(this.딟, ((Component) 딟).transform.rotation, num2);
          ((Component) 딟.CameraAnimation).camera.fieldOfView = Mathf.Lerp(this.땄, ((Component) 딟).camera.fieldOfView, num2);
        }
      }
      base.땄();
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      딡.땴().딷().딟().딟.StopCameraAnim();
    }
  }
}
