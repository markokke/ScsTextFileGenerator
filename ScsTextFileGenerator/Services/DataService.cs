using ScsTextFileGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ScsTextFileGenerator.Services
{
    public class DataService
    {
        public enum EnumType1
        {
            [Description("Closed")]
            Closed = 1,
            [Description("Reconciled")]
            Reconciled = 2,
            [Description("Expired")]
            Expired = 3,
            [Description("Open")]
            Open = 4,
            [Description("Test")]
            Test = 5
        }

        public IList<string> GenerateData(int numberOfRecords, string headerRecord)
        {
            var recordData = new List<string>();

            recordData.Add(headerRecord);

            for (int idx = 0; idx < numberOfRecords; idx++)
            {
                var dateCreated = DateTime.Now.ToShortDateString();
                var companyLegalName = RandomGenerators.GenerateRandomString(18, 65, 90);
                var merchantLogId = RandomGenerators.GenerateRandomString(18, 65, 90);
                var merchantName = RandomGenerators.GenerateRandomString(RandomGenerators.GenerateRandomInteger(5, 15), 65, 90);
                var merchantLogStatus = GetEnumDescription((EnumType1)RandomGenerators.GenerateRandomInteger(1, 4));
                var logAmount = string.Concat(RandomGenerators.GenerateRandomInteger(0, 1000), ".", RandomGenerators.GenerateRandomInteger(0, 99).ToString("00"));
                var invoiceCount = RandomGenerators.GenerateRandomInteger(1, 100);
                var emailAddress = string.Concat(RandomGenerators.GenerateRandomString(RandomGenerators.GenerateRandomInteger(5, 15), 97, 122), "@", RandomGenerators.GenerateRandomString(RandomGenerators.GenerateRandomInteger(5, 15), 97, 122), ".com");
                var countOfRecords = RandomGenerators.GenerateRandomInteger(invoiceCount, invoiceCount + 200);

                var record = $"{dateCreated}," +  // Date Created
                             $"{companyLegalName}," + // Company Legal Name
                             $"{merchantLogId}," + // Merchant Log Id
                             $"{merchantName}," + // Merchant Name
                             $"{merchantLogStatus}," + // Log Status
                             $"{logAmount}," +  // Log Amount
                             $"{invoiceCount}," +  // Invoice Count
                             $"{emailAddress}," +  // Email Address 
                             $"{countOfRecords}";  // Count of Records

                recordData.Add(record);
            }

            return recordData;
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
