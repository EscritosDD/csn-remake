// Decompiled with JetBrains decompiler
// Type: 땓.땦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땦 : IDisposable, 딧.떒
  {
    private 딭 딟;
    private 딤 딟;
    private 땰 딟;
    private 땦.땆 딟;
    private float 딟;
    private 딢.딴 딟 = 딢.딴.땄;
    private bool 딟;
    private bool 땄;
    private bool 딧;
    private Animation 딟;
    private float 땄;
    private float 딧;
    private GameObject[] 딟;
    private 딶.딡 딟;
    private int 딟;
    private List<땱> 딟;

    public 땦([In] 딶.딡 obj0, [In] 땊 obj1, [In] int obj2, [In] Vector3 obj3, [In] Quaternion obj4)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.땄(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딧(obj2);
      this.땄(obj3);
      this.딟(obj4);
      this.땓(true);
      this.땄(false);
      this.딟();
    }

    public void Dispose()
    {
      this.딟(false);
      this.땄();
      this.딧();
      this.땃();
      this.땓();
    }

    private void 딟()
    {
      this.딟 = new List<땱>(8);
      this.딟.Add(new 땱(딢.떍.땼, true));
      this.딟.Add(new 땱(딢.떍.딢, true));
      this.딟.Add(new 땱(딢.떍.땓, true));
      this.딟.Add(new 땱(딢.떍.딧, true));
      this.딟.Add(new 땱(딢.떍.땢, true));
      this.딟.Add(new 땱(딢.떍.땔, true));
      this.딟.Add(new 땱(딢.떍.떈, true));
      this.딟.Add(new 땱(딢.떍.딷, true));
    }

    private void 딟([In] bool obj0)
    {
      if (Object.op_Equality((Object) this.딣(), (Object) null))
        return;
      if (obj0 && (double) this.딟.딟() != 0.0)
      {
        this.딟.딧();
      }
      else
      {
        this.땺();
        Object.Destroy((Object) this.딣());
        // ISSUE: reference to a compiler-generated method
        this.딟((GameObject) null);
        this.딟 = (Animation) null;
      }
    }

    private void 땄()
    {
      if (this.딟 == null)
        return;
      foreach (Object @object in this.딟)
        Object.Destroy(@object);
      this.딟 = (GameObject[]) null;
    }

    private void 딧()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (딭) null;
    }

    private void 딢()
    {
      if (this.딟 == null)
        return;
      this.딟.딢();
    }

    private void 땃()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (딤) null;
    }

    private void 딶()
    {
      if (this.딟 == null)
        return;
      this.딟.딢();
    }

    private void 땓()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (땰) null;
    }

    private void 땺()
    {
      if (this.딟 == null)
        return;
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟(ref this.딟[index].딟);
    }

    private void 딟([In] ref GameObject obj0)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      Object.Destroy((Object) obj0);
      obj0 = (GameObject) null;
    }

    private void 땥()
    {
      if (!Object.op_Inequality((Object) this.딣(), (Object) null) || this.딟 == null)
        return;
      this.딝();
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟(ref this.딟[index].딟, this.딟[index].딟, this.딟[index].딟 && this.땴().딢(this.딟[index].딟) >= 0);
    }

    private void 딝()
    {
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index].딟 = this.땴().딢(this.딟[index].딟) >= 0 && !this.딟[index].땄;
    }

    private void 딟([In] ref GameObject obj0, [In] 딢.떍 obj1, [In] bool obj2)
    {
      if (obj2)
      {
        if (!Object.op_Equality((Object) obj0, (Object) null))
          return;
        Transform transform = 땧.딟(obj1);
        if (!Object.op_Inequality((Object) transform, (Object) null))
          return;
        obj0 = ((Component) (Object.Instantiate((Object) transform) as Transform)).gameObject;
        obj0.transform.parent = this.딣().transform;
        obj0.transform.localPosition = Vector3.zero;
        obj0.transform.localRotation = Quaternion.identity;
      }
      else
      {
        if (!Object.op_Inequality((Object) obj0, (Object) null))
          return;
        Object.Destroy((Object) obj0);
        obj0 = (GameObject) null;
      }
    }

    public void 딟([In] 딢.떍 obj0, [In] bool obj1)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].딟 == obj0)
          this.딟[index].땄 = obj1;
      }
    }

    private void 떎()
    {
      this.땥();
      if (Object.op_Inequality((Object) this.딣(), (Object) null))
      {
        this.딟.딢();
      }
      else
      {
        딲 딲 = this.딟.땼().땻()[this.땔()];
        Transform transform1 = (Transform) Object.Instantiate((Object) 딲.땩());
        // ISSUE: reference to a compiler-generated method
        this.딟(((Component) transform1).gameObject);
        this.땄(this.딟.땓().GetTileCentre(this.땴().땃, this.땴().딶));
        this.딟(this.땴().땃());
        transform1.position = this.딗();
        transform1.rotation = this.땳();
        딯.딟(this.딣(), 딲.때());
        foreach (UnitSelector componentsInChild in this.딣().GetComponentsInChildren<UnitSelector>())
          componentsInChild.set_Controller(this);
        foreach (UnitAudioEvents componentsInChild in this.딣().GetComponentsInChildren<UnitAudioEvents>())
          componentsInChild.set_Controller((딧.떒) this);
        땦.딟(this.딣(), this.땴().땄, false, 딲.땼());
        Transform transform2 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.UnitShadow) as Transform;
        ((Component) transform2).transform.parent = this.딣().transform;
        transform2.localPosition = Vector3.zero;
        transform2.localRotation = Quaternion.identity;
        this.딟 = this.딣().GetComponentInChildren<Animation>();
        string str = 딲.딟(this.땴(), 딺.딟);
        if (str != null)
        {
          double num1 = (double) this.딟(str, (WrapMode) 2);
          float num2 = Random.Range(0.0f, this.딟.GetClip(str).length);
          foreach (AnimationState animationState in this.딟)
          {
            if (animationState.enabled)
              animationState.time = num2;
          }
        }
        this.딟 = this.땴().땄;
        this.딟.딢();
        this.땟();
      }
    }

    public static void 딟([In] GameObject obj0, [In] int obj1, [In] 딵 obj2) => 땦.딟(obj0, obj1, true, obj2);

    public static void 딟([In] GameObject obj0, [In] int obj1, [In] bool obj2, [In] 딵 obj3)
    {
      if ((obj3 & 딵.땺) != 딵.딟)
        return;
      Color color = obj1 != 0 ? GlobalAppData.딟.GameAssets.Red : GlobalAppData.딟.GameAssets.Blue;
      foreach (Renderer componentsInChild in obj0.GetComponentsInChildren<Renderer>(true))
      {
        foreach (Material material in !obj2 ? componentsInChild.materials : componentsInChild.sharedMaterials)
          material.color = color;
      }
    }

    private void 떂()
    {
      if (this.딟 != null)
        return;
      UnitWeapon unitWeapon = 땎.딢(this.딟, this.딟.땼().땻()[this.땔()]);
      if (Object.op_Equality((Object) unitWeapon, (Object) null) || unitWeapon.Models == null)
        return;
      this.딟 = new GameObject[unitWeapon.Models.Length];
      for (int index = 0; index < unitWeapon.Models.Length; ++index)
      {
        Transform transform1 = this.땄(unitWeapon.Models[index].AttachmentJoint);
        if (Object.op_Equality((Object) transform1, (Object) null))
          transform1 = this.딣().transform;
        Transform transform2 = Object.Instantiate((Object) unitWeapon.Models[index].ModelPrefab) as Transform;
        ((Component) transform2).transform.parent = transform1;
        ((Component) transform2).transform.localPosition = Vector3.zero;
        ((Component) transform2).transform.localRotation = Quaternion.identity;
        this.딟[index] = ((Component) transform2).gameObject;
      }
    }

    private void 땭()
    {
      if (this.딟 == null)
      {
        this.딟 = new 딭(this.딟, this);
      }
      else
      {
        if (this.딟.딶())
          return;
        this.딟.땃();
      }
    }

    private void 딦()
    {
      if (this.딟 == null)
      {
        this.딟 = new 딤(this.딟, this);
      }
      else
      {
        if (this.딟.딶())
          return;
        this.딟.땃();
      }
    }

    private void 땤()
    {
      if (this.딟 != null)
        return;
      this.딟 = new 땰(this.딟, this);
    }

    public void 딟([In] 딢.딴 obj0)
    {
      if (this.딟 == obj0)
        return;
      this.딟 = obj0;
      this.땄();
      this.땄(false);
    }

    public void 딟([In] 땊 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.떁();
      this.땃(true);
      this.땄(true);
    }

    public void 땄([In] bool obj0)
    {
      this.딧(obj0);
      if (this.딟 != this.땴().땄 || this.딟)
        this.딟(false);
      this.땲();
      if (Object.op_Inequality((Object) this.딣(), (Object) null))
      {
        if (Vector3.op_Inequality(this.딗(), this.딣().transform.position))
          this.딣().transform.position = this.딗();
        float num = Quaternion.Angle(this.딣().transform.rotation, this.땳());
        if ((double) Mathf.Abs(num) > 1.40129846432482E-45)
          this.딣().transform.rotation = (double) num <= 46.0 ? Quaternion.RotateTowards(this.딣().transform.rotation, this.땳(), 5f) : this.땳();
      }
      if (this.딟 != null && this.딟.딶())
        this.딟.딟(this.딟, this, this.딗(), this.땳(), this.딟);
      if (this.딟 != null && this.딟.딶())
        this.딟.딟(this.딟, this, this.딗(), this.땳(), this.딟);
      if (this.딟 != null)
        this.딟.딟(this.딟, this.딗(), this.땳(), this.딟);
      this.딧 = this.땴().딢(딢.떍.딧) > 0;
    }

    private void 딧([In] bool obj0)
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null) || this.땴().딧 <= 0)
        return;
      if ((double) this.딧 + 5.0 < (double) Time.time)
      {
        this.딧 = Time.time + Random.value * 2.5f;
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          bool flag = true;
          foreach (AnimationState animationState in this.딟)
          {
            if (animationState.enabled && !((Object) animationState.clip).name.EndsWith("Idle_01"))
            {
              flag = false;
              break;
            }
          }
          if (flag && (double) Random.value < 0.300000011920929)
          {
            string str = this.딟.땼().땻()[this.땔()].딟(this.땴(), 딺.땭);
            if (str != null)
            {
              double num = (double) this.딟(str, (WrapMode) 1);
            }
          }
        }
      }
      if (!this.땽() && !obj0)
        return;
      string str1 = this.딟.땼().땻()[this.땔()].딟(this.땴(), 딺.딟);
      if (str1 == null)
        return;
      this.딟(땊.딟(this.땴().딟));
      double num1 = (double) this.딟(str1, (WrapMode) 2);
    }

    private bool 땽()
    {
      if (!this.딟.isPlaying)
        return true;
      return this.딧 && this.땴().딢(딢.떍.딧) <= 0 && this.땋();
    }

    private bool 땋()
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        foreach (AnimationState animationState in this.딟)
        {
          if (animationState.enabled && !((Object) animationState.clip).name.Contains("Idle"))
            return false;
        }
      }
      return true;
    }

    private void 땲()
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      if (!this.딟 && this.땴().땓())
      {
        if (!this.땄 && this.땴().땺())
        {
          딵 딵 = this.딟.땼().땻()[this.땔()].땼();
          flag1 = (딵 & 딵.땄) == 딵.딟;
          flag2 = (딵 & (딵.땄 | 딵.딶)) == 딵.딟;
        }
        else if (!this.땴().땺() || !this.땄)
        {
          딲 딲 = this.딟.땼().땻()[this.땔()];
          딵 딵 = 딲.땼() | this.땁();
          flag1 = (딵 & 딵.땄) == 딵.딟;
          flag2 = (딵 & (딵.땄 | 딵.딶)) == 딵.딟;
          flag3 = (딵 & 딵.딢) == 딵.딟;
          flag4 = (딵 & 딵.딧) == 딵.딟 && 딲.딟(this.땴()) > 0;
          flag5 = (딵 & 딵.땃) == 딵.딟 && this.딟.딷().땈() == this;
        }
      }
      if (flag1)
        this.떎();
      else
        this.딟(true);
      if (flag2)
        this.떂();
      else
        this.땄();
      if (flag3)
        this.땭();
      else
        this.딢();
      if (flag4)
        this.딦();
      else
        this.딶();
      if (flag5)
      {
        this.딟 += Time.deltaTime * 8f;
        this.땤();
      }
      else
      {
        this.딟 -= Time.deltaTime * 8f;
        this.땓();
      }
      this.딟 = Mathf.Clamp01(this.딟);
    }

    public void 딟([In] 딶.땮 obj0) => this.딟.딟(this.땔(), obj0);

    public float 딟([In] string obj0)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        AnimationClip clip = this.딟.GetClip(obj0);
        if (Object.op_Inequality((Object) clip, (Object) null))
          return clip.length;
      }
      return obj0.ToLower().StartsWith("death") ? 1f : 0.0f;
    }

    public float 딟([In] string obj0, [In] WrapMode obj1)
    {
      float num1 = 0.0f;
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        bool flag = this.딟.wrapMode == 2;
        float num2 = Mathf.Min(this.땄, 0.2f);
        this.딟.wrapMode = obj1;
        AnimationClip clip = this.딟.GetClip(obj0);
        if (Object.op_Equality((Object) clip, (Object) null) && obj0.StartsWith("Hit_"))
        {
          clip = this.딟.GetClip("Hit");
          obj0 = "Hit";
        }
        if (Object.op_Equality((Object) clip, (Object) null) && obj0.StartsWith("Death_"))
        {
          clip = this.딟.GetClip("Death");
          obj0 = "Death";
        }
        if (Object.op_Equality((Object) clip, (Object) null) && obj0 == "Disable")
        {
          obj0 = "Hit_Explosion";
          clip = this.딟.GetClip(obj0);
        }
        if (Object.op_Inequality((Object) clip, (Object) null))
        {
          num1 = clip.length;
          if (flag)
          {
            this.딟.CrossFade(obj0, num2, (PlayMode) 4);
          }
          else
          {
            this.딟.Stop(obj0);
            this.딟.Play(obj0, (PlayMode) 4);
          }
        }
        else
          Debug.LogWarning((object) ("Missing anim: " + obj0 + " on " + this.ToString()));
      }
      this.땄 = num1;
      return num1;
    }

    public float 땄([In] string obj0, [In] WrapMode obj1)
    {
      float num = 0.0f;
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        this.딟.wrapMode = obj1;
        AnimationClip clip = this.딟.GetClip(obj0);
        if (Object.op_Inequality((Object) clip, (Object) null))
        {
          num = clip.length;
          this.딟.CrossFadeQueued(obj0, 0.2f, (QueueMode) 0, (PlayMode) 4);
        }
      }
      return num;
    }

    public void 딟([In] AudioShader2 obj0) => this.딟(obj0, this.딣());

    public void 딟([In] AudioShader2 obj0, [In] GameObject obj1)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      double num = (double) obj0.PlayOneShot(obj1);
    }

    public GameObject 딟([In] AudioShader2 obj0, [In] float obj1, [In] float obj2, [In] float obj3) => Object.op_Inequality((Object) obj0, (Object) null) ? obj0.PlayLooping(this.딣(), obj1, obj2, obj3) : (GameObject) null;

    public void 떏()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.Stop();
    }

    public void 땼() => this.딟.딟(this, false);

    public void 땢() => this.딟.딟(this);

    public void 딷() => this.딟.땄(this);

    public void 떁() => this.땄 = this.땴().딧 <= 0;

    public void 딢([In] bool obj0)
    {
      if (obj0)
        this.땄 = !obj0;
      else
        this.떁();
    }

    public void 땃([In] bool obj0)
    {
      this.딟 = !obj0;
      this.땄(false);
    }

    public static Transform 딟([In] Transform obj0, [In] string obj1)
    {
      if (((Object) obj0).name == obj1)
        return obj0;
      for (int index = 0; index < obj0.childCount; ++index)
      {
        Transform transform = 땦.딟(obj0.GetChild(index), obj1);
        if (Object.op_Inequality((Object) transform, (Object) null))
          return transform;
      }
      return (Transform) null;
    }

    public Transform 땄([In] string obj0) => Object.op_Equality((Object) this.딣(), (Object) null) ? (Transform) null : 땦.딟(this.딣().transform, obj0);

    public void 딟([In] Transform obj0, [In] float obj1)
    {
      Transform transform = Object.Instantiate((Object) obj0) as Transform;
      transform.parent = this.딣().transform;
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.identity;
      Object.Destroy((Object) ((Component) transform).gameObject, obj1);
    }

    public void 땟()
    {
      if (Object.op_Equality((Object) this.딣(), (Object) null))
        return;
      this.딟.딧 = this.땴().딢(딢.떍.딢) > 0;
      if (!this.딟.땓())
        return;
      TacticsGameAssets gameAssets = GlobalAppData.딟.GameAssets;
      foreach (Renderer componentsInChild in this.딣().GetComponentsInChildren<Renderer>())
      {
        foreach (Material material in componentsInChild.materials)
        {
          if (this.딟.땄() == 땦.떃.딢)
          {
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.CharShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.CharHiddenShader))
              material.shader = gameAssets.CharTransparentShader;
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.CharTransparentShader))
              material.color = new Color((float) material.color.r, (float) material.color.g, (float) material.color.b, this.딟.딟());
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponHiddenShader))
              material.shader = gameAssets.WeaponTransparentShader;
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponTransparentShader))
              material.color = new Color((float) material.color.r, (float) material.color.g, (float) material.color.b, this.딟.딟());
          }
          else if (this.딟.땄() == 땦.떃.딧)
          {
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.CharShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.CharTransparentShader))
              material.shader = gameAssets.CharHiddenShader;
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponTransparentShader))
              material.shader = gameAssets.WeaponHiddenShader;
          }
          else
          {
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.CharHiddenShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.CharTransparentShader))
              material.shader = gameAssets.CharShader;
            if (Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponHiddenShader) || Object.op_Equality((Object) material.shader, (Object) gameAssets.WeaponTransparentShader))
              material.shader = gameAssets.WeaponShader;
          }
        }
      }
    }

    public Vector3 땂()
    {
      Bounds bounds;
      // ISSUE: explicit constructor call
      ((Bounds) ref bounds).\u002Ector(this.딣().transform.position, Vector3.zero);
      foreach (SkinnedMeshRenderer componentsInChild in this.딣().GetComponentsInChildren<SkinnedMeshRenderer>())
        ((Bounds) ref bounds).Encapsulate(((Renderer) componentsInChild).bounds);
      return ((Bounds) ref bounds).center;
    }

    [SpecialName]
    public bool 딱() => Object.op_Inequality((Object) this.딣(), (Object) null);

    [SpecialName]
    public bool 때() => this.딟.딷().땜() == this || this.딟.딷().땈() == this;

    public virtual void 땩() => this.땥(false);

    public void 딟([In] Vector3 obj0)
    {
      this.땄(obj0);
      if (!Object.op_Inequality((Object) this.딣(), (Object) null))
        return;
      this.딣().transform.position = obj0;
    }

    public void 딟([In] bool obj0, [In] bool obj1)
    {
      if (obj0)
      {
        if (obj1)
          this.딟.딢();
        else
          this.딟.딶();
      }
      else if (obj1)
        this.딟.딧();
      else
        this.딟.땃();
    }

    public void 땠()
    {
      if (딶.딡.땴() == null || this.땴().땺() || Object.op_Equality((Object) this.딟, (Object) null))
        return;
      string str = 딶.딡.땴().땼().땻()[this.땔()].딟(this.땴(), 딺.딟);
      if (str == null)
        return;
      this.딟.wrapMode = (WrapMode) 1;
      if (!Object.op_Inequality((Object) this.딟.GetClip(str), (Object) null))
        return;
      this.딟.CrossFadeQueued(str, 0.05f, (QueueMode) 0, (PlayMode) 4);
    }

    public void 딶([In] bool obj0) => this.딟(obj0, true);

    [CompilerGenerated]
    [SpecialName]
    public 땊 땴() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Vector3 딗() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] Vector3 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public Quaternion 땳() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] Quaternion obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땻() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public void 땓([In] bool obj0) => this.딢 = obj0;

    [SpecialName]
    public bool 딥() => this.딟.땄;

    [SpecialName]
    public void 땺([In] bool obj0) => this.딟.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 떓() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] int obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 딛() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] int obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public GameObject 딣() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 땔() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public 딵 땁() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 딵 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땷() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public void 땥([In] bool obj0) => this.땃 = obj0;

    private enum 떃
    {
      딟,
      땄,
      딧,
      딢,
    }

    private struct 땆
    {
      private const float 딟 = 1.666667f;
      public bool 딟;
      public bool 땄;
      public bool 딧;

      [CompilerGenerated]
      [SpecialName]
      public float 딟() => this.땄;

      [CompilerGenerated]
      [SpecialName]
      public 땦.떃 땄() => this.딟;

      public void 딧() => this.딟 = true;

      public void 딢() => this.딟 = false;

      public void 땃()
      {
        this.딧();
        // ISSUE: reference to a compiler-generated method
        this.딟(0.0f);
      }

      public void 딶()
      {
        this.딢();
        // ISSUE: reference to a compiler-generated method
        this.딟(1f);
      }

      public bool 땓()
      {
        땦.떃 떃 = this.땄();
        float num1;
        if (this.딟)
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(땦.떃.딢);
          num1 = 0.0f;
        }
        else if (this.땄)
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(땦.떃.딧);
          num1 = 1f;
        }
        else if (this.딧)
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(땦.떃.딢);
          num1 = GlobalAppData.딟.GameAssets.GhostVisFrac;
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(땦.떃.땄);
          num1 = 1f;
        }
        float num2 = this.딟();
        if ((double) this.딟() < (double) num1)
        {
          float num3 = Time.deltaTime * 1.666667f;
          // ISSUE: reference to a compiler-generated method
          this.딟(Mathf.Min(this.딟() + num3, num1));
        }
        else if ((double) this.딟() > (double) num1)
        {
          float num4 = Time.deltaTime * 1.666667f;
          // ISSUE: reference to a compiler-generated method
          this.딟(Mathf.Max(this.딟() - num4, num1));
        }
        return (double) num2 != (double) this.딟() || 떃 != this.땄();
      }
    }
  }
}
