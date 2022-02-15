using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public class Imagem
        {
            static public object loadpic()
            {
                DAL dal = new DAL();
                 SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", 1),
             };
                return dal.executarScalar("select Img from Imagem where id=1", sqlParams);
            
            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Imagem", null);
            }

            static public int insertImagem(byte [] img )
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@img", img),
                
           };

                return dal.executarNonQuery("INSERT into Imagem (Img) VALUES(@img)", sqlParams);
            }
        }

        public class Login
        {
            static public DataTable login_info_request(String user_name, String password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@user_name", user_name),
                    new SqlParameter("@password", password)
                };

                return dal.executarReader("SELECT * FROM Conta WHERE user_name=@user_name AND password=@password", sqlParams);
            }
        }

        public class Funcionarios
        {
            static public DataTable Load1()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM funcionario", null);
            }

            static public int add_func(string nome, string email, int telefone, string morada, int NIF)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@nome", nome),
                    new SqlParameter("@email", email),
                    new SqlParameter("@telefone", telefone),
                    new SqlParameter("@morada", morada),
                    new SqlParameter("@nif", NIF)
                };

                return dal.executarNonQuery("INSERT INTO Funcionarios (nome, email, telefone, morada, NIF) VALUES (@nome, @email, @telefone, @morada, @nif)", sqlParams);
            }

            static public DataTable SalariosLoad()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT funcionario.Id, Nome, Apelido, NIF, Salario FROM funcionario INNER JOIN SalariosFunc ON funcionario.id = SalariosFunc.id", null);
            }

            static public DataTable Pesquisarfuncionario(String parametro1)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@parametro", parametro1 + "%")
                };

                return dal.executarReader("SELECT  funcionario.Id, Nome, Apelido, NIF, Salario FROM SalariosFunc inner join funcionario on SalariosFunc.ID = funcionario.id WHERE (Nome LIKE @parametro) OR (Apelido LIKE @parametro) OR (Morada LIKE @parametro) OR (Salario LIKE @parametro)  ", sqlParams);
            }

            static public DataTable FiltrarFuncionario(bool parametro)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@parametro", parametro)
                };

                return dal.executarReader("SELECT * FROM funcionario WHERE Ativo=@parametro", sqlParams);
            }

            static public int Update_Salarios(int ID,int Salario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@salario", Salario)          
                };

                return dal.executarNonQuery("UPDATE [SalariosFunc] SET [salario]=@salario  WHERE [ID]=@ID", sqlParams);
            }

            static public int register(int id, string Nome, string Apelido, string Email, string Morada, string NIF, int Telefone, byte[] img, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id",id),
                    new SqlParameter("@Nome", Nome),
                    new SqlParameter("@Apelido", Apelido),
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Morada", Morada),
                    new SqlParameter("@NIF", NIF),
                    new SqlParameter("@Telefone", Telefone),
                    new SqlParameter("@Foto",img),
                    new SqlParameter("@Ativo", Ativo)
                };
                return dal.executarNonQuery("INSERT into funcionario (id,Nome,Apelido,Email,Morada,NIF,Telefone,Foto,Ativo) VALUES(@Id,@Nome,@Apelido,@Email,@Morada,@NIF,@Telefone,@Foto,@Ativo)", sqlParams);
            }

            static public int Update_funcionario(int id, string nome, string Apelido, string Email, string Morada, int NIF, int Telefone, byte[] Foto)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Nome", nome),
                    new SqlParameter("@Apelido", Apelido),
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Morada", Morada),
                    new SqlParameter("@NIF", NIF),
                    new SqlParameter("@Telefone", Telefone),
                    new SqlParameter("@Foto", Foto)
                };

                return dal.executarNonQuery("UPDATE [funcionario] SET [Nome]=@Nome, [Apelido]=@Apelido, [Email]=@Email, [Morada]=@Morada, [NIF]=@NIF, [Telefone]=@Telefone, [Foto]=@Foto WHERE [Id]=@Id", sqlParams);
            }

            static public int Desativar_funcionario(int id, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Ativo", Ativo)
                };

                return dal.executarNonQuery("UPDATE [funcionario] SET [Ativo]=@Ativo WHERE [Id]=@Id", sqlParams);
            }

        }

        public class Clientes
        {

            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Cliente", null);
            }

            static public int Update_Cliente(int id, string nome, string sobrenome, string morada, string email, int telefone, int NIF, string localidade)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Nome", nome),
                    new SqlParameter("@Sobrenome", sobrenome),
                    new SqlParameter("@Morada", morada),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Telefone", telefone),
                    new SqlParameter("@NIF", NIF),
                    new SqlParameter("@Localidade", localidade)
                };

                return dal.executarNonQuery("UPDATE [Cliente] SET [Nome]=@Nome, [Sobrenome]=Sobrenome, [Morada]=@Morada, [Telefone]=@Telefone, [NIF]=@NIF, [Localidade]=@Localidade WHERE [Id]=@Id", sqlParams);
            }

            static public int insertCliente(int id, string nome, string sobrenome, string morada, string email, int telefone, int NIF, string localidade)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Nome", nome),
                    new SqlParameter("@Sobrenome", sobrenome),
                    new SqlParameter("@Morada", morada),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Telefone", telefone),
                    new SqlParameter("@NIF", NIF),
                    new SqlParameter("@Localidade", localidade)
                };

                return dal.executarNonQuery("INSERT INTO Cliente(Id,Nome,Sobrenome,Morada,Email,Telefone,NIF,Localidade) VALUES(@Id,@Nome,@Sobrenome,@Morada,@Email,@Telefone,@NIF,@Localidade)", sqlParams);
            }         
            
            static public DataTable PesquisarCliente(String parametro)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@parametro", parametro + "%")
                };

                return dal.executarReader("SELECT * FROM Cliente WHERE (Nome LIKE @parametro) OR (Sobrenome LIKE @parametro) OR (Morada LIKE @parametro) OR (Email LIKE @parametro) OR (Telefone LIKE @parametro) OR (Localidade LIKE @parametro)", sqlParams);
            }

            static public DataTable queryCliente(int id) {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }

            static public DataTable queryCliente_2(int id, string nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                 new SqlParameter("@Nome", nome)
                };
                return dal.executarReader("select * from Clientes where ID=@id and Nome=@nome", sqlParams);
            }

            static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }

            static public int updateCliente(string id, string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
            };
                return dal.executarNonQuery("update [Clientes] set [nome]=@nome, [morada]=@morada, [telefone]=@telefone where [id]=@id", sqlParams);
            }

            static public int Desativar_Cliente(int id)            
            {
                DAL dal = new DAL(); 
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id)
                };

                return dal.executarNonQuery("INSERT INTO Cliente_Desativado(Id, Nome, Sobrenome, Morada, Email, Telefone, NIF, Localidade) SELECT * FROM Cliente WHERE [Id]=@Id DELETE FROM Cliente WHERE [Id]=@Id", sqlParams);
            }

            static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }

        }

        public class Imoveis
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Imoveis", null);
            }

            static public int Inserir_Imoveis(int id, string proprietario, string tipo, int preco, int proposta_atual, string localidade, string estado, int area_util, int area_bruta, string estado_habitacao, int quartos, int casas_banho, int anos_construcao, char certificado_energetico, byte[] img, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@ID", id),
                    new SqlParameter("@Proprietario", proprietario),
                    new SqlParameter("@Tipo", tipo),
                    new SqlParameter("@Preco", preco),
                    new SqlParameter("@Proposta_Atual", proposta_atual),
                    new SqlParameter("@Localidade", localidade),
                    new SqlParameter("@Estado", estado),
                    new SqlParameter("@Area_Util", area_util),
                    new SqlParameter("@Area_Bruta", area_bruta),
                    new SqlParameter("@Estado_Habitacao", estado_habitacao),
                    new SqlParameter("@Quartos", quartos),
                    new SqlParameter("@Casas_Banho", casas_banho),
                    new SqlParameter("@Anos_Construcao", anos_construcao),
                    new SqlParameter("@Certificado_Energetico", certificado_energetico),
                    new SqlParameter("@Foto", img),
                    new SqlParameter("@Ativo", ativo)
                };

                return dal.executarNonQuery("INSERT INTO Imoveis (Id,proprietario,tipo,preco,proposta_atual,Localidade,Estado,Area_Util,Area_Bruta,Estado_Habitacao,Quartos,Casas_Banho,Anos_Construcao,Certificado_Energetico,foto,Ativo) VALUES(@ID,@Proprietario,@Tipo,@Preco,@Proposta_Atual,@Localidade,@Estado,@Area_Util,@Area_Bruta,@Estado_Habitacao,@Quartos,@Casas_Banho,@Anos_Construcao,@Certificado_Energetico,@Foto,@Ativo)", sqlParams);
            }

            static public int Atualizar_Imovel(int id, string proprietario, string tipo, int preco, int proposta_atual, string localidade, string estado, int area_util, int area_bruta, string estado_habitacao, int quartos, int casas_banho, int anos_construcao, char certificado_energetico, byte[] img, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@ID", id),
                    new SqlParameter("@Proprietario", proprietario),
                    new SqlParameter("@Tipo", tipo),
                    new SqlParameter("@Preco", preco),
                    new SqlParameter("@Proposta_Atual", proposta_atual),
                    new SqlParameter("@Localidade", localidade),
                    new SqlParameter("@Estado", estado),
                    new SqlParameter("@Area_Util", area_util),
                    new SqlParameter("@Area_Bruta", area_bruta),
                    new SqlParameter("@Estado_Habitacao", estado_habitacao),
                    new SqlParameter("@Quartos", quartos),
                    new SqlParameter("@Casas_Banho", casas_banho),
                    new SqlParameter("@Anos_Construcao", anos_construcao),
                    new SqlParameter("@Certificado_Energetico", certificado_energetico),
                    new SqlParameter("@Foto", img),
                    new SqlParameter("@Ativo", ativo)
                };

                return dal.executarNonQuery("UPDATE [Imoveis] SET [Id]=@ID, [Proprietario]=@proprietario, [tipo]=@Tipo, [preco]=@Preco, [proposta_atual]=@Proposta_Atual, [Localidade]=@Localidade, [Estado]=@Estado, [Area_Util]=@Area_Util, [Area_Bruta]=@Area_Bruta, [Estado_Habitacao]=@Estado_Habitacao, [Quartos]=@Quartos, [Casas_Banho]=@Casas_Banho, [Anos_Construcao]=@Anos_Construcao, [Certificado_Energetico]=@Certificado_Energetico, [foto]=@Foto, [Ativo]=@Ativo WHERE Id=@ID", sqlParams);
            }

            static public int Desativar_imovel(int id, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Ativo", Ativo)
                };

                return dal.executarNonQuery("UPDATE [Imoveis] SET [Ativo]=@Ativo WHERE [Id]=@Id", sqlParams);
            }

        }
    }
}