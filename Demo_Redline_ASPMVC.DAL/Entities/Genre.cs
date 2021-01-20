using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    // Représentation sous la forme d'objet POCO de la table "genre"

    public class Genre : IEntity<long>
    {
        #region Field
        private long _IdGenre;
        private string _Name;
        #endregion

        #region Props
        public long Id
        {
            get { return _IdGenre; }
            set { _IdGenre = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        #endregion

        #region Constructor
        // Utiliser par l'application qui consome la DAL
        public Genre(string name)
        {
            this._IdGenre = 0;
            this._Name = name;
        }

        // Utiliser par la DAL, lors de la recuperation de donnée depuis la DB
        internal Genre(long idGenre, string name)
            : this(name)
        {
            this._IdGenre = idGenre;
        }
        #endregion




    }
}
