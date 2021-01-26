using Demo_Redline_ASPMVC.DAL.Entities;
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
            // TODO : Utiliser une procedure stockée qui obtient le membre sur base du mot de passe hashé en base de donnée
            QueryDB query = new QueryDB("SELECT * FROM Member WHERE (Email LIKE @login OR Pseudo LIKE @login) AND Password LIKE @pwd");
            query.AddParametre("@login", login);
            query.AddParametre("@pwd", password);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<Member> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM Member");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override Member Insert(Member entity)
        {
            //QueryDB queryRole = new QueryDB("SELECT id FROM [Role] WHERE Name = 'Member'");
            //long idRoleMember = (long)Connector.ExecuteScalar(queryRole);

            RoleRepository r = new RoleRepository();
            long idRoleMember = r.GetAll().Single(role => role.Name == "Member").Id;


            // TODO : Utiliser une procedure stockée qui hash le mot de passe dans la base de donnée
            QueryDB query = new QueryDB("INSERT INTO Member ([Pseudo],[Email],[Password],[Id_Role]) " +
                                        "OUTPUT inserted.* VALUES (@pseudo, @email, @pwd, @idRole");
            query.AddParametre("@pseudo", entity.Pseudo);
            query.AddParametre("@email", entity.Email);
            query.AddParametre("@pwd", entity.Password);
            query.AddParametre("@idRole", entity.IdRole);

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
