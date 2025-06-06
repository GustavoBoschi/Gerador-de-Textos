using System.Windows.Forms;
using System.Drawing;
using iTextSharp.text.pdf;
using Novacode;

namespace GeradorTxt
{
    public class FormAbrir : Form
    {
        public FormAbrir()
        {
            this.Text = "Abrir Arquivo TXT";
            this.Icon = new Icon("IconeGeradorTXT.ico");
            this.Width = 1000;
            this.Height = 800;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(10, 10, 10);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var btnAbrirArquivo = new Button
            {
                Text = "Abrir Arquivo",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Width = 180,
                Height = 50,
                Top = 40,
                Left = 60
            };

            var btnVoltar = new Button
            {
                Text = "Voltar",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Width = 180,
                Height = 50,
                Top = 40,
                Left = btnAbrirArquivo.Left + btnAbrirArquivo.Width + 40
            };

            var rtxtConteudo = new RichTextBox
            {
                Font = new Font("Arial", 11),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, // Use o namespace completo para evitar ambiguidade
                Width = 880,
                Height = 600,
                Top = btnAbrirArquivo.Top + btnAbrirArquivo.Height + 30,
                Left = 60,
                ReadOnly = true
            };

            this.Controls.Add(btnAbrirArquivo);
            this.Controls.Add(btnVoltar);
            this.Controls.Add(rtxtConteudo);

            btnAbrirArquivo.Click += (s, e) =>
            {
                using (var ofd = new OpenFileDialog())
                {
                    // Coloque "Todos os arquivos" como primeira opção
                    ofd.Filter = "Todos os arquivos (*.*)|*.*|Arquivos de texto (*.txt)|*.txt|PDF (*.pdf)|*.pdf|Word (*.docx)|*.docx";
                    ofd.FilterIndex = 1; // 1 = "Todos os arquivos"
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string extensao = System.IO.Path.GetExtension(ofd.FileName).ToLower();
                        if (extensao == ".txt")
                        {
                            rtxtConteudo.Text = System.IO.File.ReadAllText(ofd.FileName);
                        }
                        else if (extensao == ".pdf")
                        {
                            using (var reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName))
                            {
                                var sb = new System.Text.StringBuilder();
                                for (int i = 1; i <= reader.NumberOfPages; i++)
                                {
                                    sb.Append(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, i));
                                }
                                rtxtConteudo.Text = sb.ToString();
                            }
                        }
                        else if (extensao == ".docx")
                        {
                            using (var doc = DocX.Load(ofd.FileName)) // Usando Novacode.DocX
                            {
                                rtxtConteudo.Text = doc.Text;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Formato de arquivo não suportado para leitura.");
                        }
                        this.Text = $"Editar Arquivo - {System.IO.Path.GetFileName(ofd.FileName)}";
                    }
                }
            };

            btnVoltar.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}