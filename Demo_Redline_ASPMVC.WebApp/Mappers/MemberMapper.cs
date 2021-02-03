using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using C = Demo_Redline_ASPMVC.WebApp.Models;
using G = Demo_Redline_ASPMVC.DAL.Entities;

namespace Demo_Redline_ASPMVC.WebApp.Mappers
{
    public static class MemberMapper
    {
        public static G.Member ToGlobal(this C.MemberRegister member)
        {
            if (member == null) return null;

            return new G.Member(member.Pseudo, member.Email, member.Password);
        }

        public static C.MemberProfil ToProfil(this G.Member member)
        {
            if (member == null) return null;

            return new C.MemberProfil()
            {
                Id = member.Id,
                Pseudo = member.Pseudo,
                Role = (C.MemberProfil.RoleEnum)member.IdRole
            };
        }
    }
}