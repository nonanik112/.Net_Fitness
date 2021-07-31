using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Fitness
{
    class MyIni
    {
     static string dosyaAdi = "ayar.ini";
        static string Path = "";
        static MyIni()
        {
            Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\" + dosyaAdi;
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
        }
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string Default, StringBuilder retVal, int size, string FilePath);
        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string section, string key, string value, string FilePath);

        public static string GetValue(string key)
        {
            StringBuilder ret = new StringBuilder();
            GetPrivateProfileString("", key, "", ret, 255, Path);
            return ret.ToString();
        }
        public static void SetValue(string key, string value)
        {
            WritePrivateProfileString("", key, value, Path);
        }
    }
}
