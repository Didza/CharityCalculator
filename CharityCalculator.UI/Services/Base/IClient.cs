using System.Net.Http;

namespace CharityCalculator.UI.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
