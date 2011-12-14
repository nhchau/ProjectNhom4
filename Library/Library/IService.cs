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
        [OperationContract]
        void Register(string UserName, string PassWord, string dienthoai, bool IsGV);
        [OperationContract]
        void Addcourse(string Tenkh, string manganh, DateTime batdau, DateTime kethuc, string chitiet, int hocphi, int manguoidang);
        [OperationContract]
        DataTable GetAllSubject();
        [OperationContract]
        Chitietkh GetCourseDetail(string makh);
        [OperationContract]
        DataTable SearchAll(string key);
        [OperationContract]
        DataTable SearchByCategory(string manganh);
        [OperationContract]
        DataTable GetTeacher();
        [OperationContract]
        DataTable GetStudent();
    }
    [DataContract]
    public class Chitietkh
    {
        private string tenkh;
        private string manganh;
        private string batdau;
        private string ketthuc;
        private string hocphi;
        private string chitiet;
        private string tenlienlac;
        private string dtlienlac;

        [DataMember]
        public string Tenkh
        {
            get { return tenkh; }
            set { tenkh = value; }
        }
        [DataMember]
        public string Manganh
        {
            get { return manganh; }
            set { manganh = value; }
        }
        [DataMember]
        public string Batdau
        {
            get { return batdau; }
            set { batdau = value; }
        }
        public string Ketthuc
        {
            get { return ketthuc; }
            set { ketthuc = value; }
        }
        public string Hocphi
        {
            get { return hocphi; }
            set { hocphi = value; }
        }
        public string Chitiet
        {
            get { return chitiet; }
            set { chitiet = value; }
        }
        public string Tenlienlac
        {
            get { return tenlienlac; }
            set { tenlienlac = value; }
        }        
        public string Dtlienlac
        {
            get { return dtlienlac; }
            set { dtlienlac = value; }
        }

        public Chitietkh(string manganh, string batdau, string ketthuc, string hocphi, string chitiet, string tenlienlac, string dtlienlac)
        {
            this.manganh=manganh;
            this.batdau=batdau;
            this.ketthuc=ketthuc;
            this.hocphi=hocphi;
            this.chitiet=chitiet;
            this.tenlienlac=tenlienlac;
            this.dtlienlac=dtlienlac;
        }

        public Chitietkh()
        {
            // TODO: Complete member initialization
        }     
    }
}