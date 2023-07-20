using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ScsTextFileGenerator.Services;
using ScsTextFileGenerator.Utilities;

namespace ScsTextFileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var headerRecord = $"Merchant Log.Date Created,Company.Company Legal Name,Merchant Log.Merchant Log Unique Id,Merchant.Merchant Name,Merchant Log.Merchant Log Status,Merchant Log.Merchant Log Amount,Merchant Log.Invoice Count,Merchant.Email Addresses Primary,Count of Records";
            var numberOfRecords = 120000;
            var filePath = @"c:\filedata";
            var fileName = "seed2.csv";

            var fullFilePath = Path.Combine(filePath, fileName);

            var dataService = new DataService();

            var recordData = dataService.GenerateData(numberOfRecords, headerRecord);

            using (var tw = new StreamWriter(@"c:\filedata\seedlargesize.csv"))
            {
                foreach (string record in recordData)
                {
                    tw.WriteLine(record);
                }
            }
        }        
    }
}
