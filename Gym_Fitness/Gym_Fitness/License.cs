using Gym_Fitness.LicenseService;
using License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LicenseRequest = Gym_Fitness.LicenseService.LicenseRequest;

namespace Gym_Fitness
{
    public class License
    {
       static BasicHttpBinding Binding
        {
            get
            {
                return new BasicHttpBinding();
            }
        }
       static EndpointAddress EndPoint
        {
            get
            {
                return new EndpointAddress("http://localhost:65324/LicenseKey.asmx");
            }
        }
       static LicenseKeySoapClient Client
        {
            get 
            {
                return new LicenseKeySoapClient(Binding, EndPoint);

            }
        }
        public static string Text
        {
            // 8b7621f5-fc45-4349-97c9-c7c051b4a32f 1.
            // 7d9d08f2-535b-418d-be1d-4ca27f97fe6c 2.
            get
            {
                int i = DateTime.Now.Day;
                
                return $"{i*i}d{i}d08f{i*i-2/5}-535b-418d-be1d-4ca27f97fe{i/i}c";
                        
            }
        }
        public static bool LicenseCheck(string key)
        {
            LicenseRequest request = new LicenseRequest();
            request.Key = key;
            request.HDD = HDDNumber();
            request.History = DateTime.Now;
            request.Hash = Hash(key + request.HDD, Text);

            var reply = Client.LicenseVerification(request);
            // cevap Hash kontrol
            return reply.VerificationCode == 1;

           
        }
         public static string HDDNumber()
         {
                ManagementObjectSearcher ms = new ManagementObjectSearcher("Select * from Win32_PhysicalMedia");
                var r = ms.Get();
                string sn = "";
                foreach (var item in r)
                {
                    sn = item["SerialNumber"].ToString();
                    break;
                }
                return sn;
         }
        public static string Hash(string text, string key)
        {
            HMACMD5 md = new HMACMD5(Encoding.UTF8.GetBytes(key));
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            byte[] hash = md.ComputeHash(buffer);
            string res = string.Empty;
            foreach (byte item in hash)
            {
                res += item.ToString("x2"); 
            }
            return res;
        }
          
    }
}