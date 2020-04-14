using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoja.DTO
{
    public class UsuarioDTO
    {
        //Nesta classe DTO temos os atributos dos objetos
        //Public para que ele seja acessivel externamente
        //Propriedade GET e Set para acessar o conteúdo

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime CadastroUsuario { get; set; }
        public string SituacaoUsuario { get; set; }
        public int PerfilUsuario { get; set; }
    }
}
