using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class Member : IEntity<long>
    {
        public long Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long IdRole { get; set; }

        public Member(string pseudo, string email, string password)
        {
            this.Id = 0;
            this.IdRole = 0;
            this.Pseudo = pseudo;
            this.Email = email;
            this.Password = password;
        }

        public Member(long id, string pseudo, string email, string password, long idRole)
            : this(pseudo, email, password)
        {
            this.Id = id;
            this.IdRole = idRole;
        }
    }
}
