using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.CustomDataAnnotation
{
    public class NoTrashEmailAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            // Note : Obtenir la liste depuis la base de donnée
            List<string> trashProvider = new List<string>()
            {
                "yopmail.com",
                "yopmail.fr",
                "yopmail.net",
                "cool.fr.nf",
                "jetable.fr.nf",
                "nospam.ze.tc",
                "nomail.xl.cx",
                "mega.zik.dj",
                "speed.1s.fr",
                "courriel.fr.nf",
                "moncourrier.fr.nf",
                "monemail.fr.nf",
                "monmail.fr.nf"
            };

            if(value != null)
            {
                string mail = value.ToString();
                return !trashProvider.Where(p => mail.Contains(p)).Any();
            }

            return true;
        }


    }
}