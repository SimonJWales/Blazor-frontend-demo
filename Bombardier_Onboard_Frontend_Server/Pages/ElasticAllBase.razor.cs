using Microsoft.AspNetCore.Components;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bombardier_Onboard_Frontend_Server.Data;

namespace Bombardier_Onboard_Frontend_Server.Pages
{
    public class ElasticAllBase : ComponentBase
    {
        public IEnumerable<TrainLog.TrainLog> SearchAll { get; set; }
        public string ConnectionError;
        private readonly Onboard_Elastic_Connection OnboardEC = new Onboard_Elastic_Connection();

        protected override Task OnInitializedAsync()
        {
            try
            {
                ElasticClient ESClient = new ElasticClient(OnboardEC.ElasticConnectionSettings());
                var searchResponse = ESClient.Search<TrainLog.TrainLog>(s => s
                    .MatchAll()
                    .Size(1000)
                );
                SearchAll = searchResponse.Documents;
                if (!searchResponse.IsValid) ConnectionError = "Invalid response from Elastic Search!";
            }
            catch (Exception ex)
            {
                //if (Env.IsDevelopment())
                //{
                    ConnectionError = $"EXCEPTION:\n{ex.Message} {ex.StackTrace}";
                //}
                //else
                //{
                //   ConnectionError = "Exception encountered when connecting to Elastic Search!";
                //}
            }
            return base.OnInitializedAsync();
        }
    }
}
