using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLoja.UI
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Chamada do form CadastroUsuario no formato de MDI 
              ou seja para aprir dentro do Controle principal
              chama-se janela filha, que fica dentro da janela mãe*/

            Form childForm = new CadastroUsuario();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
