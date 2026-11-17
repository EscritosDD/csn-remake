// Decompiled with JetBrains decompiler
// Type: 딶.땎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땎 : 떒
  {
    protected GameObject 딟;

    public 땎([In] int obj0)
      : base(obj0)
    {
    }

    protected override void 딟()
    {
      this.딟 = (GameObject) null;
      Transform transform = (Transform) null;
      땖 땖 = 딡.땴().땼();
      int num = -1;
      bool flag = false;
      if (땖.땻()[((땏) this).딟] is 땘 땘)
      {
        this.딟 = Object.Instantiate((Object) ((Component) 땘.딥()).gameObject) as GameObject;
        transform = 땘.땻();
        num = 땘.땳();
      }
      else
      {
        if (땖.땻()[((땏) this).딟] is 떔 떔2)
        {
          this.딟 = Object.Instantiate((Object) ((Component) 떔2.땳()).gameObject) as GameObject;
          transform = 떔2.딗();
          num = 떔2.땄();
        }
        if (땖.땻()[((땏) this).딟] is 땹 땹2)
        {
          this.딟 = Object.Instantiate((Object) ((Component) 땹2.땳()).gameObject) as GameObject;
          transform = 땹2.딗();
          flag = true;
          num = ((땏) this).딟;
        }
      }
      땓.땊 땊1 = 딡.땴().딷().딟(((땏) this).딟).땴();
      ((땏) this).딟 = new 땩(땊1.땃, 땊1.딶);
      if (Object.op_Inequality((Object) transform, (Object) null) && Object.op_Inequality((Object) this.딟, (Object) null))
      {
        this.딟.transform.position = 딡.땴().땓().GetTileCentre(((땏) this).딟.딟, ((땏) this).딟.땄);
        this.딟.transform.rotation = Quaternion.Euler(0.0f, 90f, 0.0f);
        땓.딯.딟(this.딟, transform);
        foreach (SkinnedMeshRenderer componentsInChild in this.딟.GetComponentsInChildren<SkinnedMeshRenderer>())
          componentsInChild.updateWhenOffscreen = true;
        땓.땊 땊2 = 땖.떎()[((땏) this).딟];
        땓.땦.딟(this.딟, 땊2.땄, 땖.땻()[((땏) this).딟].땼());
        Animation componentInChildren = this.딟.GetComponentInChildren<Animation>();
        string str = 땖.땻()[((땏) this).딟].딟(땊2, 땓.딺.떎);
        if (str != null)
        {
          base.딟 = componentInChildren[str].length;
          componentInChildren.Play(str, (PlayMode) 4);
        }
        AudioShader2 audioShader2 = 땖.땻()[((땏) this).딟].딟(땓.딘.떏);
        if (Object.op_Inequality((Object) audioShader2, (Object) null))
        {
          if (flag)
            딡.땴().딷().딟(num).딟(audioShader2, this.딟);
          else if (num != -1)
            딡.땴().딷().딟(num).딟(audioShader2);
        }
      }
      base.딟();
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      Object.Destroy((Object) this.딟, 0.1f);
    }

    public override string ToString() => string.Format("[CreatePreDeployMeshCinematicEvent]: Creating for unit {0}", (object) ((땏) this).딟);
  }
}
