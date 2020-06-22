using Microsoft.AspNetCore.Components;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bombardier_Onboard_Frontend_Server.Data;
using Bombardier_Onboard_Frontend_Server.Components;

namespace Bombardier_Onboard_Frontend_Server.Pages
{
    public class ElasticFindBase : ComponentBase
    {
        public IEnumerable<TrainLog.TrainLog> SearchAll { get; set; }
        public string ConnectionError;
        readonly Onboard_Elastic_Connection OnboardEC = new Onboard_Elastic_Connection();
        public SingleSearch SingleSearchItem = new SingleSearch();
        protected SearchDialog SearchDialog { get; set; }
        public object DisplaySearchResults { get; private set; }

        public int RecordsFound;

        protected override Task OnInitializedAsync()
        {
            
            return base.OnInitializedAsync();
        }

        protected void InvokeSearchDialog()
        {
            SearchDialog.Show();
        }


        public void HandleValidSubmit()
        {
            try
            {
                ElasticClient ESClient = new ElasticClient(OnboardEC.ElasticConnectionSettings());
                var searchResponse = ESClient.Search<TrainLog.TrainLog>(s => s
                    .Size(1000)
                    .Query(q => q
                    .MultiMatch(c => c
                    .Query(SingleSearchItem.SingleInput)
                )));
                SearchAll = searchResponse.Documents;
                RecordsFound = searchResponse.Hits.Count;
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
        }
    }
}
