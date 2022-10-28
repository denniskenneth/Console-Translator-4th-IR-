using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Console_Translator
{
     class ApiTest
    {
        private string txt;
        private string srcLang;
        private string convLang;
        private string endpoint;
        static readonly HttpClient client = new HttpClient();

        

        public ApiTest(string txt)
        {
            this.txt = txt;
            this.srcLang = "English";
            this.convLang = "French";
            this.endpoint = "https://text-translation-fairseq-1.ai-sandbox.4th-ir.io/api/v1/sentence"+ "?source_lang="+this.srcLang+ "&conversion_lang="+this.convLang;
        }

        public async Task<string> ChangeText()
        {
            var values = new { sentence = txt };
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, values);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Success");
                var responseString = await response.Content.ReadFromJsonAsync<SuccessResponse>();
                string result = "end!";

                //Console.WriteLine(responseString.conversion_text);
                return result = responseString.conversion_text;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
               // Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }

        }

       
    }

    public class SuccessResponse
    {
        public string original_text { get; set; }
        public string conversion_text { get; set; }
    }
}
