using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.ServicesData;
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
            memberService.InsertMember(member);

            // Redirection vers la page Home
            return RedirectToAction("Index", "Home");
        }
    }
}