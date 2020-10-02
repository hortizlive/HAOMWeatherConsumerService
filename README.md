# HAOMCityWeatherLogger
Windows Service that queries the City Weather to Open Weather Maps API and registers it to CSV 

This project was developed using the Open Weather Map API to get the current weather conditions of the desired city, this was developed to be executed as a windows service
it uses the IHosteService and a worker Service to be executed.
it is a visual studio 2019 Solution. you can run it with the Visual Studio 2019 Community edition.

##Configuration

In the configuration file appsettings.json you can set:

     1.- the CityID (to find the CityID i've included the **city.list.json** , this file is not necesary to build the project and cant be excluded), current configuration is for Dallas, TX, USA
     2.- Polling Period, current config is to poll every 5 minutes.
     3.- The destination Folder, actual configuration is **C:\Temp** you can change it and must ensure the user running the service has write access to the folder or the application will be failing every time it tries to create or write the CSV file.
     4.- Units to Report, actual configuration is **Imperial** (Farenheit)


The included APIKey is invalid, so you need to get one APIKey in https://openweathermap.org/, a free susbcription will do the job for testing purposes, you'd need to replace value of the  "API_Key":"PUT THE KEY HERE", in the appsettings.json file. with the provided value,(**new account api keys in OpenWeatherMap take up to 2 hours to get activated**)

To install the project as a service:

1.- Publish the solution (build the excutable in release mode)

2.- Create the Windows Service with the following command, **Replace the Path with the path were the .exe was published to.**

    `sc create “HAOM WeatherConsumer Service” binPath=c:\sampleservice\WSvcHAOMWeatherConsumer.exe`
    
3.- Then Start the Windows Service with the folowwing command:

  `SC Start “HAOM WeatherConsumer Service”`
  
4.- when the service start you can see the messages in the windows event viewer.




