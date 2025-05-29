using System.Windows.Forms;

namespace GeradorTxt
{
    public class FormCriar : Form
    {
        public FormCriar()
        {

            this.Text = "Criar Arquivo TXT"; // Alterar nome da janela
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
                Text = "Escreva seu Texto", // Título
                ForeColor = System.Drawing.Color.White, // Cor do texto
                Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold), // Fonte
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter, // Alinhamento
                AutoSize = true, // Auto ajuste de tamanho
                Top = 30 // Posição vertical
            };

            var rtxtConteudo = new RichTextBox // RichTextBox para o conteúdo do texto
            {
                Font = new Font("Arial", 11), // Fonte Padrão
                BackColor = Color.FromArgb(30, 30, 30), // Cor de fundo
                ForeColor = Color.White, // Cor do texto
                BorderStyle = BorderStyle.FixedSingle, // Borda
                Width = 880, // Largura
                Height = 600, // Altura
                Top = 80, // Posição vertical
                Left = 50, // Posição horizontal
            };

            var btnNegrito = new Button
            {
                Text = "B", // Texto do botão
                BackColor = Color.FromArgb(30, 30, 30), // Cor de fundo
                ForeColor = Color.White, // Cor do texto
                FlatStyle = FlatStyle.Flat, // Estilo do botão
                Font = new Font("Arial", 10, FontStyle.Regular), // Fonte do botão
                // Fonte
                Width = 30, // Largura
                Height = 30, // Altura 
                Top = rtxtConteudo.Top - 35, // Posição vertical
                Left = rtxtConteudo.Left, // Posição horizontal
            };

            var btnItalico = new Button
            {

            };

            var btnSublinhado = new Button
            {

            };

            var btnTamanhoFonte = new Button
            {

            };

            var btnVoltar = new Button
            {
  
            };

            var btnSalvar = new Button
            {

            };

            this.Controls.Add(lblTituloCriar); // Adiciona o label à janela
            this.Controls.Add(rtxtConteudo); // Adiciona o RichTextBox à janela
            this.Controls.Add(btnNegrito); // Adiciona o botão Negrito à janela

            // Centralizando os controles
            lblTituloCriar.Left = (this.ClientSize.Width - lblTituloCriar.Width) / 2; // Centraliza o título

            btnNegrito.Click += (s, e) => // Ao clicar no botão Negrito
            {
                if (rtxtConteudo.SelectionFont != null) // Verifica se há texto selecionado
                {
                    var currentFont = rtxtConteudo.SelectionFont; // Obtém a fonte atual do texto selecionado
                    var newFontStyle = currentFont.Style ^ FontStyle.Bold; // Alterna o estilo negrito
                    rtxtConteudo.SelectionFont = new Font(currentFont, newFontStyle); // Aplica a nova fonte com o estilo alterado
                }
            };

            /*
            // Botão Aumentar Fonte
            var btnAumentar = new Button
            {
                Text = "A+",
                Width = 40,
                Height = 30,
                Top = 50,
                Left = 140,
            };
            // Ao clicar, aumenta o tamanho da fonte do texto selecionado
            btnAumentar.Click += (s, e) =>
            {
                if (rtxtConteudo.SelectionFont != null)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    rtxtConteudo.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size + 2, currentFont.Style);
                }
            };
            this.Controls.Add(btnAumentar);

            // Botão Diminuir Fonte
            var btnDiminuir = new Button
            {
                Text = "A-",
                Width = 40,
                Height = 30,
                Top = 50,
                Left = 190,
            };
            // Ao clicar, diminui o tamanho da fonte do texto selecionado (mínimo 4)
            btnDiminuir.Click += (s, e) =>
            {
                if (rtxtConteudo.SelectionFont != null && rtxtConteudo.SelectionFont.Size > 4)
                {
                    var currentFont = rtxtConteudo.SelectionFont;
                    rtxtConteudo.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size - 2, currentFont.Style);
                }
            };
            this.Controls.Add(btnDiminuir);

            // Botão Salvar
            var btnSalvar = new Button
            {
                Text = "Salvar",
                Width = 120,
                Height = 40,
                Top = 700,
                Left = 50,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(btnSalvar);

            // Botão Voltar
            var btnVoltar = new Button
            {
                Text = "Voltar",
                Width = 120,
                Height = 40,
                Top = 700,
                Left = 200,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(btnVoltar);

            // Fecha a janela ao clicar em Voltar
            btnVoltar.Click += (s, e) => this.Close();
            // Simula o salvamento do texto ao clicar em Salvar
            btnSalvar.Click += (s, e) => MessageBox.Show("Texto salvo (simulação)!");
            */
        }
    }
}