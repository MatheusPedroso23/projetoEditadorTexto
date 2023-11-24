using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO_MARCELO___EDITOR_DE_TEXTO
{
    public partial class F_Desenvolvedores : Form
    {
        public F_Desenvolvedores()
        {
            InitializeComponent();
        }

        private void btn_exibir_Click(object sender, EventArgs e)
        {
            label1.Text = Properties.Resources.nome1;
            label2.Text = Properties.Resources.nome2;
            label3.Text = Properties.Resources.nome3;
            label4.Text = Properties.Resources.nome4;
            label5.Text = Properties.Resources.nome5;

            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2023_10_30_at_22_56_34;
        }
    }
}
