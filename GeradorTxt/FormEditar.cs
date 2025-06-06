using System.Windows.Forms;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Novacode;

namespace GeradorTxt
{
    public class FormEditar : Form
    {
        public FormEditar()
        {
            this.Text = "Editar Arquivo TXT"; // Alterar nome da janela
            this.Icon = new System.Drawing.Icon("IconeGeradorTXT.ico"); // Icone da janela
            this.Width = 1000; // Largura da janela
            this.Height = 800; // Altura da janela
            this.StartPosition = FormStartPosition.CenterScreen; // Centralizar a janela na tela
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 10); // Cor de fundo da janela

            // Impede o usuario de redimensionar a janela
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var lblTituloCriar = new Label // label para o título
            {
                Text = "Edite seu Texto", // Título alterado
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                AutoSize = true,
                Top = 30
            };

            var rtxtConteudo = new RichTextBox
            {
                Font = new System.Drawing.Font("Arial", 11),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, // Use o namespace completo para evitar ambiguidade
                Width = 880,
                Height = 600,
                Top = 80, // Posição vertical
                Left = 50, // Posição horizontal
            };
            rtxtConteudo.ReadOnly = true;

            var btnNegrito = new Button
            {
                Text = "B", // Texto do botão
                BackColor = Color.FromArgb(30, 30, 30), // Cor de fundo
                ForeColor = Color.White, // Cor do texto
                FlatStyle = FlatStyle.Flat, // Estilo do botão
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold), // Fonte do botão
                Width = 30, // Largura
                Height = 30, // Altura 
                Top = rtxtConteudo.Top - 35, // Posição vertical
                Left = rtxtConteudo.Left, // Posição horizontal
            };

            var btnItalico = new Button
            {
                Text = "I", // Texto do Botão
                BackColor = Color.FromArgb(30, 30, 30), // Cor de fundo
                ForeColor = Color.White, // Cor do texto
                FlatStyle = FlatStyle.Flat, // Estilo do botão
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold), // Fonte do botão
                Width = 30, // Largura do botão
                Height = 30, // Altura do botão
                Top = rtxtConteudo.Top - 35, // Posição vertical
                Left = rtxtConteudo.Left + 35, // Posição horizontal
            };

            var btnSublinhado = new Button
            {
                Text = "U", // Texto do Botão
                BackColor = Color.FromArgb(30, 30, 30), // Cor de fundo
                ForeColor = Color.White, // Cor do texto
                FlatStyle = FlatStyle.Flat, // Estilo do botão
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold), // Fonte do botão       
                Width = 30, // Largura do botão
                Height = 30, // Altura do botão
                Top = rtxtConteudo.Top - 35, // Posição vertical
                Left = rtxtConteudo.Left + 70, // Posição horizontal
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
                Left = rtxtConteudo.Left + 105, // Botão de menos à esquerda do ComboBox
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
                Left = btnDiminuirFonte.Left + btnDiminuirFonte.Width + 5, // ComboBox ao lado do botão de menos
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
                Left = cmbTamanhoFonte.Left + cmbTamanhoFonte.Width + 5, // Botão de mais à direita do ComboBox
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
                Visible = false,
            };

            var btnAbrirArquivo = new Button
            {
                Text = "Abrir Arquivo",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                Width = 120,
                Height = 40,
                Top = btnSalvar.Top,
                Left = rtxtConteudo.Left + btnSalvar.Width + 20, // Botão de abrir arquivo à direita do botão Salvar
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
            this.Controls.Add(btnAbrirArquivo); // Adiciona o botão Abrir Arquivo à janela


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
                if (rtxtConteudo.SelectionFont != null) // Verifica se há texto selecionado
                {
                    var currentFont = rtxtConteudo.SelectionFont; // Obtém a fonte atual do texto selecionado
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Bold; // Use System.Drawing.FontStyle
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle); // Use System.Drawing.Font
                }
                rtxtConteudo.Focus(); // Foca no RichTextBox após clicar no botão
                AtualizarEstadoBotoes();
            };

            btnItalico.Click += (s, e) => // Ao clicar no botão Itálico
            {
                if (rtxtConteudo.SelectionFont != null) // Verifica se há texto selecionado
                {
                    var currentFont = rtxtConteudo.SelectionFont; // Obtém a fonte atual do texto selecionado
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Italic; // Use System.Drawing.FontStyle
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle); // Use System.Drawing.Font
                }
                rtxtConteudo.Focus(); // Foca no RichTextBox após clicar no botão
                AtualizarEstadoBotoes();
            };

            btnSublinhado.Click += (s, e) => // Ao clicar no botão Sublinhado
            {
                if (rtxtConteudo.SelectionFont != null) // Verifica se há texto selecionado
                {
                    var currentFont = rtxtConteudo.SelectionFont; // Obtém a fonte atual do texto selecionado
                    var newFontStyle = currentFont.Style ^ System.Drawing.FontStyle.Underline; // Use System.Drawing.FontStyle
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont, newFontStyle); // Use System.Drawing.Font
                }
                rtxtConteudo.Focus(); // Foca no RichTextBox após clicar no botão
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
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newSize, currentFont.Style); // Use System.Drawing.Font
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
                    rtxtConteudo.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, newSize, currentFont.Style); // Use System.Drawing.Font
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
                                    doc.InsertParagraph(rtxtConteudo.Text);
                                    doc.Save();
                                }
                                MessageBox.Show($"Documento Word salvo em:\n{sfd.FileName}");
                            }
                        }
                    }
                }
            };

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

                        // Só agora adiciona o botão Salvar e o torna visível
                        if (!this.Controls.Contains(btnSalvar))
                            this.Controls.Add(btnSalvar);
                        btnSalvar.Visible = true;
                        rtxtConteudo.ReadOnly = false;
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