using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;


namespace Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
        [OperationContract]
        double Sub(double a, double b);
        [OperationContract]
        double Multi(double a, double b);
        [OperationContract]
        double Devi(double a, double b);
    }
    
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            Thread.Sleep(16000);
            return a + b;
        }
        public double Sub(double a, double b)
        {
            Thread.Sleep(1600);
            return a - b;
        }

        public double Multi(double a, double b)
        {
            Thread.Sleep(1600);
            return a * b;
        }

        public double Devi(double a, double b)
        {
            return a / b;
        }

    }
 
}
