using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Diagnostics.Eventing.Reader;

namespace PROJETO_MARCELO___EDITOR_DE_TEXTO
{
    public partial class Form1 : Form
    {
        StringReader ler = null;
        bool alterado;
        public Form1()
        {
            InitializeComponent();
            this.Text = "";
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            alterado = true;
        }



        private void Novo()
        {
            string palavras = null;
            palavras = richTextBox1.Text;

            if (palavras != "")
            {
                DialogResult dr = MessageBox.Show("Deseja salvar antes de iniciar um arquivo novo? ", "Deseja salvar arquivo editado? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter peaky_blinders = new StreamWriter(arquivo);
                            peaky_blinders.Flush();
                            peaky_blinders.BaseStream.Seek(0, SeekOrigin.Begin);
                            peaky_blinders.Write(this.richTextBox1.Text);
                            peaky_blinders.Flush();
                            peaky_blinders.Close();
                            richTextBox1.Clear();
                            richTextBox1.Focus();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro na criação do arquivo: " + ex.Message, "Erro na Criação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Arquivo não salvo");
                    richTextBox1.Clear();
                    richTextBox1.Focus();
                    
                }
            }
            
        }

        private void Salvar(String teste)
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter peaky_blinders = new StreamWriter(arquivo);
                    peaky_blinders.Flush();
                    peaky_blinders.BaseStream.Seek(0, SeekOrigin.Begin);
                    peaky_blinders.Write(this.richTextBox1.Text);
                    peaky_blinders.Flush();
                    peaky_blinders.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na criação do arquivo: " + ex.Message, "Erro na Criação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void salvarComo()
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Salvar(saveFileDialog1.FileName);
            }
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir arquivo";
            openFileDialog1.InitialDirectory = @"C:\Área de Trabalho\";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName,FileMode.Open,FileAccess.Read);
                    StreamReader peaky_blinders = new StreamReader(arquivo);
                    peaky_blinders.BaseStream.Seek(0,SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = peaky_blinders.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = peaky_blinders.ReadLine();
                    }
                    peaky_blinders.Close();

                }catch(Exception ex)
                {
                    MessageBox.Show("Erro de leitura do arquivo" + ex.Message, "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            
        }

        private void negrito()
        {
            string fonte = null;
            float tamanho_fonte = 0;
            bool negrito, italico, sublinhado = false;

            fonte = richTextBox1.Font.Name;
            tamanho_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Regular);

            if (negrito == false)
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (italico == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold);
                }

            }
            else
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Underline);
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic);
                }



            }
        }

        private void italico()
        {
            string fonte = null;
            float tamanho_fonte = 0;
            bool negrito, italico, sublinhado = false;

            fonte = richTextBox1.Font.Name;
            tamanho_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Regular);

            if (italico == false)
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic | FontStyle.Bold);
                }
                else if (negrito == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic);
                }

            }
            else
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Underline);
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold);
                }

            }

        }


        private void sublinhado()
        {
            string fonte = null;
            float tamanho_fonte = 0;
            bool negrito, italico, sublinhado = false;

            fonte = richTextBox1.Font.Name;
            tamanho_fonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Regular);

            if (sublinhado == false)
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Underline | FontStyle.Bold);
                }
                else if (negrito == false & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Underline);
                }

            }
            else
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold);
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Italic);
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(fonte, tamanho_fonte, FontStyle.Bold);
                }

            }

        }

        private void fonte ()
        {
            FontDialog fonte = new FontDialog();
            fonte.Font = richTextBox1.Font;
            fonte.ShowDialog();
            richTextBox1.Font = fonte.Font;
        }

        private void copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        private void colar()
        {
            richTextBox1.Paste();
        }

        private void esquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void direita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void centro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }


        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            string arquivo = this.richTextBox1.Text;
            ler = new StringReader(arquivo);
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float pagina = 0;
            float y = 0;
            int contador = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if (margemEsquerda < 5)
            {
                margemEsquerda = 20;

            }

            if (margemSuperior < 5)
            {
                margemSuperior = 20;

            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(richTextBox1.BackColor);
            pagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = ler.ReadLine();
            while (contador < pagina)
            {
                y = (margemSuperior + (contador * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, y, new StringFormat());
                contador += 1;
                linha = ler.ReadLine();
            }
            if (linha != null)
            {
                e.HasMorePages = true;

            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }

        private void selecionarcor()
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && colorDialog1.Color != richTextBox1.SelectionColor)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }


        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            if (!alterado)
            {
                this.Abrir();
            }
            else
            {
                if (MessageBox.Show("Seu arquivo foi alterado. Deseja Salvar?", "Deseja Salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Abrir();
                }
                else
                {
                    if (this.Text != "")
                    {
                        this.Salvar(this.Text);
                    }
                    else
                    {
                        this.salvarComo();
                    }
                }

            }
        }

      
        private void desenvolvedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Desenvolvedores f_Desenvolvedores = new F_Desenvolvedores();
            f_Desenvolvedores.Show();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                this.Salvar(this.Text);
            }
            else
            {
                this.salvarComo();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                this.Salvar(this.Text);
            }
            else
            {
                this.salvarComo();
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.salvarComo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!alterado)
            {
                this.Abrir();
            }
            else
            {
                if(MessageBox.Show("Seu arquivo foi alterado. Deseja Salvar?", "Deseja Salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Abrir();
                }
                else
                {
                    if(this.Text != "")
                    {
                        this.Salvar(this.Text);
                    } else
                    {
                        this.salvarComo();
                    }
                }
               
                
            }
           
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colar();
        }

        

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            italico();
        }

        private void subliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sublinhado();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            esquerda();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esquerda();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            direita();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            direita();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            centro();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            centro();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        

        private void configuraçõesDePaginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetup.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_fonte_Click(object sender, EventArgs e)
        {
            fonte();
        }

        private void fonteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fonte();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void esconderToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selecionarcor();
        }

        private void imagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
         F_imagem f_Imagem = new F_imagem();
            f_Imagem.Show();
            
        }

       
    }
}
        
