using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoLoja.DTO;
using ProjetoLoja.BLL;

namespace ProjetoLoja.UI
{
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                IList<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();
                listUsuarioDTO = new UsuarioBLL().carregarUsuario();

                //Preencher dados do GridView
                dgvControleCadastro.DataSource = listUsuarioDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
