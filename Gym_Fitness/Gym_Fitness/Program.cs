using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Fitness
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string hash = License.Hash("Bilge", "kaya");
            string m = License.Text;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             var k = MyIni.GetValue("LicenseKey");
            Guid g;
            bool gDurum = Guid.TryParse(k,out g);
            bool license = License.LicenseCheck(k);
            string ms = License.HDDNumber();
            if (string.IsNullOrEmpty(k)||!gDurum||!license)
            {
                Form2 form = new Form2();
                if (form.ShowDialog()!=DialogResult.OK)
                {
                    return;
                }
            }
            Application.Run(new Login());
        }
    }
}
