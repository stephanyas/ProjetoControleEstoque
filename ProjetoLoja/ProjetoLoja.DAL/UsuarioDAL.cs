using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoja.DTO;

namespace ProjetoLoja.DAL
{
    public class UsuarioDAL
    {

        //Metodo carregarUsuario, retorna uma lista de objetos UsuarioDTO         
        public IList<UsuarioDTO> carregarUsuario()
        {
            try
            {
                //Conexão com o banco de dados
                //Seleciona todos os dados da tabela Usuario
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "SELECT*FROM Usuario";
                CM.Connection = CON;

                SqlDataReader ER;
                IList<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();

                CON.Open();
                ER = CM.ExecuteReader();
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        UsuarioDTO usuario = new UsuarioDTO();

                        /*
                        Nome dos objetos criados na DTO, cada objeto criado e enviado para a lista,
                        possibilitando que no final tenha uma lista com vários usuários
                        */
                        usuario.IdUsuario = Convert.ToInt32(ER["IdUsuario"]);
                        usuario.PerfilUsuario = Convert.ToInt32(ER["PerfilUsuario"]);
                        usuario.CadastroUsuario = Convert.ToDateTime(ER["cadastroUsuario"]);
                        usuario.NomeUsuario = Convert.ToString(ER["NomeUsuario"]);
                        usuario.LoginUsuario = Convert.ToString(ER["LoginUsuario"]);
                        usuario.SenhaUsuario = Convert.ToString(ER["Senhausuario"]);
                        usuario.EmailUsuario = Convert.ToString(ER["EmailUsuario"]);
                        usuario.SituacaoUsuario = Convert.ToString(ER["SituacaoUsuario"]);
                        listUsuarioDTO.Add(usuario);
                    }
                }
                return listUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para inserir um novo usuario ao BD
        public int insereUsuario(UsuarioDTO usuario)
        {
            try
            {
                //Conexão com o banco de dados
                //Inserindo dados na tabela Usuario
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "INSERT INTO Usuario (NomeUsuario, LoginUsuario, SenhaUsuario, EmailUsuario, CadastroUsuario, SituacaoUsuario, PerfilUsuario)" +
                    "VALUES (@NomeUsuario, @LoginUsuario, @SenhaUsuario, @EmailUsuario, @CadastroUsuario, @SituacaoUsuario, @PerfilUsuario)";
                //Parameters vai substituir os valores dentro do campo
                CM.Parameters.Add("NomeUsuario", System.Data.SqlDbType.VarChar).Value = usuario.NomeUsuario;
                CM.Parameters.Add("LoginUsuario", System.Data.SqlDbType.VarChar).Value = usuario.LoginUsuario;
                CM.Parameters.Add("SenhaUsuario", System.Data.SqlDbType.VarChar).Value = usuario.SenhaUsuario;
                CM.Parameters.Add("EmailUsuario", System.Data.SqlDbType.VarChar).Value = usuario.EmailUsuario;
                CM.Parameters.Add("CadastroUsuario", System.Data.SqlDbType.DateTime).Value = usuario.CadastroUsuario;
                CM.Parameters.Add("SituacaoUsuario", System.Data.SqlDbType.NVarChar).Value = usuario.SituacaoUsuario;
                CM.Parameters.Add("PerfilUsuario", System.Data.SqlDbType.Int).Value = usuario.PerfilUsuario;
                CM.Connection = CON;

                CON.Open();
                int quantidade = CM.ExecuteNonQuery();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para editar um usuario ja existente
        public int editarUsuario(UsuarioDTO usuario)
        {
            try
            {
                //Conexão com o banco de dados
                //Alterando os dados na tabela Usuario
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "UPDATE Usuario SET NomeUsuario = @NomeUsuario," + "LoginUsuario = @LoginUsuario," + "SenhaUsuario = @SenhaUsuario," +
                                 "EmailUsuario = @EmailUsuario," + "CadastroUsuario = @CadastroUsuario," + "SituacaoUsuario = @SituacaoUsuario," +
                                 "PerfilUsuario = @PerfilUsuario)" + "WHERE IdUsuario = @IdUsuario";
                //Parameters vai substituir os valores dentro do campo
                CM.Parameters.Add("NomeUsuario", System.Data.SqlDbType.VarChar).Value = usuario.NomeUsuario;
                CM.Parameters.Add("LoginUsuario", System.Data.SqlDbType.VarChar).Value = usuario.LoginUsuario;
                CM.Parameters.Add("SenhaUsuario", System.Data.SqlDbType.VarChar).Value = usuario.SenhaUsuario;
                CM.Parameters.Add("EmailUsuario", System.Data.SqlDbType.VarChar).Value = usuario.EmailUsuario;
                CM.Parameters.Add("CadastroUsuario", System.Data.SqlDbType.DateTime).Value = usuario.CadastroUsuario;
                CM.Parameters.Add("SituacaoUsuario", System.Data.SqlDbType.NVarChar).Value = usuario.SituacaoUsuario;
                CM.Parameters.Add("PerfilUsuario", System.Data.SqlDbType.Int).Value = usuario.PerfilUsuario;
                CM.Parameters.Add("IdUsuario", System.Data.SqlDbType.VarChar).Value = usuario.IdUsuario;
                CM.Connection = CON;

                CON.Open();
                int quantidade = CM.ExecuteNonQuery();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deletarUsuario(UsuarioDTO usuario)
        {
            try
            {
                //Conexão com o banco de dados
                //Excluindo os dados na tabela Usuario
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "DELETE Usuario WHERE IdUsuario = @IdUsuario";

                //Tem um unico parametro que sera o cpodigo usuario, só existe um           
                CM.Parameters.Add("IdUsuario", System.Data.SqlDbType.VarChar).Value = usuario.IdUsuario;

                CM.Connection = CON;

                CON.Open();
                //Retorna registro afetados
                int quantidade = CM.ExecuteNonQuery();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
