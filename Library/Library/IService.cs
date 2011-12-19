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
        void Register(string UserName, string PassWord, string dienthoai, string SN, bool IsGV);
        [OperationContract]
        void Addcourse(string Tenkh, string manganh, DateTime batdau, DateTime kethuc, string chitiet, int hocphi, int manguoidang);
        [OperationContract]
        CourseDetail GetCourseDetail(string makh);  
        [OperationContract]
        AllSubject GetAllSubject();
        [OperationContract]
        Result SearchAll(string key);              
        [OperationContract]
        ResultByCategory SearchByCategory(string manganh);
        [OperationContract]
        Teacher GetTeacher();
        [OperationContract]
        Student GetStudent();
    }
    [DataContract]
     public class AllSubject
    {        
        private int makh;      
        private string tenkh;        
        private string manganh;
        [DataMember]
        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }        
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
    }
    [DataContract]
    public class CourseDetail
    {
        private string tenkh;        
        private string manganh;
        private string batdau;
        private string ketthuc;
        private string chitiet;
        private int hocphi;
        private string ten;
        private string dt;        
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
        [DataMember]
        public string Ketthuc
        {
            get { return ketthuc; }
            set { ketthuc = value; }
        }
        [DataMember]
        public string Chitiet
        {
            get { return chitiet; }
            set { chitiet = value; }
        }
        [DataMember]
        public int Hocphi
        {
            get { return hocphi; }
            set { hocphi = value; }
        }
        [DataMember]
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        [DataMember]
        public string Dt
        {
            get { return dt; }
            set { dt = value; }
        }
    }
    [DataContract]
    public class Result
    {        
        private string tenkh;
        private string manganh;        
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
    }
    [DataContract]
    public class ResultByCategory
    {       
        private string tenkh;
        private string manganh;        
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
    }
    [DataContract]
    public class Teacher
    {
        private int ma;
        private string ten;
        private string mk;
        private string dt;
        private string sn;
        [DataMember]
        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        [DataMember]
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        [DataMember]
        public string Mk
        {
            get { return mk; }
            set { mk = value; }
        }
        public string Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
    }
    [DataContract]
    public class Student
    {
        private int ma;
        private string ten;
        private string mk;
        private string dt;
        private string sn;
        [DataMember]
        public int Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        [DataMember]
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        [DataMember]
        public string Mk
        {
            get { return mk; }
            set { mk = value; }
        }
        public string Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
    }
}