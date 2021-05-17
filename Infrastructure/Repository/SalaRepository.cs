using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.Domain.Model;
using System;
using System.Threading.Tasks;

namespace ProjetoCinema.Infrastructure
{
    public class SalaRepository : ISalaRepository
    {
        private readonly string _config;

        public SalaRepository(IConfiguration config)
        {
            _config = config.GetConnectionString("DefaultConnection");
        }

        public async Task<DadosSala> ListarSala()
        {
            using (SqlConnection conexao = new SqlConnection(_config))
            {
                try
                {
                    string query = @"SELECT 
                                         IdSala
                                        ,Nome
                                        ,QuantidadeAssento
                                        ,DataRegistro
                                        ,Ativo
                                        ,IdUsuario
                                    FROM tb_sala 
                                    ORDER BY Nome ASC";

                    return new DadosSala(false, "Listagem realizada com sucesso", await conexao.QueryAsync<Sala>(string.Format(query)));
                }
                catch (Exception ex)
                {
                    return new DadosSala(true, "Erro ao listar" + ex, null);
                }
            }
        }
    }
}