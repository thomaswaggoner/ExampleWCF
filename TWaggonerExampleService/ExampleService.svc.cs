using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TWaggonerExampleService
{
    public class ExampleService : IExampleService
    {
        private IDataLayer dataLayer;

        public ExampleService()
        {
            try
            {
                MemoryDataFactory mdf = new MemoryDataFactory();
                SQLDataFactory sdf = new SQLDataFactory();
                string dataStore = System.Web.Configuration.WebConfigurationManager.AppSettings["DataStore"];

                //I want this to be the default
                if (String.IsNullOrWhiteSpace(dataStore) || dataStore.ToLower() =="memory")
                {
                    dataLayer = mdf.CreateMemoryIntermediary();
                }
                else if (dataStore.ToLower() == "sql")
                {
                    dataLayer = sdf.CreateSQLIntermediary();
                } else
                {
                    throw new Exception("Unrecognized DataStore");
                }

            } catch(Exception ex)
            {
                //dataLayer failed to initialize, exit the application
                Environment.Exit(0);
            }

        }

        public void InsertString(string input)
        {
            try
            {
                dataLayer.SetString(input);
            } catch(Exception ex)
            {
                dataLayer.LogError(ex);
            }
        }

        public string GetLastString()
        {
            string lastString = null;
            try
            {
                lastString = dataLayer.GetLastString();
            }
            catch (Exception ex)
            {
                dataLayer.LogError(ex);
            }
            return lastString;
        }

        public void UpdateString(string existingValue, string newValue)
        {
            try {
                dataLayer.UpdateString(existingValue, newValue);
            }
            catch (Exception ex)
            {
                dataLayer.LogError(ex);
            }
        }

        public IEnumerable<string> GetAllStrings()
        {
            List<string> allStrings = new List<string>();
            try
            {
                allStrings.AddRange(dataLayer.GetAllStrings().ToList());
            } catch(Exception ex)
            {
                dataLayer.LogError(ex);
            }
            return allStrings;
        }
        
    }
}
