// Decompiled with JetBrains decompiler
// Type: 땥.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 딩
  {
    private static List<char> 딟 = new List<char>()
    {
      '/',
      '<',
      '>',
      '='
    };
    private 떋 딟;
    private 딴 딟;

    public 딩([In] Stream obj0) => this.딟(obj0);

    public 딩([In] string obj0)
    {
      using (FileStream fileStream = new FileStream(obj0, FileMode.Open, FileAccess.Read))
        this.딟((Stream) fileStream);
    }

    [SpecialName]
    public 딴 딟() => this.딟;

    public void 딟([In] Stream obj0) => this.딟 = new 떋(obj0);

    public static 딴 딟([In] string obj0)
    {
      딩 딩 = new 딩(obj0);
      딩.땃();
      return 딩.딟();
    }

    public static 딴 땄([In] Stream obj0)
    {
      딩 딩 = new 딩(obj0);
      딩.땃();
      return 딩.딟();
    }

    private string 땄()
    {
      string empty = string.Empty;
      bool flag = false;
      do
      {
        char c = this.딟.딢();
        if (딩.딟.Contains(c))
        {
          if (empty != string.Empty)
          {
            떋 딟 = this.딟;
            딟.딟(딟.땄() - 1);
            break;
          }
          flag = true;
        }
        else if (char.IsWhiteSpace(c))
        {
          if (!(empty != string.Empty))
            continue;
          break;
        }
        empty += (string) (object) c;
      }
      while (!flag);
      string str = this.땄(empty);
      if (str[0] == '"')
        str = str.Remove(0, 1);
      if (str[str.Length - 1] == '"')
        str = str.Remove(str.Length - 1, 1);
      return str;
    }

    private string 딧()
    {
      int num = this.딟.땄();
      string str = this.땄();
      this.딟.딟(num);
      return str;
    }

    private string 딟([In] char obj0)
    {
      string str = string.Empty;
      while (true)
      {
        char ch = this.딟.딢();
        if ((int) ch != (int) obj0)
          str += (string) (object) ch;
        else
          break;
      }
      떋 딟 = this.딟;
      딟.딟(딟.땄() - 1);
      if (str[0] == '"')
        str = str.Remove(0, 1);
      if (str[str.Length - 1] == '"')
        str = str.Remove(str.Length - 1, 1);
      return str;
    }

    private string 땄([In] string obj0)
    {
      string str = obj0;
      int num = 0;
      while (num != str.Length)
      {
        if (char.IsControl(str[num]))
          str = str.Remove(num, 1);
        else
          ++num;
      }
      return str;
    }

    private string 딧([In] string obj0)
    {
      int startIndex = obj0.IndexOf('>') + 1;
      int num = obj0.LastIndexOf('<');
      return this.땄(obj0.Substring(startIndex, num - startIndex));
    }

    public 딴 딢()
    {
      if (this.딟.딶())
        return (딴) null;
      int startIndex = this.딟.땄();
      string str1 = this.땄();
      if (str1 != "<")
        throw new 땀("Expected \"<\", got " + str1);
      딴 딴 = new 딴();
      딴.딟(this.땄());
      string str2;
      while (true)
      {
        string str3 = this.땄();
        if (!(str3 == ">"))
        {
          if (!(str3 == "/"))
          {
            떍 떍 = new 떍();
            떍.딟(str3);
            if (!((str2 = this.땄()) != "="))
            {
              떍.땄(this.땄());
              딴.땄().Add(떍);
            }
            else
              goto label_9;
          }
          else
            break;
        }
        else
          goto label_11;
      }
      this.땄();
      딴.딧(this.땄(this.딟.딟().Substring(startIndex, this.딟.땄() - startIndex)).Trim());
      딴.딢(string.Empty);
      return 딴;
label_9:
      throw new 땀("Expected \"=\", got " + str2);
label_11:
      while (true)
      {
        int num = this.딟.땄();
        if (this.땄() == "<")
        {
          if (!(this.딧() == "/"))
          {
            this.딟.딟(num);
            딴.딟().Add(this.딢());
          }
          else
            break;
        }
        else
        {
          this.딟.딟(num);
          딴.땄(this.딟('<'));
        }
      }
      this.땄();
      string str4 = this.땄();
      this.땄();
      딴.딧(this.땄(this.딟.딟().Substring(startIndex, this.딟.땄() - startIndex)).Trim());
      딴.딢(this.딧(딴.땃()));
      return !(str4 != 딴.딧()) ? 딴 : throw new 땀("Mismatched element pairs: \"" + 딴.딧() + "\" vs \"" + str4 + "\"");
    }

    public void 땃()
    {
      this.딟 = this.딢();
      if (this.딟 == null)
        throw new 땀("Unable to load root node");
    }
  }
}
