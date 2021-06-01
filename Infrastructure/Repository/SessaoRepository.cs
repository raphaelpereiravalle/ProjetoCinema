using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.Domain.Model;
using System;
using System.Threading.Tasks;

namespace ProjetoCinema.Infrastructure
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly string _config;

        public SessaoRepository(IConfiguration config)
        {
            _config = config.GetConnectionString("DefaultConnection");
        }

        public async Task<Notificacao> IncluirSessao(Sessao sessao)
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    conexao.Open();

                    using (var trans = conexao.BeginTransaction())
                    {
                        try
                        {
                            string query = @"INSERT INTO tb_sessao
                                                   (IdSessao,
                                                    DataSessao,
                                                    HoraInicioSessao,
                                                    HoraFimSessao,
                                                    ValorIngresso,
                                                    TipoAnimacao,
                                                    TipoAudio,
                                                    DataRegistro,
                                                    Ativo,
                                                    IdUsuario)
                                               VALUES
                                                   (@IdSessao,
                                                    @DataSessao,
                                                    @HoraInicioSessao,
                                                    @HoraFimSessao,
                                                    @ValorIngresso,
                                                    @TipoAnimacao,
                                                    @TipoAudio,
                                                    @DataRegistro,
                                                    @Ativo,
                                                    @IdUsuario)";

                            Guid guid = Guid.NewGuid();

                            await conexao.ExecuteAsync(query, new
                            {
                                IdSessao = guid.ToString(),
                                DataSessao = sessao.DataSessao,
                                HoraInicioSessao = sessao.HoraInicioSessao,
                                HoraFimSessao = sessao.HoraFimSessao,
                                ValorIngresso = sessao.ValorIngresso,
                                TipoAnimacao = sessao.TipoAnimacao,
                                TipoAudio = sessao.TipoAudio,
                                DataRegistro = DateTime.Now,
                                Ativo = true,
                                IdUsuario = sessao.IdUsuario,
                            }, transaction: trans);

                            //--------------------------

                            //Filme
                            string query2 = @"INSERT INTO tb_sessao_filme
                                                (IdFilmeSessao,
                                                 IdFilme,
                                                 IdSala,
                                                 IdSessao)
                                             VALUES
                                                (@IdFilmeSessao,
                                                 @IdFilme,
                                                 @IdSala,
                                                 @IdSessao)";

                            Guid guid2 = Guid.NewGuid();
                            await conexao.ExecuteAsync(query2, new
                            {
                                IdFilmeSessao = guid2.ToString(),
                                IdFilme = sessao.IdFilme,
                                IdSala = sessao.IdSala,
                                IdSessao = guid.ToString()
                            }, transaction: trans);

                            trans.Commit();

                            return new Notificacao(false, "Cadastro realizado com sucesso!", "");
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível inserir a sessão!", ex.Message);
                }
            }
        }

        public async Task<DadosSessao> ListarSessao()
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    string query = @"SELECT 
                                         sf.IdFilmeSessao
                                        ,sf.IdFilme
                                        ,f.Titulo
                                        ,sf.IdSala
                                        ,s.Nome
                                        ,ss.IdSessao
                                        ,ss.DataSessao
                                        ,FORMAT(CAST(ss.HoraInicioSessao AS TIME), N'hh\:mm') AS HoraInicioSessao
                                        ,FORMAT(CAST(ss.HoraFimSessao AS TIME), N'hh\:mm') AS HoraFimSessao
                                        ,ss.ValorIngresso
                                        ,ss.TipoAnimacao
                                        ,ss.TipoAudio
                                        ,ss.DataRegistro
                                        ,ss.Ativo
                                        ,ss.IdUsuario
                                    FROM tb_sessao_filme sf
                                    INNER JOIN tb_filme AS f ON (f.IdFilme  = sf.IdFilme)
                                    INNER JOIN tb_sessao AS ss ON (ss.IdSessao = sf.IdSessao)
                                    INNER JOIN tb_sala AS s ON (s.IdSala = sf.IdSala)
                                    ORDER BY s.Nome ASC";

                    return new DadosSessao(false, "Listagem realizada com sucesso", await conexao.QueryAsync<Sessao>(string.Format(query)));
                }
            }
            catch (Exception ex)
            {
                return new DadosSessao(true, "Erro ao listar" + ex, null);
            }
        }

        public async Task<Sessao> BuscarSessao(string idSessao)
        {
            using (SqlConnection conexao = new SqlConnection(_config))
            {
                try
                {
                    string query = $@"SELECT 
                                         sf.IdFilmeSessao
                                        ,sf.IdFilme
                                        ,f.Titulo
                                        ,sf.IdSala
                                        ,s.Nome
                                        ,ss.IdSessao
                                        ,ss.DataSessao
                                        ,FORMAT(CAST(ss.HoraInicioSessao AS TIME), N'hh\:mm') AS HoraInicioSessao
                                        ,FORMAT(CAST(ss.HoraFimSessao AS TIME), N'hh\:mm') AS HoraFimSessao
                                        ,ss.ValorIngresso
                                        ,ss.TipoAnimacao
                                        ,ss.TipoAudio
                                        ,ss.DataRegistro
                                        ,ss.Ativo
                                        ,ss.IdUsuario
                                    FROM tb_sessao_filme sf
                                    INNER JOIN tb_filme AS f ON (f.IdFilme  = sf.IdFilme)
                                    INNER JOIN tb_sessao AS ss ON (ss.IdSessao = sf.IdSessao)
                                    INNER JOIN tb_sala AS s ON (s.IdSala = sf.IdSala)
                                    WHERE ss.IdSessao='{idSessao}'";

                    return await conexao.QueryFirstAsync<Sessao>(string.Format(query));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<Notificacao> VerificarExisteSalaSessao(string IdSala, string HoraInicioSessao)
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    string queryVerificarExisteSalaSessao = $@"SELECT 
                                                            sa.IdSala
                                                            FROM tb_sessao_filme AS sf
                                                            INNER JOIN tb_sessao as s ON s.IdSessao = sf.IdSessao
                                                            INNER JOIN tb_filme AS f ON sf.IdFilme = f.IdFilme
                                                            INNER JOIN tb_sala AS sa ON sa.IdSala = sf.IdSala 
                                                            WHERE sa.IdSala = '{IdSala}'
                                                            AND HoraInicioSessao = '{HoraInicioSessao}'";

                    string verificar = await conexao.QueryFirstOrDefaultAsync<string>(string.Format(queryVerificarExisteSalaSessao));

                    if (string.IsNullOrEmpty(verificar))
                    {
                        return new Notificacao(false, null, null);
                    }

                    return new Notificacao(true, "Já existe sessão cadastrada para essa sala!", null);
                }
            }
            catch (Exception ex)
            {
                return new Notificacao(true, "Não foi possível inserir a sessão!", ex.Message);
            }
        }

        public async Task<Notificacao> EditarSessao(Sessao sessao)
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    conexao.Open();

                    using (var trans = conexao.BeginTransaction())
                    {
                        try
                        {
                            string query = @"UPDATE tb_sessao
                                                  SET
                                                    DataSessao = @DataSessao,
                                                    HoraInicioSessao = @HoraInicioSessao,
                                                    HoraFimSessao = @HoraFimSessao,
                                                    ValorIngresso = @ValorIngresso,
                                                    TipoAnimacao = @TipoAnimacao,
                                                    TipoAudio = @TipoAudio,
                                                    DataRegistro = @DataRegistro,
                                                    Ativo = @Ativo,
                                                    IdUsuario = @IdUsuario
                                             WHERE IdSessao = @IdSessao";

                            await conexao.ExecuteAsync(query, new
                            {
                                IdSessao = sessao.IdSessao.ToString(),
                                DataSessao = sessao.DataSessao,
                                HoraInicioSessao = sessao.HoraInicioSessao,
                                HoraFimSessao = sessao.HoraFimSessao,
                                ValorIngresso = sessao.ValorIngresso,
                                TipoAnimacao = sessao.TipoAnimacao,
                                TipoAudio = sessao.TipoAudio,
                                DataRegistro = DateTime.Now,
                                Ativo = true,
                                IdUsuario = sessao.IdUsuario,
                            }, transaction: trans);

                            trans.Commit();

                            return new Notificacao(false, "Atualização realizada com sucesso!", "");
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível editar a sessão!", ex.Message);
                }
            }
        }

        public async Task<Notificacao> ExcluirSessao(string idSessao)
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    // Excluir relacionamento
                    string query1 = $"DELETE FROM tb_sessao_filme WHERE idSessao='{idSessao}'";

                    await conexao.ExecuteAsync(string.Format(query1));

                    string query2 = $"DELETE FROM tb_sessao WHERE idSessao='{idSessao}'";

                    await conexao.ExecuteAsync(string.Format(query2));

                    return new Notificacao(false, "Sessão deletada com sucesso!", null);
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível excluir a sessão", ex.Message);
                }
            }
        }

        // Calcular horário final do filme
        public string CalculadoHoraFinal(string idFilme, string horarioInicio)
        {
            using (var conexao = new SqlConnection(_config))
            {
                // Retorna a duração do filme
                string queryDuracao = @$"SELECT Duracao 
                                        FROM tb_filme 
                                        WHERE IdFilme = '{idFilme}'";

                Filme duracao = new Filme();

                var Duracao = conexao.QueryFirst<string>(string.Format(queryDuracao));

                TimeSpan _horarioInicio = TimeSpan.Parse(horarioInicio);

                TimeSpan _duracaoFilme = TimeSpan.Parse(Duracao);

                string horaFinal = _duracaoFilme.Add(_horarioInicio).ToString(@"hh\:mm");

                return horaFinal;
            }
        }

        // Média do valor dos Ingressos
        public async Task<double> MediaValorIngresso()
        {
            using (var conexao = new SqlConnection(_config))
            {
                string query = @"SELECT CONVERT(DEC(10, 2), AVG(ValorIngresso)) AS mediaValorIngresso
                                 FROM tb_sessao";

                return await conexao.QueryFirstOrDefaultAsync<double>(string.Format(query));
            }
        }

        // Calcular prazo para a exclusão da sessão
        public int CalcularPrazoParaExcluirSessao(string idSessao)
        {
            using (var conexao = new SqlConnection(_config))
            {
                // Retornar 
                string query = @$"SELECT DATEDIFF(DAY, CONVERT(DATE, GETDATE()), DataSessao)
                                  FROM tb_sessao
                                  WHERE IdSessao = '{idSessao}'";

                return conexao.QueryFirst<int>(string.Format(query));
            }
        }
    }
}