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
    public partial class F_imagem : Form
    {
        public F_imagem()
        {
            InitializeComponent();
        }

        private void F_imagem_Load(object sender, EventArgs e)
        {
            // Abre uma caixa de diálogo para o usuário selecionar um arquivo de imagem
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string caminhoDaImagem = openFileDialog.FileName;

                // Carrega a imagem no PictureBox
                CarregarImagem(caminhoDaImagem);
            }
        }

        private void CarregarImagem(string caminhoDaImagem)
        {
            try
            {
                // Carrega a imagem a partir do caminho especificado
                Image imagem = Image.FromFile(caminhoDaImagem);

                // Define a imagem no PictureBox
                pictureBox1.Image = imagem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

