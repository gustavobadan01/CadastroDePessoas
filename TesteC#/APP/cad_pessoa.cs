using System;
using static APP.AppGustavo;

namespace APP
{
    public partial class AppGustavo : Form
    {

        private const string filePath = "pessoas.txt";
        private List<Pessoa> listaPessoas;

        public AppGustavo()
        {
            InitializeComponent();
            listaPessoas = CarregarPessoasDoArquivo();
            ConfigurarDataGridView();
            AtualizarDataGridView();
        }


        private void ConfigurarDataGridView()
        {
            dgvPessoas.Columns.Add("CPF", "CPF");
            dgvPessoas.Columns.Add("Nome", "Nome");
            dgvPessoas.Columns.Add("Sexo", "Sexo");

            DataGridViewButtonColumn btnAlterar = new DataGridViewButtonColumn();
            btnAlterar.Name = "Alterar";
            btnAlterar.HeaderText = "Alterar";
            btnAlterar.Text = "Alterar";
            btnAlterar.UseColumnTextForButtonValue = true;
            dgvPessoas.Columns.Add(btnAlterar);

            DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
            btnExcluir.Name = "Excluir";
            btnExcluir.HeaderText = "Excluir";
            btnExcluir.Text = "Excluir";
            btnExcluir.UseColumnTextForButtonValue = true;
            dgvPessoas.Columns.Add(btnExcluir);

            dgvPessoas.CellClick += DgvPessoas_CellClick;
        }

        public class Pessoa
        {
            public string CPF { get; }
            public string Nome { get; }
            public string Sexo { get; }

            public Pessoa(string cpf, string nome, string sexo)
            {
                CPF = cpf;
                Nome = nome;
                Sexo = sexo;
            }
        }


        private bool ValidarCPF(string cpf)
        {
            // Remover caracteres não numéricos do CPF
            string cpfNumerico = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificar se o CPF tem 11 dígitos
            if (cpfNumerico.Length != 11)
            {
                MessageBox.Show("CPF inválido. Deve conter exatamente 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar se todos os dígitos são iguais
            if (cpfNumerico.Distinct().Count() == 1)
            {
                MessageBox.Show("CPF inválido. Todos os dígitos são iguais.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpfNumerico[i] - '0') * (10 - i);
            }

            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : (11 - resto);

            // Verificar se o primeiro dígito verificador está correto
            if (cpfNumerico[9] - '0' != digitoVerificador1)
            {
                MessageBox.Show("CPF inválido. Primeiro dígito verificador incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Calcular o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpfNumerico[i] - '0') * (11 - i);
            }

            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : (11 - resto);

            // Verificar se o segundo dígito verificador está correto
            if (cpfNumerico[10] - '0' != digitoVerificador2)
            {
                MessageBox.Show("CPF inválido. Segundo dígito verificador incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // CPF válido
            return true;
        }



        private void cadastrar_pessoa_Click(object sender, EventArgs e)
        {
            string cpf = cpf_box.Text.Trim();
            string nome = nome_box.Text.Trim();
            string sexo = ObterSexoEscolhido();


            if (string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sexo) || sexo == "Nenhum selecionado")
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de cadastrar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCPF(cpf))
            {
                return;
            }

            if (ExisteCPFNoArquivo(cpf))
            {
                return;
            }
            else
            {

                Pessoa pessoa = new Pessoa(cpf, nome, sexo);
                listaPessoas.Add(pessoa);

                AtualizarDataGridView();
                SalvarPessoasNoArquivo();
                LimparCampos();
                LimparSex();

            }

            

        }


        private string ObterSexoEscolhido()
        {
            if (Masculino.Checked)
            {
                return "Masculino";
            }
            else if (Feminino.Checked)
            {
                return "Feminino";
            }
            else
            {
                return "Nenhum selecionado";
            }
        }

        private void LimparCampos()
        {
            nome_box.Clear();
            cpf_box.Clear();
        }

        private void LimparSex()
        {
            foreach (Control control in sex_box.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    radioButton.Checked = false;
                }
            }
        }


        private void AtualizarDataGridView()
        {
            dgvPessoas.Rows.Clear();
            listaPessoas.Reverse();

            foreach (var pessoa in listaPessoas)
            {
                dgvPessoas.Rows.Add(pessoa.CPF, pessoa.Nome, pessoa.Sexo, "Alterar", "Excluir");
            }

            listaPessoas.Reverse();
        }


        private void SalvarPessoasNoArquivo()
        {
            try
            {
                List<string> linhas = new List<string>();

                foreach (var pessoa in listaPessoas)
                {
                    linhas.Add($"{pessoa.CPF};{pessoa.Nome};{pessoa.Sexo}");
                }

                File.WriteAllLines(filePath, linhas);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar no arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AlterarPessoaNoArquivo(int index, string novoCPF, string novoNome, string novoSexo)
        {
            try
            {

                string[] linhas = File.ReadAllLines(filePath);


                linhas[index] = $"{novoCPF};{novoNome};{novoSexo}";


                File.WriteAllLines(filePath, linhas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcluirPessoaDoArquivo(int index)
        {
            try
            {
               
                List<string> linhas = new List<string>(File.ReadAllLines(filePath));

                
                if (index >= 0 && index < linhas.Count)
                {
                   
                    string[] dadosPessoa = linhas[index].Split(';'); 
                    string cpfPessoa = dadosPessoa[0]; 

                    
                    DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir a pessoa com CPF {cpfPessoa}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    
                    if (resultado == DialogResult.Yes)
                    {
                        
                        linhas.RemoveAt(index);

                        
                        File.WriteAllLines(filePath, linhas);

                        
                        MessageBox.Show("Pessoa excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    else
                    {
                        
                        MessageBox.Show("Exclusão cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Índice inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Erro ao excluir do arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private void alterar_pessoa_Click_1(object sender, EventArgs e)
        {

            if (dgvPessoas.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPessoas.SelectedCells[0].RowIndex;
                int index = listaPessoas.Count - 1 - rowIndex;

                if (index >= 0 && index < listaPessoas.Count)
                {

                    string novoCPF = cpf_box.Text;
                    string novoNome = nome_box.Text;
                    string novoSexo = ObterSexoEscolhido();

                    if (string.IsNullOrEmpty(novoNome) || string.IsNullOrEmpty(novoCPF) || string.IsNullOrEmpty(novoSexo))
                    {
                        MessageBox.Show("Por favor, preencha todos os campos antes de alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                        AlterarPessoaNoArquivo(index, novoCPF, novoNome, novoSexo);

                        listaPessoas = CarregarPessoasDoArquivo();
                        AtualizarDataGridView();

                        
                        Title_alterar.Visible = false;
                        alterar_pessoa.Visible = false;
                        alterar_cancelar.Visible = false;

                        LimparCampos();
                        LimparSex();
                        MostrarForm();

                    

                    
                }
            }
        }


        private List<Pessoa> CarregarPessoasDoArquivo()
        {
            List<Pessoa> lista = new List<Pessoa>();

            if (File.Exists(filePath))
            {
                try
                {
                    string[] linhas = File.ReadAllLines(filePath);

                    foreach (var linha in linhas)
                    {
                        string[] dados = linha.Split(';');
                        string cpf = dados[0];
                        string nome = dados[1];
                        string sexo = dados[2];

                        Pessoa pessoa = new Pessoa(cpf, nome, sexo);
                        lista.Add(pessoa);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lista;
        }

        private bool ExisteCPFNoArquivo(string cpf)
        {
            try
            {
                
                string[] linhas = File.ReadAllLines(filePath);

                
                foreach (var linha in linhas)
                {
                    string[] dados = linha.Split(';'); 
                    if (dados.Length > 0 && dados[0].Trim() == cpf.Trim())
                    {
                        MessageBox.Show($"O CPF já existe no arquivo.", "Duplicidade de CPF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true; 
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar CPF no arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // Função para Excluir e Alterar
        private void DgvPessoas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPessoas.Columns["Alterar"].Index)
            {
                int index = listaPessoas.Count - 1 - e.RowIndex;

                if (index >= 0 && index < listaPessoas.Count)
                {
                    Pessoa pessoaSelecionada = listaPessoas[index];

                    cpf_box.Text = pessoaSelecionada.CPF;
                    nome_box.Text = pessoaSelecionada.Nome;

                    if (pessoaSelecionada.Sexo == "Masculino")
                    {
                        Masculino.Checked = true;
                    }
                    else if (pessoaSelecionada.Sexo == "Feminino")
                    {
                        Feminino.Checked = true;
                    }

                    MostrarForm();
                    cpf_box.Visible = false;
                    CPF.Visible = false;
                    Title_nova.Visible = false;
                    Title_alterar.Visible = true;
                    cadastrar_pessoa.Visible = false;
                    alterar_pessoa.Visible = true;
                    alterar_cancelar.Visible = true;



                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvPessoas.Columns["Excluir"].Index)
            {

                int rowIndex = dgvPessoas.SelectedCells[0].RowIndex;
                int index = listaPessoas.Count - 1 - rowIndex;

                if (index >= 0 && index < listaPessoas.Count)
                {

                    ExcluirPessoaDoArquivo(index);

                    EsconderForm();
                    LimparCampos();
                    LimparSex();

                    listaPessoas = CarregarPessoasDoArquivo();

                    AtualizarDataGridView();

                }
            }
        }

        // Cancelar Altereção
        private void alterar_cancelar_Click(object sender, EventArgs e)
        {

            LimparCampos();
            LimparSex();
            EsconderForm();
        }

        // Botão Nova Pessoa
        private void novapessoa_Click_1(object sender, EventArgs e)
        {

            LimparCampos();
            LimparSex();
            MostrarForm();

        }

        // Função para Mostrar o Form
        private void MostrarForm()
        {
            Title_nova.Visible = true;
            novapessoa_esconder.Visible = true;
            cadastrar_pessoa.Visible = true;
            Nome.Visible = true;
            nome_box.Visible = true;
            CPF.Visible = true;
            cpf_box.Visible = true;
            sex_box.Visible = true;
            alterar_pessoa.Visible = false;
            alterar_cancelar.Visible = false;
            Title_alterar.Visible = false;


        }

        // Função para Esconder o Form
        private void EsconderForm()
        {

            Title_nova.Visible = false;
            Title_alterar.Visible = false;
            cadastrar_pessoa.Visible = false;
            Nome.Visible = false;
            nome_box.Visible = false;
            CPF.Visible = false;
            cpf_box.Visible = false;
            sex_box.Visible = false;
            novapessoa_esconder.Visible = false;
            alterar_pessoa.Visible = false;
            alterar_cancelar.Visible = false;
            alterar_pessoa.Visible = false;
            alterar_cancelar.Visible = false;


        }

        // Manipulador de eventos para o clique no botão "Esconder"
        private void novapessoa_esconder_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
            LimparSex();
            EsconderForm();

        }
    }
}
