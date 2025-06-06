namespace GeradorTxt;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.Text = "Gerador de Arquivos TXT"; // Alterar nome da janela
        this.Icon = new System.Drawing.Icon("IconeGeradorTXT.ico"); // Icone da janela
        this.Width = 1000; // Largura da janela
        this.Height = 800; // Altura da janela
        this.StartPosition = FormStartPosition.CenterScreen; // Centralizar a janela na tela
        this.BackColor = System.Drawing.Color.FromArgb(10, 10, 10); // Cor de fundo da janela
        
        // Impede o usuario de redimensionar a janela
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        var lblTitulo = new Label // label para o título
        {
            Text = "Bem-vindo ao Gerador de Arquivos TXT!", // Título
            ForeColor = System.Drawing.Color.White, // Cor
            Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold), // Fonte
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter, // Alinhamento 
            AutoSize = true, // Auto ajuste de tamanho
            Top = 20, // Posição vertical
        };

        var lblSubTitulo = new Label // label para o subtítulo
        {
            Text = "Selecione uma opção abaixo", // Subtítulo
            ForeColor = System.Drawing.Color.White, // Cor
            Font = new System.Drawing.Font("Arial", 15, System.Drawing.FontStyle.Regular), // Fonte
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter, // Alinhamento
            AutoSize = true, // Auto ajuste de tamanho
            Top = 70, // Posição vertical

        };

        var btnCriar = new Button
        {
            Text = "Criar Arquivo", // Texto do botão
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30), // Cor de fundo
            ForeColor = System.Drawing.Color.White, // Cor do texto
            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular), // Fonte
            Width = 200, // Largura
            Height = 50, // Altura
            Top = 120, // Posição vertical
        };

        var btnEditar = new Button
        {
            Text = "Editar Arquivo", // Texto do botão
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30), // Cor de fundo
            ForeColor = System.Drawing.Color.White, // Cor do texto
            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular), // Fonte
            Width = 200, // Largura
            Height = 50, // Altura
            Top = 190, // Posição vertical
        };

        var btnAbrir = new Button
        {
            Text = "Abrir Arquivo", // Texto do botão
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30), // Cor de fundo
            ForeColor = System.Drawing.Color.White, // Cor do texto
            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular), // Fonte
            Width = 200, // Largura
            Height = 50, // Altura
            Top = 260, // Posição vertical
        };

        var btnSair = new Button
        {
            Text = "Sair", // Texto do botão
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30), // Cor de fundo
            ForeColor = System.Drawing.Color.White, // Cor do texto
            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular), // Fonte
            Width = 100, // Largura
            Height = 50, // Altura
            Top = 330, // Posição vertical
        };

        // Adicionando os controles à janela
        this.Controls.Add(lblTitulo);
        this.Controls.Add(lblSubTitulo);
        // Adicionando os botões à janela
        this.Controls.Add(btnCriar);
        this.Controls.Add(btnEditar);
        this.Controls.Add(btnAbrir);

        this.Controls.Add(btnSair);

        // Overlay azul só quando mouse estiver sobre o botão
        btnCriar.TabStop = false;
        btnEditar.TabStop = false;
        btnAbrir.TabStop = false;

        btnSair.TabStop = false;

        // Centralizando os controles
        lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2; // Centralizar o título
        lblSubTitulo.Left = (this.ClientSize.Width - lblSubTitulo.Width) / 2; // Centralizar o subtítulo

        btnCriar.Left = (this.ClientSize.Width - btnCriar.Width) / 2; // Centralizar o botão
        btnCriar.Top = this.ClientSize.Height / 2 - btnCriar.Height - 140; // Vertical

        btnEditar.Left = (this.ClientSize.Width - btnEditar.Width) / 2; // Centralizar o botão de editar
        btnEditar.Top = btnCriar.Top + btnCriar.Height + 20; // Vertical baseado no botão de criar

        btnAbrir.Left = (this.ClientSize.Width - btnAbrir.Width) / 2; // Centralizar o botão de abrir
        btnAbrir.Top = btnEditar.Top + btnEditar.Height + 20; // Vertical baseado no botão de editar

        btnSair.Left = (this.ClientSize.Width - btnSair.Width) / 2; // Centralizar o botão de sair
        btnSair.Top = this.ClientSize.Height - btnSair.Height - 40; // Posição do botão de sair na parte inferior

        // Eventos ao Clicar nos botões
        btnCriar.Click += (s, e) =>
        {
            var formCriar = new FormCriar(); // Cria uma nova instância do FormCriar
            formCriar.FormClosed += (sender, args) => this.Show(); // Mostra o menu ao fechar
            this.Hide(); // Esconde o formulário atual
            formCriar.Show(); // Exibe o formulário de criação
        };

        btnEditar.Click += (s, e) =>
        {
            var formEditar = new FormEditar(); // Cria uma nova instância do FormEditar
            formEditar.FormClosed += (sender, args) => this.Show(); // Mostra o menu ao fechar
            this.Hide(); // Esconde o formulário atual
            formEditar.Show(); // Exibe o formulário de edição
        };

        btnAbrir.Click += (s, e) =>
        {
            var formAbrir = new FormAbrir(); // Cria uma nova instância do FormAbrir
            formAbrir.FormClosed += (sender, args) => this.Show(); // Mostra o menu ao fechar
            this.Hide(); // Esconde o formulário atual
            formAbrir.Show(); // Exibe o formulário de abrir
        };

        btnSair.Click += (s, e) =>
        {
            Application.Exit(); // Encerra a aplicação
        };
        
    }
}
