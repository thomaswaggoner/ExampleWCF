using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TWaggonerExampleService
{
    [ServiceContract]
    public interface IExampleService
    {

        [OperationContract]
        void InsertString(string value);

        [OperationContract]
        void UpdateString(string existingValue, string newValue);

        [OperationContract]
        string GetLastString();

        [OperationContract]
        IEnumerable<string> GetAllStrings();
    }
}
