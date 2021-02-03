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
        #region Singleton
        private static readonly Lazy<MemberService> _Instance = new Lazy<MemberService>(() => new MemberService());

        public static MemberService Instance
        {
            get { return _Instance.Value; }
        }
        #endregion

        private MemberRepository memberRepository;

        private MemberService()
        {
            memberRepository = new MemberRepository();
        }


        public bool CheckAccountExists(MemberRegister member)
        {
            return memberRepository.CheckAccountExists(member.Email, member.Pseudo);
        }

        public MemberProfil Get(long idMember)
        {
            return memberRepository.Get(idMember).ToProfil();
        }

        public MemberProfil InsertMember(MemberRegister member)
        {
            return memberRepository.Insert(member.ToGlobal()).ToProfil();
        }

        public MemberProfil GetMember(MemberLogin member)
        {
            DAL.Entities.Member m = memberRepository.GetByCredential(member.Identifiant, member.Password);
            return m.ToProfil();
        }
    }
}