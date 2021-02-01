using Demo_Redline_ASPMVC.DAL.Repositories;
using Demo_Redline_ASPMVC.WebApp.Mappers;
using Demo_Redline_ASPMVC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.ServicesData
{
    public class MemberService
    {
        private MemberRepository memberRepository;

        public MemberService()
        {
            memberRepository = new MemberRepository();
        }


        public bool CheckAccountExists(MemberRegister member)
        {
            return memberRepository.CheckAccountExists(member.Email, member.Pseudo);
        }

        public void InsertMember(MemberRegister member)
        {
            memberRepository.Insert(member.ToGlobal());
        }

        public MemberProfil GetMember(MemberLogin member)
        {
            DAL.Entities.Member m = memberRepository.GetByCredential(member.Identifiant, member.Password);
            return m.ToProfil();
        }
    }
}