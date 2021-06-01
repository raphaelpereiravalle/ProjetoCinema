using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.Domain.Model;
using System;
using System.IO;
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
                                   WHERE IdFilme='{idFilme}'";

                    return await conexao.QueryFirstAsync<Filme>(string.Format(query));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Notificacao> BuscarFilmePorTitulo(string titulo)
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    string queryVerificar = $@"SELECT IdFilme
                                               FROM tb_filme 
                                               WHERE Titulo = '{titulo}'";

                    string verificar = await conexao.QueryFirstOrDefaultAsync<string>(string.Format(queryVerificar));

                    if (string.IsNullOrEmpty(verificar))
                    {
                        return new Notificacao(false, null, null);
                    }

                    return new Notificacao(true, "Filme já cadastrado!", null);
                }
            }
            catch (Exception ex)
            {
                return new Notificacao(true, "Não foi possível localizar o titulo!", ex.Message);
            }
        }

        public async Task<Notificacao> BuscarFilmeSessaoId(string idFilme)
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    string queryVerificar = $@"SELECT IdFilme
                                               FROM tb_sessao_filme 
                                               WHERE IdFilme = '{idFilme}'";

                    string verificar = await conexao.QueryFirstOrDefaultAsync<string>(string.Format(queryVerificar));

                    if (string.IsNullOrEmpty(verificar))
                    {
                        return new Notificacao(false, null, null);
                    }

                    return new Notificacao(true, "O Filme não pode se excluir pois existem sessão vinculadas a ele!", null);
                }
            }
            catch (Exception ex)
            {
                return new Notificacao(true, "Não foi possível localizar o titulo!", ex.Message);
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
                    // Deletar filme
                    string query = @$"DELETE FROM tb_filme WHERE IdFilme = '{idFilme}'";

                    await conexao.ExecuteAsync(string.Format(query));

                    return new Notificacao(false, "Filme deletada com sucesso!", "");
                }
                catch (Exception ex)
                {
                    return new Notificacao(true, "Não foi possível excluir o filme", ex.Message);
                }
            }
        }

        public void ExcluirImagem(string caminho, string arquivo)
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
                string query = @"SELECT COUNT(IdFilme) totalFilmes 
                                 FROM tb_filme";

                return await conexao.QueryFirstAsync<int>(string.Format(query));
            }
        }

        // Busca o caminha da imagem
        public async Task<Filme> BuscarImagemCaminho(string idFilme)
        {
            try
            {
                using (var conexao = new SqlConnection(_config))
                {
                    // Retornar imagem e o caminho
                    string queryImagem = $@"SELECT Caminho, Imagem
                                            FROM tb_filme
                                            WHERE IdFilme = '{idFilme}'";

                    return await conexao.QueryFirstOrDefaultAsync<Filme>(queryImagem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}