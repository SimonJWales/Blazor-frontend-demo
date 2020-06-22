using Bombardier_Onboard_Frontend_Server.Data;
using Microsoft.AspNetCore.Components;

namespace Bombardier_Onboard_Frontend_Server.Components
{
    public class SearchDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }
        public SingleSearch SingleSearchItem = new SingleSearch();
        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            //StateHasChanged();
        }
        public void Close()
        {
            ShowDialog = false;
            //StateHasChanged();
        }
        public void ResetDialog()
        {
            SingleSearchItem = new SingleSearch();
        }
        public async void HandleValidSubmit()
        {
            //try
            //{
            //    ElasticClient ESClient = new ElasticClient(OnboardEC.ElasticConnectionSettings());
            //    var searchResponse = ESClient.Search<TrainLog.TrainLog>(s => s
            //        .Size(1000)
            //        .Query(q => q
            //        .MultiMatch(c => c
            //        .Query(SingleSearchItem.SingleInput)
            //    )));
            //    SearchAll = searchResponse.Documents;

            //    foreach (var s in SearchAll)
            //    {
            //        if (s.BDS_HEAD == null)
            //        {
            //            ConnectionError += "HEAD: " + s.Id + ", ";
            //        }
            //        if (s.BDS_TXT == null)
            //        {
            //            ConnectionError += "TXT: " + s.Id + ", ";
            //        }
            //    }

            //    RecordsFound = searchResponse.Hits.Count;
            //    if (!searchResponse.IsValid) ConnectionError = "Invalid response from Elastic Search!";
            //}
            //catch (Exception ex)
            //{
            //    //if (Env.IsDevelopment())
            //    //{
            //    ConnectionError = $"EXCEPTION:\n{ex.Message} {ex.StackTrace}";
            //    //}
            //    //else
            //    //{
            //    //   ConnectionError = "Exception encountered when connecting to Elastic Search!";
            //    //}
            //}
            // StateHasChanged();
        }
    }
}
