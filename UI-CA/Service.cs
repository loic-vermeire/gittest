using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using Newtonsoft.Json;
using SC.BL.Domain;

namespace SC.UI.CA
{
    internal class Service
    {
        private const string baseUri = "https://localhost.fiddler:5001/api/";

        private HttpClient GetNewHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (request, certificate, chain, SslPolicyErrors ) => true
            };
            
            return new HttpClient(httpClientHandler);
        }
        
        public IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber)
        {
            IEnumerable<TicketResponse> responses = null;
            using (HttpClient http = GetNewHttpClient())
            {
                string uri = baseUri + "TicketResponses?ticketNumber=" + ticketNumber;
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
                
                request.Headers.Add("Accept","application/json");
    
                HttpResponseMessage response = http.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    responses = JsonConvert.DeserializeObject<IEnumerable<TicketResponse>>(responseContent);
                } else 
                    throw new Exception(response.StatusCode + " " + response.ReasonPhrase);
            }

            return responses;
        }

        public TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse)
        {
            TicketResponse newResponse = null;

            using (HttpClient http = GetNewHttpClient())
            {
                string uri = baseUri + "TicketResponses";
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);
                httpRequest.Headers.Add("Accept","application/json");
                object httpData = new
                    {TicketNumber = ticketNumber, ResponseText = response, IsClientResponse = isClientResponse};
                string dataAsJsonString = JsonConvert.SerializeObject(httpData);
                httpRequest.Content = new StringContent(dataAsJsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = http.SendAsync(httpRequest).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseContentAsString = httpResponse.Content.ReadAsStringAsync().Result;

                    newResponse = JsonConvert.DeserializeObject<TicketResponse>(responseContentAsString);
                } else 
                    throw new Exception(httpResponse.StatusCode + " " + httpResponse.ReasonPhrase);

                return newResponse;
            }
        }
    }
}