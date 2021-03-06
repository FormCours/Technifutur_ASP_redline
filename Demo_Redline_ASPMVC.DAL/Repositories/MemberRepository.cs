﻿using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    public class MemberRepository : RepositoryBase<long, Member>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Member WHERE Id_Member = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override Member Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM Member WHERE Id_Member = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        /// <summary>
        /// </summary>
        /// <param name="login">Pseudo or Email of Member</param>
        /// <param name="password">Password of Member</param>
        /// <returns></returns>
        public Member GetByCredential(string login, String password)
        {
            // Utilisation d'une procedure stockée qui obtient le membre sur base du mot de passe hashé en base de donnée
            QueryDB query = new QueryDB("LoginMember", true);
            query.AddParametre("@login", login);
            query.AddParametre("@Password", password);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<Member> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM Member");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public bool CheckAccountExists(string email, string pseudo)
        {
            QueryDB query = new QueryDB("SELECT * FROM Member WHERE Email LIKE @email OR Pseudo LIKE @pseudo");
            query.AddParametre("@email", email);
            query.AddParametre("@pseudo", pseudo);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).Count() == 1;
        }

        public override Member Insert(Member entity)
        {
            // Utilisation d'une procedure stockée qui hash le mot de passe dans la base de donnée
            QueryDB query = new QueryDB("AddMember", true);
            query.AddParametre("@Pseudo", entity.Pseudo);
            query.AddParametre("@Email", entity.Email);
            query.AddParametre("@Password", entity.Password);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Member Update(long key, Member entity)
        {
            QueryDB query = new QueryDB("UPDATE Member " +
                                        "SET [Pseudo] = @pseudo, [Email] = @email, [Password] = @pwd, [Id_Role] = @idRole " +
                                        "OUTPUT inserted.* WHERE Id_Member = @Id");
            query.AddParametre("@Id", key); 
            query.AddParametre("@pseudo", entity.Pseudo);
            query.AddParametre("@email", entity.Email);
            query.AddParametre("@pwd", entity.Password);
            query.AddParametre("@idRole", entity.IdRole);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override Member ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new Member(
                (long)dataReader["Id_Member"],
                dataReader["Pseudo"].ToString(),
                dataReader["Email"].ToString(),
                null, // On ne récupère pas le mot de passe ;)
                (long)dataReader["Id_Role"]
            );
        }
    }
}
