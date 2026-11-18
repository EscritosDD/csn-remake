// Decompiled with JetBrains decompiler
// Type: BaseMenuHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public abstract class BaseMenuHandler : MonoBehaviour
{
  protected Vector3 딟;
  public static BaseMenuHandler 딟;
  public static BaseMenuHandler 땄;

  public virtual void DeactivateMenu()
  {
    ((Component) this).transform.position = this.딟;
    if (!Object.op_Equality((Object) BaseMenuHandler.딟, (Object) this))
      return;
    BaseMenuHandler.땄 = BaseMenuHandler.딟;
    BaseMenuHandler.딟 = (BaseMenuHandler) null;
  }

  public virtual void ActivateMenu()
  {
    ((Component) this).transform.position = Vector3.zero;
    BaseMenuHandler.딟 = this;
  }

  protected void SetGameObjectActive(GameObject button, bool active)
  {
    if (active)
    {
      if (button.activeInHierarchy)
        return;
      NaClContentDisplayComponent component = button.GetComponent<NaClContentDisplayComponent>();
      if (!Object.op_Inequality((Object) component, (Object) null) || !component.CanActivate())
        return;
      button.SetActive(active);
    }
    else
      button.SetActive(active);
  }
}
