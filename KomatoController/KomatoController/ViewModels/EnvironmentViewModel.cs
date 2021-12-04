using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using KomatoController.Models;
using KomatoController.Services;
using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KomatoController.ViewModels
{
    public class EnvironmentViewModel : BaseViewModel
    {
        public Chart tempChart;
        public Chart humidityChart;
        public Chart lightChart;
        public Command LoadRecordsCommand;
        public List<EnvRecord> records;
        readonly List<ChartEntry> tempEntry = new List<ChartEntry>();
        readonly List<ChartEntry> humidityEntry = new List<ChartEntry>();
        readonly List<ChartEntry> lightEntry = new List<ChartEntry>();
        readonly CosmosDBService service;



        public EnvironmentViewModel()
        {
            
            Title = "Environment";
            service = new CosmosDBService();
            //Task.WaitAny(service.GetRecordsAsync());
            //service.GetRecordsAsync();

            Task.Run(service.GetRecordsAsync().Wait);

            //records = service.GetRecordsAsync().Result;

            Debug.WriteLine("----------Chart Initialization " + service.Records.Count.ToString() + "----------------------!");

            foreach (EnvRecord item in service.Records)
            {
                //Pouze 2 dny mínus
                if (item.Date > DateTime.Now.AddDays(-2))
                {

                    string t = item.Date.ToString("HH") + ":" + item.Date.ToString("mm") + " " + item.Date.ToString("dd") + "." + item.Date.ToString("MM") + " ";
                    var fn = item.TempSensor.Count;
                    float tem = item.TempSensor[0].Temp;
                    float hum = item.TempSensor[0].Humidity;
                    tempEntry.Add(new ChartEntry(tem) { Label = t, ValueLabel = tem.ToString() + "°C", Color = SKColor.Parse("#77d065") });
                    humidityEntry.Add(new ChartEntry(hum) { Label = t, ValueLabel = hum.ToString() + "%", Color = SKColor.Parse("#77d065") });

                    float x;
                    string state;
                    if (item.Light)
                    {
                        x = 1;
                        state = "zapnuté";
                    }
                    else
                    {
                        x = 0;
                        state = "vypnuté";
                    }
                    lightEntry.Add(new ChartEntry(x) { Label = t, ValueLabel = state, Color = SKColor.Parse("#FF1943") });
                }
            }

            //Inicializing Charts
            tempChart = new LineChart() { Entries = tempEntry, LabelOrientation = Orientation.Horizontal };
            humidityChart = new LineChart() { Entries = humidityEntry, LabelOrientation = Orientation.Horizontal };
            lightChart = new LineChart() { Entries = lightEntry, LabelOrientation = Orientation.Horizontal, LineMode = LineMode.Straight };

        }      
    }
}