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
        /*
         Metodo carregarUsuario, retorna uma lista de objetos UsuarioDTO
         */
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
