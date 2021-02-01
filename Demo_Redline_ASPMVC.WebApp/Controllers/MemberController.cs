using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.ServicesData;
using Demo_Redline_ASPMVC.WebApp.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Redline_ASPMVC.WebApp.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Register()
        {
            return View(new MemberRegister());
        }

        [HttpPost]
        public ActionResult Register(MemberRegister member)
        {
            MemberService memberService = new MemberService();

            // Formulaire invalide
            if(!ModelState.IsValid)
            {
                // Retour au formulaire !
                return View(member);
            }

            // Check si l'email ou le pseudo exsite
            if(memberService.CheckAccountExists(member))
            {
                // Retour au formulaire !
                ModelState.AddModelError("Account", "Le compte existe déjà");
                return View(member);
            }

            // Save in DB
            MemberProfil profil = memberService.InsertMember(member);

            // Ajout en Session
            SessionHelper.Member = profil;
                
            // Redirection vers la page Home
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Login()
        {
            return View(new MemberLogin());
        }

        [HttpPost]
        public ActionResult Login(MemberLogin member)
        {
            MemberService memberService = new MemberService();

            if(!ModelState.IsValid)
            {
                return View(member);
            }

            MemberProfil profil = memberService.GetMember(member);

            if(profil == null)
            {
                ModelState.AddModelError("Account", "Bad credential");
                return View(member);
            }

            // Sauvegarde du Login dans la Session
            SessionHelper.Member = profil;

            // Redirection vers la page Home
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            SessionHelper.Disconnect();
            return RedirectToAction("Index", "Home");
        }
    }
}