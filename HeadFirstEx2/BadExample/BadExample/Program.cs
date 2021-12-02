using System;

namespace BadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            weatherData.setMeasurements(80, 65, 30.4f);
            weatherData.setMeasurements(90, 80, 60.4f);
            weatherData.setMeasurements(20, 45, 20.4f);
        }
    }

    public class WeatherData
    {
        private float temperature;
        private float humidity;
        private float pressure;

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay();

        public void measurementsChanged()
        {
            currentDisplay.update(temperature,humidity,pressure);
            statisticsDisplay.update(temperature, humidity, pressure);
            statisticsDisplay.display();
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }


    }

    public class CurrentConditionsDisplay
    {

        private float temperature;
        private float humidity;
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

    public class StatisticsDisplay
    {
       
        private float maxTemp = 0.0f;
        private float minTemp = 200;//set intial high so that minimum 
                                    //is set first invokation
        private float temperatureSum = 0.0f;
        private int numReadings = 0;       
        
        public int NumberOfReadings
        {
            get
            {
                return numReadings;
            }
        }
        
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
           
        }
        
        public void display()
        {
            Console.WriteLine("Avg /Max/Min temperature = " + RoundFloatToString(temperatureSum / numReadings) +
                "F/" + maxTemp + "F/" + minTemp + "F");
        }
       
        public static string RoundFloatToString(float floatToRound)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            return floatToRound.ToString("F", cultureInfo);
        }
        

    }


}
