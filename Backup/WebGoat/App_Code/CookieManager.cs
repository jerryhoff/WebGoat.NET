using System;
using System.Web;
using System.Web.Security;

namespace OWASP.WebGoat.NET.App_Code
{
    public class CookieManager
    {
        public CookieManager()
        {
        }
        
        public static HttpCookie SetCookie(FormsAuthenticationTicket ticket, string cookieId, string cookieValue)
        {
            string encrypted_ticket = FormsAuthentication.Encrypt(ticket); //encrypt the ticket
 
            // put ticket into the cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted_ticket);

            //set expiration date
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
                
            return cookie;
            
            //TODO: Not sure if not adding this extra cookie will give us problems. Let's try and see.
//          response.Cookies.Add(cookie);

            //save the customerNumber as a cookie to fix the "server farm" issue we were facing
//            HttpCookie cookie_id = new HttpCookie("customerNumber", ds.Tables[0].Rows[0]["customerNumber"].ToString());
//            cookie_id.Expires = DateTime.Now.AddDays(14); //expires in 2 weeks
//            response.Cookies.Add(cookie_id);
        }
    }
}

