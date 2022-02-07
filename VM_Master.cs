using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mul.Models
{
    public class VM_Projects
    {
        public Int64 Project_id { get; set; }
        public string Project_code { get; set; }
        public string Project_name { get; set; }
        public string Domain { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string Client_name { get; set; }
        public string Client_contact { get; set; }
        public string Client_email { get; set; }
        public string Client_person { get; set; }
        public string Client_address { get; set; }
        public string Work_order { get; set; }
        public string Agreement { get; set; }
        public string SMP_doc { get; set; }
        public string BG_docs { get; set; }
        public string BG_name { get; set; }
        public string State { get; set; }
        public string Projecthead_id { get; set; }
        public string Project_head { get; set; }
        public string Project_status { get; set; }
        public List<VM_Projects> List { get; set; }
        public string Status { get; set; }

    }
    public class VM_Package
    {
        public Int64 Package_id { get; set; }
        public string Package_name { get; set; }
        public Int64 Project_id { get; set; }
        public string Project_name { get; set; }
        public Int64 Block { get; set; }
        public string Block_name { get; set; }
        public Int32 Division_id { get; set; }
        public string Contractor_name { get; set; }
        public string Contractor_contact { get; set; }
        public string Contractor_email { get; set; }
        public string Contractor_person { get; set; }
        public string Contractor_address { get; set; }
        public string Work_order { get; set; }
        public string Agreement { get; set; }
        public string Approved_designs { get; set; }
        public string BOQ_approved { get; set; }
        public string Tendor_document { get; set; }
        public string Package_status { get; set; }
        public List<VM_Package> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_Schemes
    {
        public Int64 Scheme_id { get; set; }
        public string Scheme_name { get; set; }
        public Int64 Package_id { get; set; }
        public string Package_name { get; set; }
        public Int64 Project_id { get; set; }
        public string Project_name { get; set; }
        public string Scheme_type { get; set; }
        public string Work_order { get; set; }
        public string Agreement { get; set; }
        public string Approved_designs { get; set; }
        public string Scheme_status { get; set; }
        public List<VM_Schemes> List { get; set; }
        public string Status { get; set; }

    }
    public class VM_Component
    {
        public Int64 Component_id { get; set; }
        public string Component_name { get; set; }
        public Int64 Scheme_id { get; set; }
        public Int64 Package_id { get; set; }
        public List<VM_Component> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_CmpDtl
    {
        public Int64 Cmp_id { get; set; }
        public string Cmp_name { get; set; }
        public Int64 Component_id { get; set; }
        public Int64 Scheme_id { get; set; }
        public Int64 Package_id { get; set; }
        public Int32 Block_id { get; set; }
        public Int32 District_id { get; set; }
        public List<VM_CmpDtl> List { get; set; }
        public double BOQ { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public Int64 Amount { get; set; }
        public string Geotech_DGPS { get; set; }
        public string Architectural_Drawings { get; set; }
        public string Approved_DPR { get; set; }
        public string Structure_DesignProof { get; set; }
        public string Mix_Design { get; set; }
        public string Approved_BBS { get; set; }
        public string Cmp_status { get; set; }
        public string Status { get; set; }
    }
    public class VM_SubActvty
    {
        public Int64 SubAct_id { get; set; }
        public string SubAct_name { get; set; }
        public Int64 Activity_id { get; set; }
        public string Activity_name{ get; set; }
        public Int64 Cmp_id { get; set; }
        public Int64 Component_id { get; set; }
        public Int64 Scheme_id { get; set; }
        public Int64 Package_id { get; set; }
        public Int32 Block_id { get; set; }
        public Int32 District_id { get; set; }
        public List<VM_SubActvty> List { get; set; }
        public double BOQ { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public Int64 Amount { get; set; }
        public Int64 Total_exctQnt { get; set; }
        public string SubAct_status { get; set; }
        public string Status { get; set; }
    }
    public class VM_Division
    {
        public Int64 Division_id { get; set; }
        public string Division_code { get; set; }
        public string Division_name { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public List<VM_Division> List { get; set; }
    }
    public class VM_District
    {
        public Int64 District_id { get; set; }
        public int Division_id { get; set; }
        public string Division_name { get; set; }
        public string District_name { get; set; }
        public string State { get; set; }
        public List<VM_District> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_Block
    {
        public Int64 Block_id { get; set; }
        public string Block_name { get; set; }
        public int District_id { get; set; }
        public string District_name { get; set; }
        public int Division_id { get; set; }
        public string Division_name { get; set; }
        public string State { get; set; }
        public List<VM_Block> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_Panchayat
    {
        public Int64 Panchayat_id { get; set; }
        public string Panchayat_name { get; set; }
        public int Block_id { get; set; }
        public string Block_name { get; set; }
        public int District_id { get; set; }
        public string District_name { get; set; }
        public int Division_id { get; set; }
        public string Division_name { get; set; }
        public string State { get; set; }
        public List<VM_Panchayat> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_Village
    {
        public Int64 Village_id { get; set; }
        public string Village_name { get; set; }
        public int Panchayat_id { get; set; }
        public string Panchayat_name { get; set; }
        public int Block_id { get; set; }
        public string Block_name { get; set; }
        public int District_id { get; set; }
        public string District_name { get; set; }
        public int Division_id { get; set; }
        public string Division_name { get; set; }
        public string State { get; set; }
        public List<VM_Village> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_School
    {
        public Int64 School_id { get; set; }
        public string School_name { get; set; }
        public string School_code { get; set; }
        public int Village_id { get; set; }
        public int Block_id { get; set; }
        public int Invoice_id { get; set; }
        public List<VM_School> List { get; set; }
        public string Status { get; set; }
    }
    public class VM_Anganwadi
    {
        public Int64 Anganwadi_id { get; set; }
        public string Anganwadi_name { get; set; }
        public string Anganwadi_building { get; set; }
        public int Village_id { get; set; }
        public int Block_id { get; set; }
        public List<VM_Anganwadi> List { get; set; }
        public string Status { get; set; }
    }
    public class Survey_Master
    {
        public Int64 Ssurvey_id { get; set; }
        public Int64 Asurvey_id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public int District_id { get; set; }
        public string District_name { get; set; }
        public int Block_id { get; set; }
        public string Block_name { get; set; }
        public int Panchayat_id { get; set; }
        public string Panchayat_name { get; set; }
        public int Village_id { get; set; }
        public string Village_name { get; set; }
        public int School_id { get; set; }
        public string School_name { get; set; }
        public string school_Code { get; set; }
        public string Survey_status { get; set; }
        public int anganwadi_ID { get; set; }
        public string Anganwadi_name { get; set; }
        public string anganwadi_Centre { get; set; }
        public string Electricity_Avail { get; set; }
        public string HP_Avail { get; set; }
        public string PipeWater_Avail { get; set; }
        public string Implmnt_agency { get; set; }
        public string Supply_scheme { get; set; }
        public string Work_boq { get; set; }
        public string Invoice_ref { get; set; }
        public string global_ID { get; set; }
        public string Providing_BoreWell1 { get; set; }
        public string BoreWell1_WorkDone { get; set; }
        public int BoreWell1_Workmanship { get; set; }
        public string Cpvc_Pipe2 { get; set; }
        public string Cpvc_Pipe2_WorkDone { get; set; }
        public int Cpvc_Pipe2_Workmanship { get; set; }
        public string Providing_BrassLongnose3 { get; set; }
        public string BrassLong3_WorkDone { get; set; }
        public int BrassLong3_Workmanship { get; set; }
        public string Providing_Cpvc_BallValve4 { get; set; }
        public string CpvcBallValve4_WorkDone { get; set; }
        public int CpvcBallValve4_Workmanship { get; set; }
        public string Providing_StorageTank5 { get; set; }
        public string StorageTank5_WorkDone { get; set; }
        public int StorageTank5_Workmanship { get; set; }
        public string Providing_HandPump6 { get; set; }
        public string HandPump6_WorkDone { get; set; }
        public int HandPump6_Workmanship { get; set; }
        public string Overall_Scheme { get; set; }
        public string Overall_remark { get; set; }
        public string photo_boreWell { get; set; }
        public string photo_handPump { get; set; }
        public string photo_overallStatus { get; set; }
        public string photo_storageTank { get; set; }
        public string dateOfInstallation { get; set; }
        public string verification_State { get; set; }
        public string versionName { get; set; }
        public string surveyType { get; set; }
        public int Survey_apporvStat { get; set; }
        public string Survey_apporve { get; set; }
        public string Survey_date { get; set; }
        public string Survey_remark { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string user_code { get; set; }
        public string Status { get; set; }
    }
    public class Invoice_Upload
    {
        public Int64 Invoice_id { get; set; }
        public int School_id { get; set; }
        public string School_name { get; set; }
        public string School_code { get; set; }
        public int Anganwadi_id { get; set; }
        public string Anganwadi_name { get; set; }
        public string Anganwadi_building { get; set; }
        public int Village_id { get; set; }
        public string Village_name { get; set; }
        public int Block_id { get; set; }
        public string Block_name { get; set; }
        public string Invoice_no { get; set; }
        public string Invoice_date { get; set; }
        public string Invoice_amount { get; set; }
        public string Invoice_detail { get; set; }
        public string School_val { get; set; }
        public string Aganwd_val { get; set; }
        public string InvoiceUpload { get; set; }
        public string Invoice_uploadby { get; set; }
        public string Invoice_uploadDate { get; set; }
        public string verification_State { get; set; }
        public List<Invoice_Upload> List { get; set; }
        public string Status { get; set; }
    }


}