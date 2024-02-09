using Newtonsoft.Json;

namespace Zadanie0902KB;

public partial class MainPage : ContentPage
{
	class Daty
	{
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
	}

	public MainPage()
	{
		InitializeComponent();
	}

	private void btnJson(object sender, EventArgs e)
	{
		Daty data = new Daty
		{
			StartDate = dateStart.Date.ToShortDateString(),
			EndDate = dateEnd.Date.ToShortDateString(),
			StartTime = timeStart.Time.ToString(),
			EndTime = timeEnd.Time.ToString()
		};
		string dane = JsonConvert.SerializeObject(data, Formatting.Indented);
		string path = Path.Combine(FileSystem.Current.AppDataDirectory, "data.json");
        File.Delete(path);
        File.WriteAllText(path, dane);
		jsonData.Text = File.ReadAllText(path);
    }
}

