using System;
using System.Collections.Generic;

namespace HeadFirstEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            
            weatherData.setMeasurements(80, 65, 30.4f);
            weatherData.setMeasurements(90, 80, 60.4f);
            weatherData.setMeasurements(20, 45, 20.4f);
            statisticsDisplay.display();
            

        }
    }

    public interface ISubject
    {
        public void registerObserver(IObserver o);
        public void removeObserver(IObserver o);
        public void notifyObservers();


    }

    public interface IObserver
    {
        public void update(float temp, float humidity, float pressure);
    }

    public interface IDisplayElement
    {
        public void display();
    }

    public class WeatherData: ISubject
    {
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if(i>= 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void notifyObservers()
        {
            for(int i = 0; i < observers.Count; i++)
            {
                IObserver observer = (IObserver)observers[i];
                observer.update(temperature, humidity, pressure);
            }
        }

        public void measurementsChanged()
        {
            notifyObservers();
        }

        public void setMeasurements(float temperature,float humidity,float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
        }
    }

   

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        #region Members
        private float maxTemp = 0.0f;
        private float minTemp = 200;//set intial high so that minimum 
                                    //is set first invokation
        private float temperatureSum = 0.0f;
        private int numReadings = 0;
        private ISubject weatherData;
        #endregion//Members

        #region NumberOfReadings Property
        public int NumberOfReadings
        {
            get
            {
                return numReadings;
            }
        }
        #endregion//NumberOfReadings Property

        #region Constructor
        public StatisticsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        #endregion//Constructor

        #region IObserver Members

        public void update(float temperature, float humidity, float pressure)
        {
            temperatureSum += temperature;
            numReadings++;

            if (temperature > maxTemp)
            {
                maxTemp = temperature;
            }

            if (temperature < minTemp)
            {
                minTemp = temperature;
            }
            //display();
        }

        #endregion

        #region IDisplayElement Members

        public void display()
        {
            Console.WriteLine("Avg /Max/Min temperature = " + RoundFloatToString(temperatureSum / numReadings) +
                "F/" + maxTemp + "F/" + minTemp + "F");
        }

        #endregion

        #region RoundFloatToString
        public static string RoundFloatToString(float floatToRound)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            return floatToRound.ToString("F", cultureInfo);
        }
        #endregion//RoundFloatToString

    }

}
