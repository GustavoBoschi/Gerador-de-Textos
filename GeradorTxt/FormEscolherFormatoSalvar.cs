using System;
using System.Windows.Forms;

namespace GeradorTxt
{
    public class FormEscolherFormatoSalvar : Form
    {
        public enum FormatoEscolhido { Nenhum, TXT, PDF, Word }
        public FormatoEscolhido Escolha { get; private set; } = FormatoEscolhido.Nenhum;

        public FormEscolherFormatoSalvar()
        {
            this.Text = "Escolher Formato";
            this.Width = 600; // ou até 480 para mais folga
            this.Height = 160;
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var btnTxt = new Button
            {
                Text = "Salvar em TXT",
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Width = 130,
                Height = 40,
                Top = 40,
                Left = 20
            };
            var btnPdf = new Button
            {
                Text = "Salvar em PDF",
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Width = 130,
                Height = 40,
                Top = 40,
                Left = btnTxt.Left + btnTxt.Width + 10 // 10px de espaço após o btnTxt
            };
            var btnWord = new Button
            {
                Text = "Salvar em Word",
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                Width = 140,
                Height = 40,
                Top = 40,
                Left = btnPdf.Left + btnPdf.Width + 10 // 10px de espaço após o btnPdf
            };

            // Defina a largura total dos botões e espaçamentos
            int totalWidth = btnTxt.Width + btnPdf.Width + btnWord.Width + 20 + 10 + 10; // Espaço entre botões
            int startLeft = (this.ClientSize.Width - totalWidth) / 2;

            btnTxt.Left = startLeft;
            btnPdf.Left = btnTxt.Left + btnTxt.Width + 10;
            btnWord.Left = btnPdf.Left + btnPdf.Width + 10;

            btnTxt.Click += (s, e) => { Escolha = FormatoEscolhido.TXT; this.DialogResult = DialogResult.OK; };
            btnPdf.Click += (s, e) => { Escolha = FormatoEscolhido.PDF; this.DialogResult = DialogResult.OK; };
            btnWord.Click += (s, e) => { Escolha = FormatoEscolhido.Word; this.DialogResult = DialogResult.OK; };

            this.Controls.Add(btnTxt);
            this.Controls.Add(btnPdf);
            this.Controls.Add(btnWord);
        }
    }
}