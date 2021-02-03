using Demo_Redline_ASPMVC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Session
{
    public static class SessionHelper
    {
        private const string MEMBER_DATA = "MemberData";


        public static MemberProfil Member
        {
            get
            {
                return HttpContext.Current.Session[MEMBER_DATA] as MemberProfil;
            }
            set
            {
                HttpContext.Current.Session[MEMBER_DATA] = value;
            }
        }

        public static bool IsLogged
        {
            get
            {
                return Member != null;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                return IsLogged && Member.Role == MemberProfil.RoleEnum.Admin;
            }
        }

        public static void Disconnect()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}