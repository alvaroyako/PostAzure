using Newtonsoft.Json;
using PostAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PostAzure.Services
{
    public class ServiceMail
    {
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceMail()
        {
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task SendMail(Correo correo)
        {
            string urlMail = "https://prod-130.westeurope.logic.azure.com:443/workflows/fcf404c2a6c24fafbb06c90852a81d21/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=K6aUEEa_hMtMwUlKt1umZXlVTzhCykjqzNvEGDtgJeU";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                
                string json = JsonConvert.SerializeObject(correo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlMail, content);

            }
        }
    }
}
