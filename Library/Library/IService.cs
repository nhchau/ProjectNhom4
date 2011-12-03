using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Library
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool CheckLoginAD(string UserName, string PassWord);
        [OperationContract]
        bool CheckLoginGV(string UserName, string PassWord);
        [OperationContract]
        bool CheckLoginSV(string UserName, string PassWord);
        [OperationContract]
        string GetAuthors();        
    }        
}
