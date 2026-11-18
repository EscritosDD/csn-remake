// Decompiled with JetBrains decompiler
// Type: EffectPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
  public EffectPlayer.EffectInfo[] Effects;

  public void PlayEffect(string Name)
  {
    foreach (EffectPlayer.EffectInfo effect in this.Effects)
    {
      if (effect.Name.Equals(Name, StringComparison.OrdinalIgnoreCase))
      {
        Transform transform = ((Component) this).transform;
        if (!string.IsNullOrEmpty(effect.JointName))
        {
          transform = ((Component) this).gameObject.transform.FindChild(effect.JointName);
          if (Object.op_Equality((Object) transform, (Object) null))
          {
            Debug.LogWarning((object) ("Unknown joint " + effect.JointName));
            transform = ((Component) this).transform;
          }
        }
        (Object.Instantiate((Object) effect.Effect, transform.position, transform.rotation) as GameObject).transform.parent = transform;
        return;
      }
    }
    Debug.LogWarning((object) ("Unknown effect " + Name));
  }

  [Serializable]
  public class EffectInfo
  {
    public string Name;
    public string JointName;
    public GameObject Effect;
  }
}
