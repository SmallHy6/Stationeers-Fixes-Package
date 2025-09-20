using System.Collections.Generic;
using UnityEngine.UI;

namespace Stationeers_Fixes_Package
{
  internal class UI_Config_Css
  {
    internal static readonly string TopBarText1 = "General";
    internal static readonly string TopBarText2 = "Function";
    internal static readonly Dictionary<string, string> UI_Config_Css_Dictionary = new Dictionary<string, string>();
  }
  internal class Create_Dictionary
  {
    internal static void Write_Dictionary()
    {
      UI_Config_Css.UI_Config_Css_Dictionary.Add("TopBarText1", UI_Config_Css.TopBarText1);
      UI_Config_Css.UI_Config_Css_Dictionary.Add("TopBarText2", UI_Config_Css.TopBarText2);
    }
  }
}