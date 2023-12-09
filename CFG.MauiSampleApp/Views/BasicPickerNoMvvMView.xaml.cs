using CFG.MauiSampleApp.Services;

namespace CFG.MauiSampleApp.Views;

public partial class BasicPickerNoMvvMView : ContentPage
{
	
    private ICountryService _countryService;

    public BasicPickerNoMvvMView(ICountryService countryService)
    {
        _countryService = countryService;
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var data = await _countryService.GetCountries();
        CountryPicker.ItemsSource = await data.ToListAsync();
    }
}