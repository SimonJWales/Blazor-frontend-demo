using Elasticsearch.Net;
using Elasticsearch.Net.Aws;
using Nest;
using System;

namespace Bombardier_Onboard_Frontend_Server.Data
{
    public class Onboard_Elastic_Connection
    {
        public ConnectionSettings ElasticConnectionSettings()
        {
            AwsHttpConnection httpConnection = new AwsHttpConnection("eu-north-1");
            SingleNodeConnectionPool esDomain = new SingleNodeConnectionPool(new Uri("https://search-onboard-dev-3mkkukg6qax5vsv4o3o3k2bh7q.eu-north-1.es.amazonaws.com"));
            ConnectionSettings settings = new ConnectionSettings(esDomain, httpConnection)
                .DisableDirectStreaming()
                .DefaultIndex("onboard-dev");
            return settings;

            //AwsHttpConnection httpConnection = new AwsHttpConnection(Environment.GetEnvironmentVariable("AWS_REGION"));
            //SingleNodeConnectionPool esDomain = new SingleNodeConnectionPool(new Uri(Environment.GetEnvironmentVariable("ES_ENDPOINT")));
            //ConnectionSettings settings = new ConnectionSettings(esDomain, httpConnection)
            //    .DisableDirectStreaming()
            //    .DefaultIndex(Environment.GetEnvironmentVariable("ES_DOMAIN"));
            //return settings;
        }
    }
}
