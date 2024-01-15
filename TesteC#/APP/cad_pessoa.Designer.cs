namespace APP
{
    partial class AppGustavo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Nome = new Label();
            nome_box = new TextBox();
            cpf_box = new TextBox();
            CPF = new Label();
            Masculino = new RadioButton();
            sex_box = new GroupBox();
            Feminino = new RadioButton();
            cadastrar_pessoa = new Button();
            dgvPessoas = new DataGridView();
            alterar_pessoa = new Button();
            alterar_cancelar = new Button();
            Title_nova = new Label();
            label1 = new Label();
            novapessoa = new Button();
            novapessoa_esconder = new Button();
            Title_alterar = new Label();
            sex_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPessoas).BeginInit();
            SuspendLayout();
            // 
            // Nome
            // 
            Nome.AutoSize = true;
            Nome.ForeColor = Color.RoyalBlue;
            Nome.Location = new Point(25, 298);
            Nome.Name = "Nome";
            Nome.Size = new Size(40, 15);
            Nome.TabIndex = 0;
            Nome.Text = "Nome";
            Nome.Visible = false;
            // 
            // nome_box
            // 
            nome_box.Location = new Point(71, 295);
            nome_box.Name = "nome_box";
            nome_box.Size = new Size(195, 23);
            nome_box.TabIndex = 1;
            nome_box.Visible = false;
            // 
            // cpf_box
            // 
            cpf_box.Location = new Point(71, 324);
            cpf_box.Name = "cpf_box";
            cpf_box.Size = new Size(195, 23);
            cpf_box.TabIndex = 3;
            cpf_box.Visible = false;
            // 
            // CPF
            // 
            CPF.AutoSize = true;
            CPF.ForeColor = Color.RoyalBlue;
            CPF.Location = new Point(30, 327);
            CPF.Name = "CPF";
            CPF.Size = new Size(28, 15);
            CPF.TabIndex = 2;
            CPF.Text = "CPF";
            CPF.Visible = false;
            // 
            // Masculino
            // 
            Masculino.AutoSize = true;
            Masculino.Location = new Point(6, 22);
            Masculino.Name = "Masculino";
            Masculino.Size = new Size(80, 19);
            Masculino.TabIndex = 4;
            Masculino.TabStop = true;
            Masculino.Text = "Masculino";
            Masculino.UseVisualStyleBackColor = true;
            // 
            // sex_box
            // 
            sex_box.BackColor = SystemColors.Control;
            sex_box.Controls.Add(Feminino);
            sex_box.Controls.Add(Masculino);
            sex_box.Location = new Point(71, 356);
            sex_box.Name = "sex_box";
            sex_box.Size = new Size(195, 50);
            sex_box.TabIndex = 5;
            sex_box.TabStop = false;
            sex_box.Text = " Escolha o sexo";
            sex_box.Visible = false;
            // 
            // Feminino
            // 
            Feminino.AutoSize = true;
            Feminino.Location = new Point(106, 22);
            Feminino.Name = "Feminino";
            Feminino.Size = new Size(75, 19);
            Feminino.TabIndex = 5;
            Feminino.TabStop = true;
            Feminino.Text = "Feminino";
            Feminino.UseVisualStyleBackColor = true;
            // 
            // cadastrar_pessoa
            // 
            cadastrar_pessoa.BackColor = Color.RoyalBlue;
            cadastrar_pessoa.ForeColor = Color.White;
            cadastrar_pessoa.Location = new Point(71, 412);
            cadastrar_pessoa.Name = "cadastrar_pessoa";
            cadastrar_pessoa.Size = new Size(75, 23);
            cadastrar_pessoa.TabIndex = 6;
            cadastrar_pessoa.Text = "Cadastrar";
            cadastrar_pessoa.UseVisualStyleBackColor = false;
            cadastrar_pessoa.Visible = false;
            cadastrar_pessoa.Click += cadastrar_pessoa_Click;
            // 
            // dgvPessoas
            // 
            dgvPessoas.AllowUserToOrderColumns = true;
            dgvPessoas.GridColor = Color.WhiteSmoke;
            dgvPessoas.Location = new Point(12, 49);
            dgvPessoas.Name = "dgvPessoas";
            dgvPessoas.ReadOnly = true;
            dgvPessoas.RightToLeft = RightToLeft.No;
            dgvPessoas.Size = new Size(560, 150);
            dgvPessoas.TabIndex = 7;
            // 
            // alterar_pessoa
            // 
            alterar_pessoa.BackColor = Color.RoyalBlue;
            alterar_pessoa.ForeColor = Color.Cornsilk;
            alterar_pessoa.Location = new Point(71, 412);
            alterar_pessoa.Name = "alterar_pessoa";
            alterar_pessoa.Size = new Size(75, 23);
            alterar_pessoa.TabIndex = 8;
            alterar_pessoa.Text = "Alterar";
            alterar_pessoa.UseVisualStyleBackColor = false;
            alterar_pessoa.Visible = false;
            alterar_pessoa.Click += alterar_pessoa_Click_1;
            // 
            // alterar_cancelar
            // 
            alterar_cancelar.BackColor = Color.Red;
            alterar_cancelar.ForeColor = Color.White;
            alterar_cancelar.Location = new Point(191, 412);
            alterar_cancelar.Name = "alterar_cancelar";
            alterar_cancelar.Size = new Size(75, 23);
            alterar_cancelar.TabIndex = 9;
            alterar_cancelar.Text = "Cancelar";
            alterar_cancelar.UseVisualStyleBackColor = false;
            alterar_cancelar.Visible = false;
            alterar_cancelar.Click += alterar_cancelar_Click;
            // 
            // Title_nova
            // 
            Title_nova.AutoSize = true;
            Title_nova.Font = new Font("Segoe UI", 20F);
            Title_nova.ForeColor = Color.RoyalBlue;
            Title_nova.Location = new Point(12, 237);
            Title_nova.Name = "Title_nova";
            Title_nova.Size = new Size(167, 37);
            Title_nova.TabIndex = 12;
            Title_nova.Text = "Nova Pessoa";
            Title_nova.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(206, 37);
            label1.TabIndex = 13;
            label1.Text = "Lista de Pessoas";
            // 
            // novapessoa
            // 
            novapessoa.Location = new Point(488, 205);
            novapessoa.Name = "novapessoa";
            novapessoa.Size = new Size(85, 23);
            novapessoa.TabIndex = 14;
            novapessoa.Text = "Nova Pessoa";
            novapessoa.UseVisualStyleBackColor = true;
            novapessoa.Click += novapessoa_Click_1;
            // 
            // novapessoa_esconder
            // 
            novapessoa_esconder.Location = new Point(488, 234);
            novapessoa_esconder.Name = "novapessoa_esconder";
            novapessoa_esconder.Size = new Size(85, 23);
            novapessoa_esconder.TabIndex = 15;
            novapessoa_esconder.Text = "Esconder";
            novapessoa_esconder.UseVisualStyleBackColor = true;
            novapessoa_esconder.Visible = false;
            novapessoa_esconder.Click += novapessoa_esconder_Click_1;
            // 
            // Title_alterar
            // 
            Title_alterar.AutoSize = true;
            Title_alterar.Font = new Font("Segoe UI", 20F);
            Title_alterar.ForeColor = Color.RoyalBlue;
            Title_alterar.Location = new Point(12, 237);
            Title_alterar.Name = "Title_alterar";
            Title_alterar.Size = new Size(183, 37);
            Title_alterar.TabIndex = 16;
            Title_alterar.Text = "Alterar Pessoa";
            Title_alterar.Visible = false;
            // 
            // AppGustavo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 450);
            Controls.Add(Title_alterar);
            Controls.Add(novapessoa_esconder);
            Controls.Add(novapessoa);
            Controls.Add(label1);
            Controls.Add(Title_nova);
            Controls.Add(alterar_cancelar);
            Controls.Add(alterar_pessoa);
            Controls.Add(dgvPessoas);
            Controls.Add(cadastrar_pessoa);
            Controls.Add(sex_box);
            Controls.Add(cpf_box);
            Controls.Add(CPF);
            Controls.Add(nome_box);
            Controls.Add(Nome);
            Name = "AppGustavo";
            Text = "AppGustavo";
            sex_box.ResumeLayout(false);
            sex_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPessoas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nome;
        private TextBox nome_box;
        private TextBox cpf_box;
        private Label CPF;
        private RadioButton Masculino;
        private GroupBox sex_box;
        private RadioButton Feminino;
        private Button cadastrar_pessoa;
        private DataGridView dgvPessoas;
        private Button alterar_pessoa;
        private Button alterar_cancelar;
        private Label Title_nova;
        private Label label1;
        private Button novapessoa;
        private Button novapessoa_esconder;
        private Label Title_alterar;
    }
}
