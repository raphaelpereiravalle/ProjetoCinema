using Newtonsoft.Json;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Domain.Token.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjetoCinema.Web.Client
{
    public class ClientService : HttpClient
    {
        public ClientService()
        {
        }

        public async Task<Notificacao> PostAsync<T>(string url, string token, T item)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //Faz a consulta
            HttpResponseMessage response = client.PostAsync(url, byteContent).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                Notificacao resultado = JsonConvert.DeserializeObject<Notificacao>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<Notificacao> PutAsync<T>(string url, string token, T item)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //Faz a consulta
            HttpResponseMessage response = client.PutAsync(url, byteContent).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                Notificacao resultado = JsonConvert.DeserializeObject<Notificacao>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<T> GetAsync<T>(string url, string token, string item)
        {
            var client = new HttpClient();
            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //Faz a consulta
            HttpResponseMessage response = client.GetAsync(url + item).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                T resultado = JsonConvert.DeserializeObject<T>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<T> DeleteAsync<T>(string url, string token, string item)
        {
            var client = new HttpClient();
            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //Faz a consulta
            HttpResponseMessage response = client.DeleteAsync(url + item).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                T resultado = JsonConvert.DeserializeObject<T>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<T> GetModelAsync<T>(string url, string token, object item)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //Faz a consulta
            HttpResponseMessage response = client.PostAsync(url, byteContent).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                T resultado = JsonConvert.DeserializeObject<T>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<Token> PostAsyncLogin<T>(string url, T item)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Limpa os Headers
            client.DefaultRequestHeaders.Accept.Clear();

            //Faz a consulta
            HttpResponseMessage response = client.PostAsync(url, byteContent).Result;

            //Pega o conteudo da consulta
            string conteudo = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                Token resultado = JsonConvert.DeserializeObject<Token>(conteudo);
                return resultado;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
