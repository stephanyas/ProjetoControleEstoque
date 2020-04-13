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

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             Chamada do Form CadastroUsuario no formato de MDI, 
             ou seja para abrir dentro do form principal chama-se 
             a janela filha. (ChildForm), fica dentro da janela mãe
             */
            Form ChildForm = new CadastroUsuario();
            ChildForm.MdiParent = this;
            ChildForm.Show();

        }
    }
}
