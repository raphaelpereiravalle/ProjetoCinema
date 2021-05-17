using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.Domain.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCinema.Infrastructure
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly string _config;

        public FilmeRepository(IConfiguration config)
        {
            _config = config.GetConnectionString("DefaultConnection");
        }

        public async Task<Notificacao> IncluirFilme(Filme filme)
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    // Query para verificar se o filme já foi cadastrado
                    string queryVerificar = $@"SELECT UPPER(Titulo) AS Titulo
                                                FROM tb_filme 
                                                WHERE Titulo like UPPER('%{filme.Titulo}%')";

                    var verificar = conexao.Query<Filme>(queryVerificar, new
                    {
                        Titulo = filme.Titulo

                    }).SingleOrDefault();

                    if (verificar == null)
                    {
                        conexao.Open();

                        using (var trans = conexao.BeginTransaction())
                        {
                            try
                            {
                                string query = @$"INSERT INTO tb_filme
                                               (IdFilme,
                                                Titulo,
                                                Descricao,
                                                Imagem,
                                                Caminho,
                                                Duracao,
                                                DataRegistro,
                                                Ativo,
                                                IdUsuario
		                                       )
                                            VALUES
                                               (@IdFilme,
                                                @Titulo,
                                                @Descricao,
                                                @Imagem,
                                                @Caminho,
                                                @Duracao,
                                                @DataRegistro,
                                                @Ativo,
                                                @IdUsuario
		                                      )";

                                await conexao.ExecuteAsync(query, new
                                {
                                    IdFilme = Guid.NewGuid().ToString(),
                                    Titulo = filme.Titulo,
                                    Descricao = filme.Descricao,
                                    Imagem = filme.Imagem,
                                    Caminho = filme.Caminho,
                                    Duracao = filme.Duracao,
                                    DataRegistro = DateTime.Now,
                                    Ativo = true,
                                    IdUsuario = filme.IdUsuario
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
                    else
                    {
                        return new Notificacao(true, "Filme já cadastrada.", "");
                    }
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível inserir o filme!", ex.Message);
                }
            }
        }

        public async Task<DadosFilme> ListarFilme()
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    string query = @"SELECT 
                                     IdFilme
                                    ,Titulo
                                    ,Descricao
                                    ,Imagem
                                    ,Duracao
                                    ,DataRegistro
                                    ,Ativo
                                    ,IdUsuario
                                    FROM tb_filme";

                    return new DadosFilme(false, "Listagem realizada com sucesso", await conexao.QueryAsync<Filme>(string.Format(query)));
                }
                catch (Exception ex)
                {
                    return new DadosFilme(true, "Erro ao listar" + ex, null);
                }
            }
        }

        public async Task<Filme> BuscarFilme(string idFilme)
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    string query = @$"SELECT
                                    IdFilme
                                    ,Titulo
                                    ,Descricao
                                    ,Imagem
                                    ,Caminho
                                    ,Duracao
                                    ,DataRegistro
                                    ,Ativo
                                    ,IdUsuario
                                  FROM tb_filme
                                  where IdFilme='{idFilme}'";

                    return await conexao.QueryFirstAsync<Filme>(string.Format(query));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Notificacao> EditarFilme(Filme filme)
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
                            // Retornar imagem e o caminho
                            string queryImagem = @$"SELECT Caminho, Imagem 
                                                FROM tb_filme 
                                                WHERE IdFilme = '{filme.IdFilme}'";

                            var verificarImagem = conexao.Query<Filme>(queryImagem, transaction: trans).SingleOrDefault();

                            if (verificarImagem.Imagem != filme.Imagem)
                            {
                                // Deletar imagem do filme
                                excluirImagem(verificarImagem.Caminho, verificarImagem.Imagem);
                            }
                            else
                            {
                                filme.Imagem = verificarImagem.Imagem;
                            }

                            string query = @$"UPDATE tb_filme
                                   SET
                                      Titulo = @Titulo
                                      ,Descricao = @Descricao
                                      ,Imagem = @Imagem
                                      ,Duracao = @Duracao
                                      ,DataRegistro = @DataRegistro
                                      ,Ativo = @Ativo
                                      ,IdUsuario = @IdUsuario
                                  WHERE IdFilme = @IdFilme";

                            await conexao.ExecuteAsync(query, new
                            {
                                IdFilme = filme.IdFilme.ToString(),
                                Titulo = filme.Titulo,
                                Descricao = filme.Descricao,
                                Imagem = filme.Imagem,
                                Caminho = filme.Caminho,
                                Duracao = filme.Duracao,
                                DataRegistro = DateTime.Now,
                                Ativo = true,
                                IdUsuario = filme.IdUsuario
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
                    return new Notificacao(true, "Não foi possível editar o filme!", ex.Message);
                }
            }
        }

        public async Task<Notificacao> ExcluirFilme(string idFilme)
        {
            using (var conexao = new SqlConnection(_config))
            {
                try
                {
                    // Query para verificar a existem de filme vinculadas com alguma sessão
                    string queryVerificar = $@"SELECT IdFilme
                                               FROM tb_sessao_filme 
                                               WHERE IdFilme = '{idFilme}'";

                    string verificar = conexao.Query<string>(string.Format(queryVerificar)).SingleOrDefault();

                    if (string.IsNullOrEmpty(verificar))
                    {
                        // Retornar imagem e o caminho
                        string queryImagem = @$"SELECT Caminho, Imagem 
                                                FROM tb_filme 
                                                WHERE IdFilme = '{idFilme}'";

                        var verificarImagem = conexao.Query<Filme>(queryImagem).SingleOrDefault();

                        if (!string.IsNullOrEmpty(verificarImagem.Caminho))
                        {
                            // Deletar imagem do filme
                            excluirImagem(verificarImagem.Caminho, verificarImagem.Imagem);
                        }

                        // Deletar filme
                        string query = @$"DELETE FROM tb_filme WHERE IdFilme = '{idFilme}'";

                        await conexao.ExecuteAsync(string.Format(query));

                        return new Notificacao(false, "Filme deletada com sucesso!", "");
                    }
                    else
                    {
                        return new Notificacao(true, "O Filme não pode excluir pois existem sessão vinculadas a ele.", "");
                    }
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível excluir o filme", ex.Message);
                }
            }
        }

        private void excluirImagem(string caminho, string arquivo)
        {
            var caminhoCompleta = Path.Combine("C:\\Projetos\\dev\\.NET\\ProjetoCinema\\Web\\", caminho, arquivo);

            if (File.Exists(caminhoCompleta))
            {
                try
                {
                    File.Delete(caminhoCompleta);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        // Contador de filmes
        public async Task<int> ContadorFilme()
        {
            using (var conexao = new SqlConnection(_config))
            {
                string query = @$"SELECT COUNT(IdFilme) totalFilmes FROM tb_filme";

                return await conexao.QueryFirstAsync<int>(string.Format(query));
            }
        }
    }
}