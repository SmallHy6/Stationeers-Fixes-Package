using System;
using System.Threading.Tasks;
using Stationeers_Fixes_Package;

namespace Language_Delay_Refuse
{
  class Program
  {
    static void Main(string[] args)
    {
      {
        string[] FileName = new string[4];
        var Main = new BepinExTool();
        if (args.Length != 6)
        {
          Main.ExternalMessage("字符串修复", "True", $"传参个数[6],实际[{args.Length}]");
        }
        string DestLanguageFilePath = args[0];
        for (int i = 0, ii = 1; i < 4; i++, ii++)
        {
          FileName[i] = args[ii];
        }
        try
        {
          for (int i = 0; i < 4; i++)
          {
            File.Move($"{DestLanguageFilePath}Language/{FileName[i]}.Backup.xml", $"{DestLanguageFilePath}{FileName[i]}.xml");
            Main.ExternalMessage("字符串修复", "", "字符串修复.复原字符表成功!");
          }
        }
        catch (IOException ex)
        {
          if (ex != null)
          {
            Main.ExternalMessage("字符串修复", "True", "RollingCopy:Exception");
          }
        }
        catch (Exception ex)
        {
          if (ex != null)
          {
            Main.ExternalMessage("字符串修复", "True", "RollingCopy:Exception");
          }
        }
      }
    }
  }
}