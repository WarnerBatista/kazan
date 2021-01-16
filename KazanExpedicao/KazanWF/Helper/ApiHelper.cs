using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KazanWF.Helper
{
    public class ApiHelper
    {
        public static Uri Uri = new Uri("http://localhost:61899/");
        //static TokenVM tokenVM = new TokenVM();
        //static UsuarioModel Usuario = new UsuarioModel()
        //{
        //    Nome = "warner",
        //    Senha = "dev2020"
        //};

        //public async Task<bool> ObterToken()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = Uri;
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = await client.PostAsJsonAsync("api/Login", Usuario);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            tokenVM = await response.Content.ReadAsAsync<TokenVM>();
        //            tokenVM.Token = tokenVM.Token.Replace("\"", string.Empty);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                //if (tokenVM.Token == "" || DateTime.UtcNow >= tokenVM.DataExpiracaoToken)
                //    await ObterToken();
                client.BaseAddress = Uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer"/*, tokenVM.Token*/);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return json;
                }
            }
            return default(T);
        }

        public async Task<bool> Post(string url, Object model)
        {
            using (var client = new HttpClient())
            {
                //if (tokenVM.Token == "" || DateTime.UtcNow >= tokenVM.DataExpiracaoToken)
                //    await ObterToken();
                client.BaseAddress = Uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer"/*, tokenVM.Token*/);
                try
                {
                    var data = JsonConvert.SerializeObject(model);
                    using (var content = new StringContent(data, Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage response = client.PostAsync(url, content).Result;
                    }
                    return true;
                }
                catch (Exception)
                {

                }
                return false;
            }
        }

        //public async Task<bool> Put(string url, Object model)
        //{
        //    return false;
        //}

        //public async Task<bool> Delete(string url)
        //{
        //    return false;
        //}

    }
}