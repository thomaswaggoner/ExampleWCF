using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWaggonerExampleService
{

    public class MemoryDataIntermediary : IDataLayer
    {
        private static List<string> strings = new List<string>();

        public string GetLastString()
        {
            return strings.Last<string>();
        }

        public IEnumerable<string> GetAllStrings()
        {
            return strings;
        }

        public void SetString(string input)
        {
            strings.Add(input);
        }

        public void UpdateString(string oldVal, string newVal)
        {
            for(int i = 0; i <strings.Count; i++)
            {
                if(strings[i] == oldVal)
                {
                    strings[i] = newVal;
                }
            }
        }

        public void LogError(Exception ex)
        {
            //Here we would normally write it to a db log or a flat file
        }
    }

    //Not used because I ran out of time
    public class SQLDataIntermediary : IDataLayer
    {
        public string GetLastString()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetAllStrings()
        {
            throw new NotImplementedException();
        }
        public void SetString(string input)
        {
            throw new NotImplementedException();
        }
        public void UpdateString(string oldVal, string newVal)
        {
            throw new NotImplementedException();
        }
        public void LogError(Exception ex)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDataLayer
    {
        string GetLastString();
        IEnumerable<string> GetAllStrings();
        void SetString(string input);
        void UpdateString(string oldVal, string newVal);
        void LogError(Exception ex);
    }

    public class MemoryDataFactory
    {
        public MemoryDataIntermediary CreateMemoryIntermediary()
        { return new MemoryDataIntermediary(); }
    }

    public class SQLDataFactory
    {
        public SQLDataIntermediary CreateSQLIntermediary()
        { return new SQLDataIntermediary();  }
    }
}