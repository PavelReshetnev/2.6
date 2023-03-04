using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace ConsoleApp2
{
    public class App
    {
        static string oth;
        public static void wethapp()
        {
            Console.WriteLine("Введите город(на английском и с заглавной буквы)\n");
            string city = Console.ReadLine();
            oth += city;
            Console.WriteLine("Куда вы хотите вывести данные? (txt/консоль)");
            string output = Console.ReadLine();
            if (output == "txt") {
                txt();
            } else if(output == "консоль"){
                consl();
            }
           
        }

        public static void txt()
        {
            string path = @"C:\Users\gr623_repal\Documents\Weather.txt";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={oth}&units=metric&lang=ru&appid=6eb98cc1873223b20f85cc4d07b8577e";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            string streamresponse;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                streamresponse = streamReader.ReadToEnd();
            }
            Response weatherresponse = JsonConvert.DeserializeObject<Response>(streamresponse);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("-----------------------------------------------------------------------------------------");
                writer.WriteLine($"Текущая температура в {weatherresponse.name} {weatherresponse.main.temp} °C, {weatherresponse.weather[0].description}\nОщущается как {weatherresponse.main.feels_Like} °C\n" +
                                 $"Максимальная температура: {weatherresponse.main.temp_max}°C\n" +
                                 $"Минимальная температура: {weatherresponse.main.temp_min}°C");
                writer.WriteLine("-----------------------------------------------------------------------------------------");
                writer.Close();
                nextornot();
            }
        }

        public static void nextornot()
        {
            Console.WriteLine("Хотите получить более подробную информацию? (y/n)");
            string choose = Console.ReadLine();
            if (choose == "y") {
                OtherTxt();
            } 
        }
        public static void OtherTxt()
        {
            string path = @"C:\Users\gr623_repal\Documents\Weather.txt";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={oth}&units=metric&lang=ru&appid=6eb98cc1873223b20f85cc4d07b8577e";
            WebRequest requestWind = WebRequest.Create(url);
            WebResponse responseWind = requestWind.GetResponse();
            string streamresponseWind;
            using (StreamReader otherReader = new StreamReader(responseWind.GetResponseStream())) {
                streamresponseWind = otherReader.ReadToEnd();
            }
            Response Other = JsonConvert.DeserializeObject<Response>(streamresponseWind);
            using (StreamWriter writer = new StreamWriter(path, true)) {
                writer.WriteLine("-----------------------------------------------------------------------------------------");
                writer.WriteLine($"Ветер {Other.wind.speed} м/с");
                if (Other.wind.speed>= 5.00)
                {
                    writer.WriteLine("Из-за сильного ветра кажется, что холоднее");
                }
                writer.WriteLine($"Порывы ветра = {Other.wind.gust} м/с\nНаправление ветра = {Other.wind.deg}°\nУровень моря = {Other.main.sea_level} hPa\n" +
                                 $"Влажность = {Other.main.humidity} %\nАтмосф.Давление = {Other.main.pressure} hPa\nДавление на земле = {Other.main.grnd_level} hPa");
                writer.WriteLine("-----------------------------------------------------------------------------------------\n");
            }
        }
        public static void consl() {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={oth}&units=metric&lang=ru&appid=6eb98cc1873223b20f85cc4d07b8577e";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            string streamresponse;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream())) {
                streamresponse = streamReader.ReadToEnd();
            }
                     
            Response weatherresponse = JsonConvert.DeserializeObject<Response>(streamresponse);
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"Текущая температура в {weatherresponse.name} {weatherresponse.main.temp} °C, {weatherresponse.weather[0].description}\nОщущается как {weatherresponse.main.feels_Like} °C\n" +
                              $"Максимальная температура: {weatherresponse.main.temp_max}°C\n" +
                              $"Минимальная температура: {weatherresponse.main.temp_min}°C");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Хотите получить более подробную информацию? (y/n)");
            string choose = Console.ReadLine();
            if (choose == "y") {
                OtherConsl();
            }else if(choose == "n") {
                Console.WriteLine();
            }
        }
        public static void OtherConsl()
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={oth}&units=metric&lang=ru&appid=6eb98cc1873223b20f85cc4d07b8577e";
            WebRequest requestWind = WebRequest.Create(url);
            WebResponse responseWind = requestWind.GetResponse();
            string streamresponseWind;
            using (StreamReader otherReader = new StreamReader(responseWind.GetResponseStream()))
            {
                streamresponseWind = otherReader.ReadToEnd();
            }
                        
            Response Other = JsonConvert.DeserializeObject<Response>(streamresponseWind);
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine($"Ветер {Other.wind.speed} м/с");
            if (Other.wind.speed>= 5.00)
            {
                Console.WriteLine("Из-за сильного ветра кажется, что холоднее");
                
            }
            Console.WriteLine($"Порывы ветра = {Other.wind.gust} м/с\nНаправление ветра = {Other.wind.deg}°\nУровень моря = {Other.main.sea_level} hPa\n" +
                              $"Влажность = {Other.main.humidity} %\nАтмосф.Давление = {Other.main.pressure} hPa\nДавление на земле = {Other.main.grnd_level} hPa");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        
    }
}