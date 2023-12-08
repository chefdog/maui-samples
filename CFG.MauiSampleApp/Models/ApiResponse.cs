namespace CFG.MauiSampleApp.Models
{
    public class ApiResponse<TModel>
    {
        public TModel? Data { get; set; }

        public bool DidError { get; set; }

        public string? Error { get; set; }
    }
}
