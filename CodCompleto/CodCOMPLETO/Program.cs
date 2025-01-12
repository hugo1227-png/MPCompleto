using System;
using System.Collections.Generic;

class Sistema
{
    private List<Jogador> jogadoresRegistrados = new List<Jogador>();
    private Jogo jogoAtual;

    // Classe Jogador
    class Jogador
    {
        public string Nome { get; }

        public Jogador(string nome)
        {
            Nome = nome;
        }
    }

    // Classe Jogo
    class Jogo
    {
        public Jogador JogadorA { get; private set; }
        public Jogador JogadorB { get; private set; }
        public bool EmAndamento { get; set; }

        public Jogo(Jogador jogadorA, Jogador jogadorB)
        {
            JogadorA = jogadorA;
            JogadorB = jogadorB;
            EmAndamento = true;
        }

        public void IniciarJogo()
        {
            EmAndamento = true;
            Console.WriteLine("Jogo iniciado com sucesso.");
        }

        public void EncerrarJogo()
        {
            EmAndamento = false;
            Console.WriteLine("Jogo encerrado com sucesso.");
        }
    }

    // Método para registrar jogador
    public string RegistrarJogador(string nomeJogador)
    {
        if (jogadoresRegistrados.Exists(j => j.Nome == nomeJogador))
        {
            return "Jogador já registrado.";
        }
        jogadoresRegistrados.Add(new Jogador(nomeJogador));
        return "Jogador registrado com sucesso.";
    }

    // Método para listar jogadores registrados
    public void ListarJogadores()
    {
        if (jogadoresRegistrados.Count == 0)
        {
            Console.WriteLine("Sem jogadores registrados.");
        }
        else
        {
            foreach (var jogador in jogadoresRegistrados)
            {
                Console.WriteLine($"Jogador: {jogador.Nome}");
            }
        }
    }

    // Método para iniciar o jogo
    public string IniciarJogo(string comando, string nomeJogadorA, string nomeJogadorB)
    {
        if (jogoAtual != null && jogoAtual.EmAndamento)
        {
            return "Existe um jogo em curso.";
        }

        // Verificar se os jogadores estão registrados
        Jogador jogadorA = jogadoresRegistrados.Find(j => j.Nome == nomeJogadorA);
        Jogador jogadorB = jogadoresRegistrados.Find(j => j.Nome == nomeJogadorB);

        if (jogadorA == null || jogadorB == null)
        {
            return "Jogador inexistente.";
        }

        // Caso seja uma continuação do jogo
        if (comando == "Continuação")
        {
            // Aqui você pode carregar o estado do jogo a partir de um arquivo ou estrutura
            Console.WriteLine("Jogo em continuação.");
        }
        else
        {
            // Caso seja um jogo novo
            jogoAtual = new Jogo(jogadorA, jogadorB);
            jogoAtual.IniciarJogo();
        }

        // Exibe o tabuleiro após iniciar o jogo
        ExibirTabuleiro();

        return "Jogo iniciado com sucesso.";
    }

    // Método para realizar movimentos (MP)
    public void RealizarMovimento(string nomeJogador, string posicaoInicial, string posicaoFinal)
    {
        if (jogoAtual == null || !jogoAtual.EmAndamento)
        {
            Console.WriteLine("Não existe jogo em curso.");
            return;
        }

        if (nomeJogador != jogoAtual.JogadorA.Nome && nomeJogador != jogoAtual.JogadorB.Nome)
        {
            Console.WriteLine("Jogador não participa no jogo em curso.");
            return;
        }

        // Lógica para verificar e realizar movimento
        Console.WriteLine($"{nomeJogador} moveu de {posicaoInicial} para {posicaoFinal}.");
    }

    // Método para realizar a troca de peças (OS)
    public void RealizarTroca(string nomeJogador, string posicaoInicial, string posicaoFinal)
    {
        if (jogoAtual == null || !jogoAtual.EmAndamento)
        {
            Console.WriteLine("Não existe jogo em curso.");
            return;
        }

        if (nomeJogador != jogoAtual.JogadorA.Nome && nomeJogador != jogoAtual.JogadorB.Nome)
        {
            Console.WriteLine("Jogador não participa no jogo em curso.");
            return;
        }

        // Lógica para troca de peças
        Console.WriteLine($"{nomeJogador} trocou as peças de {posicaoInicial} para {posicaoFinal}.");
    }

    // Método para exibir o tabuleiro (DJ)
    public void ExibirTabuleiro()
    {
        if (jogoAtual == null || !jogoAtual.EmAndamento)
        {
            Console.WriteLine("Não existe jogo em curso.");
            return;
        }

        // Exibição simplificada do tabuleiro
        Console.WriteLine("Tabuleiro:");
        Console.WriteLine("A    B    C    D    E    F    G    H");
        Console.WriteLine("1  BR1  BH1  BB1  BQ1  BK1  BB2  BH2  BR2");
        Console.WriteLine("2  BP1  BP2  BP3  BP4  BP5  BP6  BP7  BP8");
        Console.WriteLine("3  ,,,,,,");
        Console.WriteLine("4  ,,,,,,");
        Console.WriteLine("5  ,,,,,,");
        Console.WriteLine("6  ,,,,,,");
        Console.WriteLine("7  WP1  WP2  WP3  WP4  WP5  WP6  WP7  WP8");
        Console.WriteLine("8  WR1  WH1  WB1  WQ1  WK1  WB2  WH2  WR2");
    }

    // Método para encerrar o jogo
    public void EncerrarJogo()
    {
        if (jogoAtual == null || !jogoAtual.EmAndamento)
        {
            Console.WriteLine("Não existe jogo em curso.");
            return;
        }

        jogoAtual.EncerrarJogo();
    }

    // Método para salvar o jogo
    public void SalvarJogo(string nomeFicheiro)
    {
        if (jogoAtual == null || !jogoAtual.EmAndamento)
        {
            Console.WriteLine("Não existe jogo em curso.");
            return;
        }

        // Salvar o estado do jogo no arquivo
        Console.WriteLine($"Jogo gravado com sucesso em {nomeFicheiro}.");
    }

    // Método para carregar o jogo
    public void CarregarJogo(string nomeFicheiro)
    {
        if (jogoAtual != null && jogoAtual.EmAndamento)
        {
            Console.WriteLine("Existe um jogo em curso.");
            return;
        }

        // Carregar o estado do jogo a partir do arquivo
        Console.WriteLine($"Jogo lido com sucesso de {nomeFicheiro}.");
    }


    public void peças(string[] args)
    {
        // Inicialização do tabuleiro com as posições iniciais das peças
        Dictionary<string, string> tabuleiro = new Dictionary<string, string>()
        {
            // Peças pretas
            {"A1", "BR1"}, {"B1", "BH1"}, {"C1", "BB1"}, {"D1", "BQ1"}, {"E1", "BK1"}, {"F1", "BB2"}, {"G1", "BH2"}, {"H1", "BR2"},
            {"A2", "BP1"}, {"B2", "BP2"}, {"C2", "BP3"}, {"D2", "BP4"}, {"E2", "BP5"}, {"F2", "BP6"}, {"G2", "BP7"}, {"H2", "BP8"},

            // Peças brancas
            {"A7", "WP1"}, {"B7", "WP2"}, {"C7", "WP3"}, {"D7", "WP4"}, {"E7", "WP5"}, {"F7", "WP6"}, {"G7", "WP7"}, {"H7", "WP8"},
            {"A8", "WR1"}, {"B8", "WH1"}, {"C8", "WB1"}, {"D8", "WQ1"}, {"E8", "WK1"}, {"F8", "WB2"}, {"G8", "WH2"}, {"H8", "WR2"}
        };

        // Controle de operações especiais
        Dictionary<string, bool> operacoesEspeciais = new Dictionary<string, bool>
        {
            {"PeaoParaTras", true},
            {"TorreCapturaDupla", true},
            {"BispoCapturaArea", true},
            {"Cavalo4Casas", true},
            {"RainhaTroca", true}
        };

        string turno = "W"; // Brancos começam
        int movimentosSemCapturaOuPeao = 0;
        List<string> historicoPosicoes = new List<string>();

        while (true)
        {
            ImprimirTabuleiro(tabuleiro);

            string comando = Console.ReadLine();

            string[] partes = comando.Split(' ');
            if (partes.Length >= 3 && (partes[0] == "MP" || partes[0] == "OS"))
            {
                string posicaoInicial = partes[1];
                string posicaoFinal = partes[2];

                if (!tabuleiro.ContainsKey(posicaoInicial) || tabuleiro[posicaoInicial][0].ToString() != turno)
                {
                    Console.WriteLine("Movimento inválido: peça não pertence ao jogador atual ou posição inicial está vazia.");
                    continue;
                }

                string nomePeca = tabuleiro[posicaoInicial];

                // Verifica se é um movimento válido ou uma operação especial
                if (MovimentoValido(nomePeca, posicaoInicial, posicaoFinal, tabuleiro, operacoesEspeciais))
                {
                    // Atualiza o tabuleiro para movimentos normais ou especiais
                    bool capturou = tabuleiro.ContainsKey(posicaoFinal);
                    if (capturou || nomePeca[1] == 'P') movimentosSemCapturaOuPeao = 0;
                    else movimentosSemCapturaOuPeao++;

                    tabuleiro[posicaoFinal] = nomePeca;
                    tabuleiro.Remove(posicaoInicial);

                    Console.WriteLine($"{(turno == "W" ? "Branco" : "Preto")} moveu {nomePeca} de {posicaoInicial} para {posicaoFinal}.");

                    // Verifica estado do jogo
                    if (EstaEmCheque(turno == "W" ? 'B' : 'W', tabuleiro))
                    {
                        Console.WriteLine("Rei adversário está em cheque!");
                        if (EstaEmXequeMate(turno == "W" ? 'B' : 'W', tabuleiro))
                        {
                            Console.WriteLine("Xeque-mate! Fim de jogo.");
                            break;
                        }
                    }

                    // Verifica empate
                    if (movimentosSemCapturaOuPeao >= 50)
                    {
                        Console.WriteLine("Empate por regra dos 50 movimentos.");
                        break;
                    }

                    string posicaoAtual = string.Join(";", tabuleiro.OrderBy(kv => kv.Key).Select(kv => kv.Value + kv.Key));
                    historicoPosicoes.Add(posicaoAtual);
                    if (historicoPosicoes.Count(x => x == posicaoAtual) >= 3)
                    {
                        Console.WriteLine("Empate por repetição de posição.");
                        break;
                    }

                    turno = turno == "W" ? "B" : "W";
                }
                else
                {
                    Console.WriteLine("Movimento inválido ou operação especial indisponível.");
                }
            }
            else
            {
                Console.WriteLine("Comando inválido. Certifique-se de usar o formato correto.");
            }
        }
    }

    static bool MovimentoValido(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro, Dictionary<string, bool> operacoesEspeciais)
    {
        char tipo = nomePeca[1];

        switch (tipo)
        {
            case 'P':
                return MovimentoPeao(nomePeca, posicaoInicial, posicaoFinal, tabuleiro, operacoesEspeciais);
            case 'R':
                return MovimentoTorre(nomePeca, posicaoInicial, posicaoFinal, tabuleiro, operacoesEspeciais);
            case 'H':
                return MovimentoCavalo(nomePeca, posicaoInicial, posicaoFinal, tabuleiro);
            case 'B':
                return MovimentoBispo(nomePeca, posicaoInicial, posicaoFinal, tabuleiro, operacoesEspeciais);
            case 'Q':
                return MovimentoRainha(nomePeca, posicaoInicial, posicaoFinal, tabuleiro);
            case 'K':
                return MovimentoRei(nomePeca, posicaoInicial, posicaoFinal, tabuleiro);
            default:
                return false;
        }
    }

    static bool MovimentoPeao(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro, Dictionary<string, bool> operacoesEspeciais)
    {
        int direcao = nomePeca[0] == 'W' ? -1 : 1;
        int linhaInicial = int.Parse(posicaoInicial[1].ToString());
        int linhaFinal = int.Parse(posicaoFinal[1].ToString());
        char colunaInicial = posicaoInicial[0];
        char colunaFinal = posicaoFinal[0];

        // Movimento normal para frente
        if (colunaInicial == colunaFinal && linhaFinal == linhaInicial + direcao && !tabuleiro.ContainsKey(posicaoFinal))
        {
            return true;
        }

        // Captura diagonal
        if (Math.Abs(colunaFinal - colunaInicial) == 1 && linhaFinal == linhaInicial + direcao && tabuleiro.ContainsKey(posicaoFinal) && tabuleiro[posicaoFinal][0] != nomePeca[0])
        {
            return true;
        }

        // Movimento especial: andar para trás
        if (operacoesEspeciais["PeaoParaTras"] && colunaInicial == colunaFinal && linhaFinal == linhaInicial - direcao && !tabuleiro.ContainsKey(posicaoFinal))
        {
            operacoesEspeciais["PeaoParaTras"] = false; 
            return true;
        }

        return false;
    }

    static bool MovimentoTorre(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro, Dictionary<string, bool> operacoesEspeciais)
    {
        // Verifica movimento reto
        if (!MovimentoReto(posicaoInicial, posicaoFinal, tabuleiro)) return false;

        // Movimento especial: captura dupla
        if (operacoesEspeciais["TorreCapturaDupla"])
        {
            List<string> capturas = PecasEntre(posicaoInicial, posicaoFinal, tabuleiro);
            if (capturas.Count == 2 && capturas.All(p => tabuleiro[p][0] != nomePeca[0]))
            {
                operacoesEspeciais["TorreCapturaDupla"] = false; // Marca como usada
                foreach (var captura in capturas) tabuleiro.Remove(captura);
                return true;
            }
        }

        return true;
    }

    static bool MovimentoBispo(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro, Dictionary<string, bool> operacoesEspeciais)
    {
        // Verifica movimento diagonal
        if (!MovimentoDiagonal(posicaoInicial, posicaoFinal, tabuleiro)) return false;

        // Movimento especial: captura em área
        if (operacoesEspeciais["BispoCapturaArea"] && posicaoInicial == posicaoFinal)
        {
            operacoesEspeciais["BispoCapturaArea"] = false; // Marca como usada
            int linhaCentral = int.Parse(posicaoInicial[1].ToString());
            char colunaCentral = posicaoInicial[0];

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    string posicao = "" + (char)(colunaCentral + i) + (linhaCentral + j);
                    if (tabuleiro.ContainsKey(posicao) && tabuleiro[posicao][0] != nomePeca[0])
                    {
                        tabuleiro.Remove(posicao);
                    }
                }
            }

            return true;
        }

        return true;
    }

    static bool MovimentoRainha(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
    {
        // Movimento normal da rainha (combinação de torre e bispo)
        if (MovimentoReto(posicaoInicial, posicaoFinal, tabuleiro) || MovimentoDiagonal(posicaoInicial, posicaoFinal, tabuleiro))
        {
            return true;
        }

        // Movimento especial: troca com o rei
        if (tabuleiro.ContainsKey(posicaoFinal) && tabuleiro[posicaoFinal][1] == 'K' && tabuleiro[posicaoFinal][0] == nomePeca[0])
        {
            // Certifica que o rei não está em cheque antes e após a troca
            if (!EstaEmCheque(nomePeca[0], tabuleiro))
            {
                string rei = tabuleiro[posicaoFinal];
                tabuleiro[posicaoFinal] = nomePeca;
                tabuleiro[posicaoInicial] = rei;
                return true;
            }
        }

        return false;
    }

    static bool MovimentoRei(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
{
    int linhaInicial = int.Parse(posicaoInicial[1].ToString());
    int linhaFinal = int.Parse(posicaoFinal[1].ToString());
    char colunaInicial = posicaoInicial[0];
    char colunaFinal = posicaoFinal[0];

    // Verifica o movimento normal do rei (uma casa em qualquer direção)
    if (Math.Abs(colunaFinal - colunaInicial) <= 1 && Math.Abs(linhaFinal - linhaInicial) <= 1)
    {
        // Permite captura, desde que a peça de destino seja inimiga ou esteja vazia
        if (!tabuleiro.ContainsKey(posicaoFinal) || tabuleiro[posicaoFinal][0] != nomePeca[0])
        {
            // Simula o movimento para verificar se o rei ficará em cheque
            string? pecaCapturada = tabuleiro.ContainsKey(posicaoFinal) ? tabuleiro[posicaoFinal] : null;
            tabuleiro[posicaoFinal] = nomePeca;
            tabuleiro.Remove(posicaoInicial);

            bool seguro = !EstaEmCheque(nomePeca[0], tabuleiro);

            // Reverte a simulação
            tabuleiro[posicaoInicial] = nomePeca;
            if (pecaCapturada != null)
            {
                tabuleiro[posicaoFinal] = pecaCapturada;
            }
            else
            {
                tabuleiro.Remove(posicaoFinal);
            }

            return seguro;
        }
    }

    return false;
}


    static bool MovimentoCavalo(string nomePeca, string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
{
    int linhaInicial = int.Parse(posicaoInicial[1].ToString());
    int linhaFinal = int.Parse(posicaoFinal[1].ToString());
    char colunaInicial = posicaoInicial[0];
    char colunaFinal = posicaoFinal[0];

    // Verifica o movimento padrão em "L"
    if ((Math.Abs(colunaFinal - colunaInicial) == 2 && Math.Abs(linhaFinal - linhaInicial) == 1) ||
        (Math.Abs(colunaFinal - colunaInicial) == 1 && Math.Abs(linhaFinal - linhaInicial) == 2))
    {
        return !tabuleiro.ContainsKey(posicaoFinal) || tabuleiro[posicaoFinal][0] != nomePeca[0];
    }

    if (PodeExecutarOperacaoEspecialCavalo(posicaoInicial, tabuleiro))
    {
        if (Math.Abs(colunaFinal - colunaInicial) == Math.Abs(linhaFinal - linhaInicial) || // Diagonal
            colunaInicial == colunaFinal || // Vertical
            linhaInicial == linhaFinal) // Horizontal
        {
            int distancia = Math.Max(Math.Abs(colunaFinal - colunaInicial), Math.Abs(linhaFinal - linhaInicial));
            if (distancia == 4)
            {
                // Verifica se o caminho está livre até a posição final
                List<string> caminho = PecasEntre(posicaoInicial, posicaoFinal, tabuleiro);
                if (caminho.Count == 0 || (caminho.Count == 1 && tabuleiro.ContainsKey(posicaoFinal) && tabuleiro[posicaoFinal][0] != nomePeca[0]))
                {
                    return true;
                }
            }
        }
    }

    return false;
}

static bool PodeExecutarOperacaoEspecialCavalo(string posicaoInicial, Dictionary<string, string> tabuleiro)
{       

    int linha = int.Parse(posicaoInicial[1].ToString());
    char coluna = posicaoInicial[0];

    // Verifica se o cavalo está encostado a qualquer outra peça
    for (int i = -1; i <= 1; i++)
    {
        for (int j = -1; j <= 1; j++)
        {
            if (i == 0 && j == 0) continue;

            string posicaoAdjacente = "" + (char)(coluna + i) + (linha + j);
            if (tabuleiro.ContainsKey(posicaoAdjacente)) return false;
        }
    }

    return true;
}


    static bool MovimentoReto(string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
    {
        // Implementa movimento reto horizontal ou vertical
        return posicaoInicial[0] == posicaoFinal[0] || posicaoInicial[1] == posicaoFinal[1];
    }

    static bool MovimentoDiagonal(string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
    {
        // Implementa movimento diagonal
        return Math.Abs(posicaoFinal[0] - posicaoInicial[0]) == Math.Abs(posicaoFinal[1] - posicaoInicial[1]);
    }

    static List<string> PecasEntre(string posicaoInicial, string posicaoFinal, Dictionary<string, string> tabuleiro)
    {
        // Retorna lista de posições entre inicial e final
        List<string> pecasEntre = new List<string>();
        char colunaInicial = posicaoInicial[0];
        char colunaFinal = posicaoFinal[0];
        int linhaInicial = int.Parse(posicaoInicial[1].ToString());
        int linhaFinal = int.Parse(posicaoFinal[1].ToString());

        if (colunaInicial == colunaFinal)
        {
            for (int linha = Math.Min(linhaInicial, linhaFinal) + 1; linha < Math.Max(linhaInicial, linhaFinal); linha++)
            {
                string posicao = "" + colunaInicial + linha;
                if (tabuleiro.ContainsKey(posicao)) pecasEntre.Add(posicao);
            }
        }
        else if (linhaInicial == linhaFinal)
        {
            for (char coluna = (char)(Math.Min(colunaInicial, colunaFinal) + 1); coluna < Math.Max(colunaInicial, colunaFinal); coluna++)
            {
                string posicao = "" + coluna + linhaInicial;
                if (tabuleiro.ContainsKey(posicao)) pecasEntre.Add(posicao);
            }
        }

        return pecasEntre;
    }

    static void ImprimirTabuleiro(Dictionary<string, string> tabuleiro)
    {
        // Função para imprimir o tabuleiro
        for (int linha = 8; linha >= 1; linha--)
        {
            for (char coluna = 'A'; coluna <= 'H'; coluna++)
            {
                string posicao = "" + coluna + linha;
                                if (tabuleiro.ContainsKey(posicao))
                {
                    Console.Write(tabuleiro[posicao].PadRight(4));
                }
                else
                {
                    Console.Write("....".PadRight(4));
                }
            }
            Console.WriteLine();
        }
    }

    static bool EstaEmCheque(char corRei, Dictionary<string, string> tabuleiro)
    {
        // Função para verificar se o rei está em cheque
        string posicaoRei = tabuleiro.FirstOrDefault(kv => kv.Value == $"{corRei}K1").Key;
        if (string.IsNullOrEmpty(posicaoRei)) return false;

        foreach (var peca in tabuleiro)
        {
            if (peca.Value[0] != corRei)
            {
                if (MovimentoValido(peca.Value, peca.Key, posicaoRei, tabuleiro, new Dictionary<string, bool>()))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool EstaEmXequeMate(char corRei, Dictionary<string, string> tabuleiro)
    {
        // Função para verificar se o rei está em xeque-mate
        string posicaoRei = tabuleiro.FirstOrDefault(kv => kv.Value == $"{corRei}K1").Key;
        if (string.IsNullOrEmpty(posicaoRei)) return false;

        if (!EstaEmCheque(corRei, tabuleiro)) return false;

        foreach (var peca in tabuleiro.Where(kv => kv.Value[0] == corRei))
        {
            for (char coluna = 'A'; coluna <= 'H'; coluna++)
            {
                for (int linha = 1; linha <= 8; linha++)
                {
                    string destino = "" + coluna + linha;
                    if (MovimentoValido(peca.Value, peca.Key, destino, tabuleiro, new Dictionary<string, bool>()))
                    {
                        // Simula o movimento
                        string? pecaCapturada = tabuleiro.ContainsKey(destino) ? tabuleiro[destino] : null;
                        tabuleiro[destino] = peca.Value;
                        tabuleiro.Remove(peca.Key);

                        bool emCheque = EstaEmCheque(corRei, tabuleiro);

                        // Desfaz o movimento
                        tabuleiro[peca.Key] = peca.Value;
                        if (pecaCapturada != null) tabuleiro[destino] = pecaCapturada;
                        else tabuleiro.Remove(destino);

                        if (!emCheque) return false;
                    }
                }
            }
        }

        return true;
    }
}






class Program
{
    static void Main()
    {
        Sistema sistema = new Sistema();

        while (true)
        {
            string entrada = Console.ReadLine();
            string[] partes = entrada.Split(' ');

            // Verificação de comando "RJ" para registrar jogador
            if (partes.Length == 2 && partes[0] == "RJ") // Registrar Jogador
            {
                string resultado = sistema.RegistrarJogador(partes[1]);
                Console.WriteLine(resultado);
            }
            // Verificação de comando "LJ" para listar jogadores
            else if (partes.Length == 1 && partes[0] == "LJ") // Listar Jogadores
            {
                sistema.ListarJogadores();
            }
            // Verificação de comando "IJ" para iniciar jogo
            else if (partes.Length == 4 && partes[0] == "IJ") // Iniciar Jogo
            {
                string resultado = sistema.IniciarJogo(partes[1], partes[2], partes[3]);
                Console.WriteLine(resultado);
            }
            // Verificação de comando "MP" para realizar movimento
            else if (partes.Length == 4 && partes[0] == "MP") // Movimento
            {
                sistema.RealizarMovimento(partes[1], partes[2], partes[3]);
            }
            // Verificação de comando "OS" para troca de peças
            else if (partes.Length == 4 && partes[0] == "OS") // Operações especiais
            {
                sistema.RealizarTroca(partes[1], partes[2], partes[3]);
            }
            // Verificação de comando "DJ" para exibir tabuleiro
            else if (partes.Length == 1 && partes[0] == "DJ") // Exibir Tabuleiro
            {
                sistema.ExibirTabuleiro();
            }
            // Verificação de comando "D" para encerrar jogo
            else if (partes.Length == 1 && partes[0] == "D") // Desistir do Jogo
            {
                sistema.EncerrarJogo();
            }
            // Verificação de comando "G" para salvar jogo
            else if (partes.Length == 2 && partes[0] == "G") // Gravar Jogo
            {
                sistema.SalvarJogo(partes[1]);
            }
            // Verificação de comando "L" para carregar jogo
            else if (partes.Length == 2 && partes[0] == "L") // Carregar Jogo
            {
                sistema.CarregarJogo(partes[1]);
            }
            else
            {
                Console.WriteLine("Comando inválido.");
            }
        }
    }
}