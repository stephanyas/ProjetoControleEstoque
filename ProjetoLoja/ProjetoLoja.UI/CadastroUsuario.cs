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
        //Acionando um dos botoes esta variavel vai registrar e acionar o modo selecionado
        string modo = "";

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

        private void dgvControleCadastro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Linha que estiver selecionada aparecerá nos campos
            int selecionado = dgvControleCadastro.CurrentRow.Index;

            //Valor de cada datagrid será enviado ao seu respectivvo textbox
            txtNomeUsuario.Text = Convert.ToString(dgvControleCadastro["NomeUsuario", selecionado].Value);
            txtEmailUsuario.Text = Convert.ToString(dgvControleCadastro["EmailUsuario", selecionado].Value);
            txtLoginUsuario.Text = Convert.ToString(dgvControleCadastro["LoginUsuario", selecionado].Value);
            txtSenhaUsuario.Text = Convert.ToString(dgvControleCadastro["SenhaUsuario", selecionado].Value);
            txtCadastroUsuario.Text = Convert.ToString(dgvControleCadastro["CadastroUsuario", selecionado].Value);

            //Condição se a situação for igual a A então o combo ficara ativo se não inativo
            if(Convert.ToString(dgvControleCadastro["SituacaoUsuario", selecionado].Value) == "A")
            {
                cboSituacaoUsuario.Text = "Ativo";
            }
            else
            {
                cboSituacaoUsuario.Text = "Inativo";                
            }

            //Definindo o perfil usuario com o switch
            switch(Convert.ToString(dgvControleCadastro["PerfilUsuario", selecionado].Value))
            {
                case "1":
                    cboPerfilUsuario.Text = "Administrador";
                    break;
                case "2":
                    cboPerfilUsuario.Text = "Operador";
                    break;
                case "3":
                    cboPerfilUsuario.Text = "Gerencial";
                    break;
            }
        }

        //Metodo para limpar os campos
        private void limparCampos()
        {
            txtNomeUsuario.Text = "";
            txtEmailUsuario.Text = "";
            txtLoginUsuario.Text = "";
            txtSenhaUsuario.Text = "";
            txtCadastroUsuario.Text = "";
            cboPerfilUsuario.Text = "";
            cboSituacaoUsuario.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //Chamando método Limpar campos que foi criado
            limparCampos();

            //Inserindo data atual automaticamente no txtCadastroUsuario
            txtCadastroUsuario.Text = Convert.ToString(System.DateTime.Now);

            //Apos clicar no botão novo, aciona a variavel modo passa a ser novo incluindo um registro
            modo = "novo";
        }
    }
}
