using System.Windows.Forms;
using System.Drawing; // Adicione este using!
using iTextSharp.text;
using iTextSharp.text.pdf;
using Novacode;

namespace GeradorTxt
{
    public class FormCriar : Form
    {
        public FormCriar()
        {
            this.Text = "Criar Arquivo TXT";
            this.Icon = new System.Drawing.Icon("IconeGeradorTXT.ico");
            this.Width = 1000;
            this.Height = 800;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var lblTituloCriar = new Label
            {
                Text = "Escreva seu Texto",
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                AutoSize = true,
                Top = 30
            };

            var rtxtConteudo = new RichTextBox
            {
                Font = new System.Drawing.Font("Arial", 11), // Use System.Drawing.Font
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, // Use namespace completo para evitar ambiguidade
                Width = 880,
                Height = 600,
                Top = 80,
                Left = 50,
            };

            var btnNegrito = new Button
            {
                Text = "B",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Width = 30,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = rtxtConteudo.Left,
            };

            var btnItalico = new Button
            {
                Text = "I",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold),
                Width = 30,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = rtxtConteudo.Left + 35,
            };

            var btnSublinhado = new Button
            {
                Text = "U",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold),
                Width = 30,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = rtxtConteudo.Left + 70,
            };

            var btnDiminuirFonte = new Button
            {
                Text = "-",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Width = 30,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = rtxtConteudo.Left + 105,
            };

            var cmbTamanhoFonte = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 11),
                Width = 60,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = btnDiminuirFonte.Left + btnDiminuirFonte.Width + 5,
            };

            var btnAumentarFonte = new Button
            {
                Text = "+",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Width = 30,
                Height = 30,
                Top = rtxtConteudo.Top - 35,
                Left = cmbTamanhoFonte.Left + cmbTamanhoFonte.Width + 5,
            };

            var btnSalvar = new Button
            {
                Text = "Salvar",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Width = 120,
                Height = 40,
                Top = 700,
                Left = 50,
            };

            var btnVoltar = new Button
            {
                Text = "Voltar",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Width = 120,
                Height = 40,
                Top = 700,
                Left = this.ClientSize.Width - 170,
            };

            this.Controls.Add(lblTituloCriar); // Adiciona o label à janela
            this.Controls.Add(rtxtConteudo); // Adiciona o RichTextBox à janela
            this.Controls.Add(btnNegrito); // Adiciona o botão Negrito à janela
            this.Controls.Add(btnItalico); // Adiciona o botão Itálico à janela
            this.Controls.Add(btnSublinhado); // Adiciona o botão Sublinhado à janela
            this.Controls.Add(btnDiminuirFonte); // Adiciona o botão Diminuir Fonte à janela
            this.Controls.Add(cmbTamanhoFonte); // Adiciona o ComboBox de Tamanho da Fonte à janela
            this.Controls.Add(btnAumentarFonte); // Adiciona o botão Aumentar Fonte à janela
            this.Controls.Add(btnVoltar); // Adiciona o botão Voltar à janela
            this.Controls.Add(btnSalvar); // Adiciona o botão Salvar à janela


            // Centralizando os controles
            lblTituloCriar.Left = (this.ClientSize.Width - lblTituloCriar.Width) / 2; // Centraliza o título

            // Defina as cores
            Color corAtivo = Color.FromArgb(70, 130, 180);
            Color corInativo = Color.FromArgb(30, 30, 30);

            // Declare a função ANTES dos eventos
            void AtualizarEstadoBotoes()
            {
                var font = rtxtConteudo.SelectionFont;
                if (font != null)
                {
                    btnNegrito.BackColor = font.Bold ? corAtivo : corInativo;
                    btnItalico.BackColor = font.Italic ? corAtivo : corInativo;
                    btnSublinhado.BackColor = font.Underline ? corAtivo : corInativo;
                }
                else
                {
                    btnNegrito.BackColor = corInativo;
                    btnItalico.BackColor = corInativo;
                    btnSublinhado.BackColor = corInativo;
                }
            }

            btnNegrito.Click += (s, e) => // Ao clicar no botão Negrito
            {
                if (rtxtConteudo.SelectionFont != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Bold;
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle);
                }
                rtxtConteudo.Focus();
                AtualizarEstadoBotoes();
            };

            btnItalico.Click += (s, e) => // Ao clicar no botão Itálico
            {
                if (rtxtConteudo.SelectionFont != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Italic;
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle);
                }
                rtxtConteudo.Focus();
                AtualizarEstadoBotoes();
            };

            btnSublinhado.Click += (s, e) => // Ao clicar no botão Sublinhado
            {
                if (rtxtConteudo.SelectionFont != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Underline;
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle);
                }
                rtxtConteudo.Focus();
                AtualizarEstadoBotoes();
            };

            // 1. Popule o ComboBox com tamanhos de fonte de 8 até 40, de 1 em 1
            for (int i = 8; i <= 40; i++)
                cmbTamanhoFonte.Items.Add(i.ToString());

            // Defina o padrão como 11
            cmbTamanhoFonte.SelectedItem = "11";

            // 2. Atualize o ComboBox ao mudar a seleção do RichTextBox
            rtxtConteudo.SelectionChanged += (s, e) =>
            {
                var font = rtxtConteudo.SelectionFont;
                if (font != null)
                {
                    cmbTamanhoFonte.SelectedItem = ((int)Math.Round(font.Size)).ToString();
                }
                else
                {
                    cmbTamanhoFonte.SelectedItem = "11";
                }
            };

            // 3. Permita alterar o tamanho da fonte pelo ComboBox
            cmbTamanhoFonte.SelectedIndexChanged += (s, e) =>
            {
                if (rtxtConteudo.SelectionFont != null && cmbTamanhoFonte.SelectedItem != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    if (float.TryParse(cmbTamanhoFonte.SelectedItem.ToString(), out float newSize))
                    {
                        rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newSize, currentFont.Style);
                    }
                    rtxtConteudo.Focus();
                }
            };

            // Evento para aumentar a fonte
            btnAumentarFonte.Click += (s, e) =>
            {
                if (rtxtConteudo.SelectionFont != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    float newSize = currentFont.Size + 1;
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newSize, currentFont.Style);
                    cmbTamanhoFonte.SelectedItem = ((int)Math.Round(newSize)).ToString();
                    rtxtConteudo.Focus();
                }
            };

            // Evento para diminuir a fonte
            btnDiminuirFonte.Click += (s, e) =>
            {
                if (rtxtConteudo.SelectionFont != null && rtxtConteudo.SelectionFont.Size > 4)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    float newSize = currentFont.Size - 1;
                    if (newSize < 4) newSize = 4;
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newSize, currentFont.Style);
                    cmbTamanhoFonte.SelectedItem = ((int)Math.Round(newSize)).ToString();
                    rtxtConteudo.Focus();
                }
            };

            btnSalvar.Click += (s, e) =>
            {
                var escolherFormato = new FormEscolherFormatoSalvar();
                if (escolherFormato.ShowDialog() == DialogResult.OK)
                {
                    var formato = escolherFormato.Escolha;
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                        if (formato == FormEscolherFormatoSalvar.FormatoEscolhido.TXT)
                        {
                            sfd.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                            sfd.Title = "Salvar como TXT";
                            sfd.FileName = "NovoArquivo.txt";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                System.IO.File.WriteAllText(sfd.FileName, rtxtConteudo.Text);
                                MessageBox.Show($"Documento salvo em:\n{sfd.FileName}");
                            }
                        }
                        else if (formato == FormEscolherFormatoSalvar.FormatoEscolhido.PDF)
                        {
                            sfd.Filter = "PDF (*.pdf)|*.pdf";
                            sfd.Title = "Salvar como PDF";
                            sfd.FileName = "Documento.pdf";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using (var fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                                {
                                    var doc = new iTextSharp.text.Document();
                                    PdfWriter.GetInstance(doc, fs);
                                    doc.Open();
                                    doc.Add(new iTextSharp.text.Paragraph(rtxtConteudo.Text));
                                    doc.Close();
                                }
                                MessageBox.Show($"PDF salvo em:\n{sfd.FileName}");
                            }
                        }
                        else if (formato == FormEscolherFormatoSalvar.FormatoEscolhido.Word)
                        {
                            sfd.Filter = "Word (*.docx)|*.docx";
                            sfd.Title = "Salvar como Word";
                            sfd.FileName = "Documento.docx";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using (var doc = DocX.Create(sfd.FileName)) // Usando Novacode.DocX
                                {
                                    // Salva cada linha do RichTextBox como um parágrafo no Word
                                    foreach (var linha in rtxtConteudo.Lines)
                                    {
                                        doc.InsertParagraph(linha);
                                    }
                                    doc.Save();
                                }
                                MessageBox.Show($"Documento Word salvo em:\n{sfd.FileName}");
                            }
                        }
                    }
                }
            };
            
            btnVoltar.Click += (s, e) =>
            {
                // Fecha a janela ao clicar em Voltar
                this.Close();
            };

            // Atualiza o estado dos botões ao iniciar
            AtualizarEstadoBotoes();
        
        }
    }
}