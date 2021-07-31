using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace License
{
    /// <summary>
    /// Summary description for LicenseKey
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LicenseKey : System.Web.Services.WebService
    {
 [WebMethod]
        public UndergraduateAnswer LicenseVerification(LicenseRequest request)
        {
           string ip = HttpContext.Current.Request.UserHostAddress;

            string hs = Hash(request.Key + request.HDD, Text);
            if (hs!= request.Hash)
            {
                return new UndergraduateAnswer {Key=request.Key,HDD=request.HDD,History=DateTime.Now,VerificationCode = 0 };
            }
             UndergraduateAnswer reply = new UndergraduateAnswer();
             reply.Key = request.Key;
             reply.HDD = request.HDD;
            if (request.Key == "7d9d08f2-535b-418d-be1d-4ca27f97fe6c" )
            {
                 reply.VerificationCode = 1;
            }
            else
            {
                reply.VerificationCode = 0;
            }

            return reply;
        }
         public static string Text
         {   // ca1473be-cbfb-46c8-9776-d69157eb1925
            // 8b7621f5-fc45-4349-97c9-c7c051b4a32f
            get
            {
                int i = DateTime.Now.Day;
                return $" {i*i}d{i}d08f{i*i-2/5}-535b-418d-be1d-4ca27f97fe{i/i}c";
            }

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
    
      public  class LicenseRequest
      {
         public LicenseRequest()
         {
            History = DateTime.Now;
         }
         public string Key { get; set; }

         public string HDD { get; set; }

         public DateTime History { get; set; }

         public string Hash { get; set; }

      }

     public class UndergraduateAnswer
     {
         public UndergraduateAnswer()
         {
             History = DateTime.Now;
         }
         public int VerificationCode { get; set; }

         public string Key { get; set; }

         public string HDD { get; set; }

         public DateTime History { get; set; }

         public string Hash { get; set; }
     }
}