using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System.Web.Routing;
namespace ChemAnalyst.Authorize
{
    public class Authorization : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (LoginStatus())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Admin" },
                                      { "action", "Index" }

                                        });
            }

        }
        public bool LoginStatus()
        {
            bool useHashing = true;
            string cipherString = ConfigurationManager.AppSettings["AuthTocken"];
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();

            string key = "workProgress";
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;


            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();

            if (DateTime.Now >= DateTime.Parse(UTF8Encoding.UTF8.GetString(resultArray)))
            {
                return true;
            }
            else
                return false;
        }
    }
}