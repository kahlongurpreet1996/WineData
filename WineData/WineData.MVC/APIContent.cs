using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HospitalDoctoerRecord.MVC
{
    public static class APIContent
    {
        public static HttpClient Client = new HttpClient();
        static APIContent()
        {
            Client.BaseAddress = new Uri("http://localhost:64667/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}