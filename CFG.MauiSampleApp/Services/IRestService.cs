using CFG.MauiSampleApp.Models;

namespace CFG.MauiSampleApp.Services
{
    public interface IRestService
    {
        Task<List<Country>> RefreshDataAsync();

        Task SaveTodoItemAsync(Country item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
