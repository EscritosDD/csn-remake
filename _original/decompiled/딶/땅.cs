// Decompiled with JetBrains decompiler
// Type: 딶.땅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땅 : 떒
  {
    private 땃.땦 딟;
    private new float 딟;
    private new float 땄;

    public 땅([In] 땃.땦 obj0, [In] float obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    protected override void 딟() => base.딟();

    protected override void 땄()
    {
      this.딟 += Time.deltaTime;
      땇 땇 = (땇) 딡.땴().딷();
      float num = this.딟 / this.땄;
      bool flag = false;
      for (int index = 0; index < this.딟.딟.Count; ++index)
      {
        땃.떃 떃 = this.딟.딟[index];
        if (떃.딟)
        {
          땓.땊 땊 = 땇.딟(떃.딟).땴();
          if (땊.땃 != -1 && 땊.딶 != -1)
          {
            Vector3 tileCentre = 딡.땴().땼().땹().GetTileCentre(땊.땃, 땊.딶);
            Vector3 vector3 = Vector3.op_Subtraction(tileCentre, 떃.딟);
            if ((double) ((Vector3) ref vector3).sqrMagnitude > 0.100000001490116)
            {
              땇.딟(떃.딟).땄(Vector3.Lerp(떃.딟, tileCentre, num));
              flag = true;
            }
          }
        }
      }
      if (flag && (double) num < 1.0)
        return;
      this.딧(true);
    }

    public override string ToString() => string.Format("[DisplayKnockbackCinematicEvent]");
  }
}
