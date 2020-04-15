using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoja.DTO;
using ProjetoLoja.DAL;

namespace ProjetoLoja.BLL
{
    public class UsuarioBLL
    {
        /*
         Metodo que tras os dados da tabela Usuario para o grid
         */

        public IList<UsuarioDTO> carregarUsuario()
        {
            try
            {
                return new UsuarioDAL().carregarUsuario();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int insereUsuario( UsuarioDTO usuario)
        {
            //Insere usuario criado na DAL
            try
            {
                return new UsuarioDAL().insereUsuario(usuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
