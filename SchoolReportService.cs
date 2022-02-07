using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Mul.Models;
using System.Net.Mail;

namespace Mul.Services
{
    public class SchoolReportService
    {
        MyDatabaseClass objdb = new MyDatabaseClass();
        bool hasExceptionThrown = false;
        string errorMessage = "";
        public List<VM_District> District_list(string usrid)
        {
            List<VM_District> Dist_list = new List<VM_District>();
            try
            {
                DataSet ds1 = new DataSet();
                if (usrid != null)
                {
                    ds1 = objdb.GetDataSet("select District_id from allocation_detail where User_Id= '" + usrid + "' and Project_id='100' and District_id !='0' and status='A'", ref hasExceptionThrown, ref errorMessage);
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int a = 0; a < ds1.Tables[0].Rows.Count; a++)
                    {
                        var District_id = Convert.ToInt32(ds1.Tables[0].Rows[a]["District_id"].ToString());
                        DataSet ds = new DataSet();
                        if (District_id != 0)
                        {
                            ds = objdb.GetDataSet("select * from district_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    VM_District vm = new VM_District();
                                    vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                                    vm.District_name = ds.Tables[0].Rows[i]["District_name"].ToString();
                                    //vm.Division_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Division_id"].ToString());
                                    Dist_list.Add(vm);
                                }
                            }
                        }
                    }
                }
                else
                {

                    ds1 = objdb.GetDataSet("select Division_id from allocation_detail where User_Id= '" + usrid + "' and Project_id='100' and status='A'", ref hasExceptionThrown, ref errorMessage);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int b = 0; b < ds1.Tables[0].Rows.Count; b++)
                        {
                            var Division_id = Convert.ToInt32(ds1.Tables[0].Rows[b]["Division_id"].ToString());
                            DataSet ds2 = new DataSet();
                            if (Division_id != 0)
                            {
                                ds2 = objdb.GetDataSet("select * from district_master where Division_id= '" + Division_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                            }
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                                {
                                    VM_District vm = new VM_District();
                                    vm.District_id = Convert.ToInt32(ds2.Tables[0].Rows[i]["District_id"].ToString());
                                    vm.District_name = ds2.Tables[0].Rows[i]["District_name"].ToString();
                                    vm.Division_id = Convert.ToInt32(ds2.Tables[0].Rows[i]["Division_id"].ToString());
                                    Dist_list.Add(vm);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Dist_list;
        }
        public List<VM_Panchayat> Panchayat_list(VM_Panchayat Request_Data)
        {
            List<VM_Panchayat> Vilg_list = new List<VM_Panchayat>();
            var Block_id = Convert.ToInt32(Request_Data.Block_id);
            DataSet ds = new DataSet();
            if (Block_id != 0)
            {
                try
                {

                    ds = objdb.GetDataSet("select * from panchayat_master_old where Block_id= '" + Block_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            VM_Panchayat vm = new VM_Panchayat();
                            vm.Panchayat_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Panchayat_id"].ToString());
                            vm.Panchayat_name = ds.Tables[0].Rows[i]["Panchayat_name"].ToString();
                            vm.Block_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Block_id"].ToString());
                            Vilg_list.Add(vm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    throw;
                }
            }
            return Vilg_list;
        }
        public List<VM_Village> Village_list(VM_Village Request_Data)
        {
            List<VM_Village> Vilg_list = new List<VM_Village>();
            var Block_id = Convert.ToInt32(Request_Data.Block_id);
            DataSet ds = new DataSet();
            if (Block_id != 0)
            {
                try
                {
                    ds = objdb.GetDataSet("select * from village_master_old where Block_id= '" + Block_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            VM_Village vm = new VM_Village();
                            vm.Village_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Village_id"].ToString());
                            vm.Village_name = ds.Tables[0].Rows[i]["Village_name"].ToString();
                            vm.Block_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Block_id"].ToString());
                            Vilg_list.Add(vm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    throw;
                }
            }
            return Vilg_list;
        }
        public List<Invoice_Upload> School_list(Invoice_Upload Request_Data)
        {
            List<Invoice_Upload> Schl_list = new List<Invoice_Upload>();
            try
            {
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var verif_State = Request_Data.verification_State;
                DataSet ds = new DataSet();
                if (Block_id != 0)
                {
                    ds = objdb.GetDataSet("select * from school_master where Block_id= '" + Block_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Invoice_Upload vm = new Invoice_Upload();
                            vm.School_id = Convert.ToInt32(ds.Tables[0].Rows[i]["School_id"].ToString());
                            vm.School_name = ds.Tables[0].Rows[i]["School_name"].ToString();
                            vm.School_code = ds.Tables[0].Rows[i]["School_code"].ToString();
                            var VillageId = Convert.ToInt32(ds.Tables[0].Rows[i]["Village_id"].ToString());
                            vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id= '" + VillageId + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                            vm.Block_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Block_id"].ToString());
                            vm.Invoice_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_id"].ToString());
                            Schl_list.Add(vm);
                        }
                    }
                }
                if (Block_id != 0)
                {
                    ds = objdb.GetDataSet("select * from anganwadi_master where Block_id= '" + Block_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Invoice_Upload vm = new Invoice_Upload();
                            vm.Anganwadi_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Anganwadi_id"].ToString());
                            vm.Anganwadi_name = ds.Tables[0].Rows[i]["Anganwadi_name"].ToString();
                            vm.Anganwadi_building = ds.Tables[0].Rows[i]["Anganwadi_building"].ToString();
                            var VillageId = Convert.ToInt32(ds.Tables[0].Rows[i]["Village_id"].ToString());
                            vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id= '" + VillageId + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                            vm.Block_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Block_id"].ToString());
                            vm.Invoice_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_id"].ToString());
                            Schl_list.Add(vm);
                        }
                    }
                }
                return Schl_list;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        public bool InvoiceUploads(Invoice_Upload vm, string usrid)
        {
            MyDatabaseClass objdb = new MyDatabaseClass();
            bool hasExceptionThrown = false;
            string errorMessage = "";
            SortedList sl = new SortedList();
            int counter = 0;
            try
            {
                if (vm.InvoiceUpload != null)
                {
                    if (vm.InvoiceUpload.Contains(@"C:\fakepath\"))
                        vm.InvoiceUpload = vm.InvoiceUpload.Replace(@"C:\fakepath\", "");
                    String pretend = DateTime.Now.ToString("dd-MMM-yyyy");
                    vm.InvoiceUpload = pretend + "_" + vm.Invoice_no + vm.InvoiceUpload;
                }
                if (vm.Invoice_id == 0)
                {
                    string dup = objdb.GetSingleValue("select count(Invoice_no) from invoice_details where Invoice_no ='" + vm.Invoice_no + "'", ref hasExceptionThrown, ref errorMessage);
                    if (Convert.ToInt32(dup) > 0) return false;
                    string maxid = objdb.GetSingleValue("select max(Invoice_id) from invoice_details", ref hasExceptionThrown, ref errorMessage);
                    if (maxid == "") maxid = "0";
                    maxid = (Convert.ToInt32(maxid) + 1).ToString();
                    string createdby = usrid; //Session["username"].ToString();
                    string sql = "insert into invoice_details(Invoice_id,Invoice_no,Invoice_date,Invoice_amount,Invoice_detail,Block_id,Invoice_Upload,Invoice_Uploadby,Invoice_uploadDate) values ";
                    sql += "('" + maxid + "','" + vm.Invoice_no + "','" + vm.Invoice_date + "','" + vm.Invoice_amount + "','" + vm.Invoice_detail + "','" + vm.Block_id + "','" + vm.InvoiceUpload + "','" + createdby + "',GETDATE()) ";
                    sl.Add(counter, sql); counter++;
                    string[] arrSchool = vm.School_val.Split(',');
                    string[] arrAngawdi = vm.Aganwd_val.Split(',');
                    if (arrSchool.Length != 0)
                    {

                        for (int b = 0; b < arrSchool.Length; b++)
                        {
                            sql = "Update school_master set Invoice_id ='" + maxid + "' where School_id='" + arrSchool[b] + "'";
                            sl.Add(counter, sql); counter++;
                        }
                    }
                    if (arrAngawdi.Length != 0)
                    {

                        for (int b = 0; b < arrAngawdi.Length; b++)
                        {
                            sql = "Update anganwadi_master set Invoice_id ='" + maxid + "' where Anganwadi_id='" + arrSchool[b] + "'";
                            sl.Add(counter, sql); counter++;
                        }

                    }
                    objdb.GetRowsAffected(sl, ref hasExceptionThrown, ref errorMessage);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return true;
        }
        public List<Invoice_Upload> Invoice_list(string usrid)
        {
            List<Invoice_Upload> Invoic_list = new List<Invoice_Upload>();
            try
            {
                DataSet ds1 = new DataSet();
                if (usrid != null)
                {
                    ds1 = objdb.GetDataSet("select District_id from allocation_detail where User_Id= '" + usrid + "' and Project_id='100' and status='A'", ref hasExceptionThrown, ref errorMessage);
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int a = 0; a < ds1.Tables[0].Rows.Count; a++)
                    {
                        var District_id = Convert.ToInt32(ds1.Tables[0].Rows[a]["District_id"].ToString());
                        DataSet ds = new DataSet();
                        if (District_id != 0)
                        {
                            ds = objdb.GetDataSet("select b.Block_id, b.Block_name, i.* from block_master b, invoice_details i where b.District_id= '" + District_id + "' and i.Block_id = b.Block_id and b.status='A'", ref hasExceptionThrown, ref errorMessage);
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                Invoice_Upload vm = new Invoice_Upload();
                                vm.Invoice_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_id"].ToString());
                                vm.Block_name = ds.Tables[0].Rows[i]["Block_name"].ToString();
                                vm.Invoice_no = ds.Tables[0].Rows[i]["Invoice_no"].ToString();
                                vm.Invoice_date = ds.Tables[0].Rows[i]["Invoice_date"].ToString();
                                vm.Invoice_amount = ds.Tables[0].Rows[i]["Invoice_amount"].ToString();
                                var InvoiceUploadby = ds.Tables[0].Rows[i]["Invoice_uploadby"].ToString();
                                vm.Invoice_uploadby = objdb.GetSingleValue("select Emp_name from user_master where Emp_code= '" + InvoiceUploadby + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                                vm.Invoice_uploadDate = ds.Tables[0].Rows[i]["Invoice_uploadDate"].ToString();
                                Invoic_list.Add(vm);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Invoic_list;
        }
        public List<Survey_Master> Survey_list(Survey_Master Request_Data)
        {
            List<Survey_Master> Survey_list = new List<Survey_Master>();
            try
            {
                var District_id = Convert.ToInt32(Request_Data.District_id);
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var Village_id = Convert.ToInt32(Request_Data.Village_id);
                var verification_State = Request_Data.verification_State;
                var fromdate = Request_Data.fromDate;
                var todate = Request_Data.toDate;
                if (District_id == 0) { return Survey_list; }
                DataSet ds = new DataSet();
                string schlsrch = "Select * from school_survey where ";
                if (Request_Data.District_id != 0)
                {
                    schlsrch += "District_id = '" + Request_Data.District_id + "' and";
                }
                if (Request_Data.Block_id != 0)
                {
                    schlsrch += " Block_id = '" + Request_Data.Block_id + "' and";
                }
                if (Request_Data.Panchayat_id != 0)
                {
                    schlsrch += " Panchayat_id = '" + Request_Data.Panchayat_id + "' and";
                }
                if (Request_Data.verification_State == "School")
                {
                    schlsrch += " verification_State = 'School' and";
                }
                if (Request_Data.verification_State == "Anganwadi")
                {
                    schlsrch += " verification_State = 'Anganwadi' and";
                }
                if (Request_Data.fromDate != null && Request_Data.toDate != null)
                {
                    schlsrch += " Installation_date >= '" + Request_Data.fromDate + "' AND Installation_date<= '" + Request_Data.toDate + "' and";
                }
                schlsrch += " Status='A' and Survey_apporve is null";

                ds = objdb.GetDataSet(schlsrch, ref hasExceptionThrown, ref errorMessage);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Survey_Master vm = new Survey_Master();
                        vm.Ssurvey_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Ssurvey_id"].ToString());
                        vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                        vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id ='" + vm.District_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var blk_id = ds.Tables[0].Rows[i]["Block_id"].ToString();
                        vm.Block_name = objdb.GetSingleValue("select Block_name from block_master where Block_id='" + blk_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var pac_id = ds.Tables[0].Rows[i]["Panchayat_id"].ToString();
                        vm.Panchayat_name = objdb.GetSingleValue("select Panchayat_name from panchayat_master where Panchayat_id='" + pac_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var vlg_id = ds.Tables[0].Rows[i]["Village_id"].ToString();
                        vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id='" + vlg_id + "'", ref hasExceptionThrown, ref errorMessage);
                        vm.verification_State = ds.Tables[0].Rows[i]["verification_State"].ToString();
                        var verif_State = ds.Tables[0].Rows[i]["verification_State"].ToString();
                        if (verif_State == "School")
                        {
                            var schl_id = ds.Tables[0].Rows[i]["School_id"].ToString();
                            if (schl_id != null && schl_id != "")
                            {
                                vm.School_id = Convert.ToInt32(schl_id);
                                vm.School_name = objdb.GetSingleValue("select School_name from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                            }
                        }
                        else
                        {
                            var anganwd_id = ds.Tables[0].Rows[i]["Anganwadi_id"].ToString();
                            if (anganwd_id != null && anganwd_id != "")
                            {
                                vm.anganwadi_ID = Convert.ToInt32(anganwd_id);
                                vm.Anganwadi_name = objdb.GetSingleValue("select Anganwadi_name from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                            }
                        }
                        vm.dateOfInstallation = ds.Tables[0].Rows[i]["Installation_date"].ToString();
                        vm.Electricity_Avail = ds.Tables[0].Rows[i]["Electricity_Avail"].ToString();
                        vm.HP_Avail = ds.Tables[0].Rows[i]["HP_Avail"].ToString();
                        vm.PipeWater_Avail = ds.Tables[0].Rows[i]["PipeWater_Avail"].ToString();
                        vm.Implmnt_agency = ds.Tables[0].Rows[i]["Implmnt_agency"].ToString();
                        vm.Supply_scheme = ds.Tables[0].Rows[i]["Supply_scheme"].ToString();
                        vm.BoreWell1_WorkDone = ds.Tables[0].Rows[i]["BoreWell1_WorkDone"].ToString();
                        if (vm.BoreWell1_WorkDone == "YES")
                        {
                            vm.BoreWell1_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BoreWell1_Workmanship"].ToString());
                            vm.Providing_BoreWell1 = Workmanshipnam(vm.BoreWell1_Workmanship);
                        }
                        vm.Cpvc_Pipe2_WorkDone = ds.Tables[0].Rows[i]["Cpvc_Pipe2_WorkDone"].ToString();
                        if (vm.Cpvc_Pipe2_WorkDone == "YES")
                        {
                            vm.Cpvc_Pipe2_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["Cpvc_Pipe2_Workmanship"].ToString());
                            vm.Cpvc_Pipe2 = Workmanshipnam(vm.Cpvc_Pipe2_Workmanship);
                        }
                        vm.BrassLong3_WorkDone = ds.Tables[0].Rows[i]["BrassLong3_WorkDone"].ToString();
                        if (vm.BrassLong3_WorkDone == "YES")
                        {
                            vm.BrassLong3_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BrassLong3_Workmanship"].ToString());
                            vm.Providing_BrassLongnose3 = Workmanshipnam(vm.BrassLong3_Workmanship);
                        }
                        vm.CpvcBallValve4_WorkDone = ds.Tables[0].Rows[i]["CpvcBallValve4_WorkDone"].ToString();
                        if (vm.CpvcBallValve4_WorkDone == "YES")
                        {
                            vm.CpvcBallValve4_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["CpvcBallValve4_Workmanship"].ToString());
                            vm.Providing_Cpvc_BallValve4 = Workmanshipnam(vm.CpvcBallValve4_Workmanship);
                        }
                        vm.StorageTank5_WorkDone = ds.Tables[0].Rows[i]["StorageTank5_WorkDone"].ToString();
                        if (vm.StorageTank5_WorkDone == "YES")
                        {
                            vm.StorageTank5_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["StorageTank5_Workmanship"].ToString());
                            vm.Providing_StorageTank5 = Workmanshipnam(vm.StorageTank5_Workmanship);
                        }
                        vm.HandPump6_WorkDone = ds.Tables[0].Rows[i]["HandPump6_WorkDone"].ToString();
                        if (vm.HandPump6_WorkDone == "YES")
                        {
                            vm.HandPump6_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["HandPump6_Workmanship"].ToString());
                            vm.Providing_HandPump6 = Workmanshipnam(vm.HandPump6_Workmanship);
                        }
                        vm.Overall_Scheme = ds.Tables[0].Rows[i]["Overall_Scheme"].ToString();
                        vm.Overall_remark = ds.Tables[0].Rows[i]["Overall_remark"].ToString();
                        string workmanship = "";
                        if (vm.BoreWell1_Workmanship == 0 || vm.Cpvc_Pipe2_Workmanship == 0 || vm.BrassLong3_Workmanship == 0 || vm.CpvcBallValve4_Workmanship == 0 || vm.StorageTank5_Workmanship == 0 || vm.HandPump6_Workmanship == 0)
                        {
                            if (vm.Overall_Scheme == "Non Operational") { workmanship = ""; } else { workmanship = Workmanshipnam(5); }
                        }
                        else if (vm.BoreWell1_Workmanship > 4 || vm.Cpvc_Pipe2_Workmanship > 4 || vm.BrassLong3_Workmanship > 4 || vm.CpvcBallValve4_Workmanship > 4 || vm.StorageTank5_Workmanship > 4 || vm.HandPump6_Workmanship > 4)
                        {
                            workmanship = Workmanshipnam(5);
                        }
                        else if (vm.BoreWell1_Workmanship > 3 || vm.Cpvc_Pipe2_Workmanship > 3 || vm.BrassLong3_Workmanship > 3 || vm.CpvcBallValve4_Workmanship > 3 || vm.StorageTank5_Workmanship > 3 || vm.HandPump6_Workmanship > 3)
                        {
                            workmanship = Workmanshipnam(4);
                        }
                        else if (vm.BoreWell1_Workmanship > 2 || vm.Cpvc_Pipe2_Workmanship > 2 || vm.BrassLong3_Workmanship > 2 || vm.CpvcBallValve4_Workmanship > 2 || vm.StorageTank5_Workmanship > 2 || vm.HandPump6_Workmanship > 2)
                        {
                            workmanship = Workmanshipnam(3);
                        }
                        else if (vm.BoreWell1_Workmanship > 1 || vm.Cpvc_Pipe2_Workmanship > 1 || vm.BrassLong3_Workmanship > 1 || vm.CpvcBallValve4_Workmanship > 1 || vm.StorageTank5_Workmanship > 1 || vm.HandPump6_Workmanship > 1)
                        {
                            workmanship = Workmanshipnam(2);
                        }
                        else if (vm.BoreWell1_Workmanship == 1 || vm.Cpvc_Pipe2_Workmanship == 1 || vm.BrassLong3_Workmanship == 1 || vm.CpvcBallValve4_Workmanship == 1 || vm.StorageTank5_Workmanship == 1 || vm.HandPump6_Workmanship == 1)
                        {
                            workmanship = Workmanshipnam(1);
                        }
                        vm.photo_boreWell = ds.Tables[0].Rows[i]["photo_boreWell"].ToString();
                        vm.photo_handPump = ds.Tables[0].Rows[i]["photo_handPump"].ToString();
                        vm.photo_storageTank = ds.Tables[0].Rows[i]["photo_storageTank"].ToString();
                        vm.photo_overallStatus = ds.Tables[0].Rows[i]["photo_overallStatus"].ToString();
                        vm.Work_boq = vm.Overall_Scheme + " - " + workmanship;
                        vm.user_code= ds.Tables[0].Rows[i]["Created_user"].ToString();
                        Survey_list.Add(vm);
                    }

                }
                return Survey_list;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                // return Survey_list;
                throw;
            }
        }
        public bool Approval_Survey(int School_id, string verification_State, string Survey_remark, string UID)
        {
            MyDatabaseClass objdb = new MyDatabaseClass();
            bool hasExceptionThrown = false;
            string errorMessage = "";
            SortedList sl = new SortedList();
            int counter = 0;
            try
            {
                if (verification_State == "School") {
                string sql = "update school_master set School_status='2', Survey_status='Approved', Updated_user='" + UID + "', Updated_date=Getdate() where School_id='" + School_id + "'";
                sl.Add(counter, sql); counter++;
                sql = "update school_survey set Survey_apporve='Approve', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where School_id='" + School_id + "'";
                sl.Add(counter, sql); counter++;
                }
                else {
                    string sql = "update anganwadi_master set Anganwadi_status='2', Survey_status='Approved', Updated_user='" + UID + "', Updated_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                    sql = "update school_survey set Survey_apporve='Approve', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                }                
                int i = objdb.GetRowsAffected(sl, ref hasExceptionThrown, ref errorMessage);
                if (i > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public bool Reject_Survey(int School_id, string verification_State, string Survey_remark, string UID)
        {
            MyDatabaseClass objdb = new MyDatabaseClass();
            bool hasExceptionThrown = false;
            string errorMessage = "";
            SortedList sl = new SortedList();
            int counter = 0;
            try
            {
                if (verification_State == "School")
                {
                    string sql = "update school_master set School_status='0', Survey_status='Reject', Updated_user='" + UID + "', Updated_date=Getdate() where School_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                    sql = "update school_survey set Survey_apporve='Reject', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where School_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                }
                else
                {
                    string sql = "update anganwadi_master set Anganwadi_status='0', Survey_status='Reject', Updated_user='" + UID + "', Updated_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                    sql = "update school_survey set Survey_apporve='Reject', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                }
                int i = objdb.GetRowsAffected(sl, ref hasExceptionThrown, ref errorMessage);
                if (i > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public bool Tochange_Survey(int School_id, string verification_State, string Survey_remark, string UID)
        {
            MyDatabaseClass objdb = new MyDatabaseClass();
            bool hasExceptionThrown = false;
            string errorMessage = "";
            SortedList sl = new SortedList();
            int counter = 0;
            try
            {
                if (verification_State == "School")
                {
                    string sql = "update school_master set School_status='3', Survey_status='Hold', Updated_user='" + UID + "', Updated_date=Getdate() where School_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                    sql = "update school_survey set Survey_apporve='Hold', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where School_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                }
                else if(verification_State == "Anganwadi")
                {
                    string sql = "update anganwadi_master set Anganwadi_status='3', Survey_status='Hold', Updated_user='" + UID + "', Updated_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                    sql = "update school_survey set Survey_apporve='Hold', Survey_remark='" + Survey_remark + "', Apporved_by='" + UID + "', Approve_date=Getdate() where Anganwadi_id='" + School_id + "'";
                    sl.Add(counter, sql); counter++;
                }
                int i = objdb.GetRowsAffected(sl, ref hasExceptionThrown, ref errorMessage);
                if (i > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public List<Survey_Master> UpdatSurvey_list(Survey_Master Request_Data)
        {
            List<Survey_Master> Survey_list = new List<Survey_Master>();
            try
            {
                var District_id = Convert.ToInt32(Request_Data.District_id);
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var Village_id = Convert.ToInt32(Request_Data.Village_id);
                var verif_State = Request_Data.verification_State;
                var fromdate = Request_Data.fromDate;
                var todate = Request_Data.toDate;
                DataSet ds = new DataSet();

                string schlsrch = "Select * from school_survey where ";
                if (Request_Data.District_id != 0)
                {
                    schlsrch += "District_id = '" + Request_Data.District_id + "'";
                }
                if (Request_Data.Block_id != 0)
                {
                    schlsrch += " and Block_id = '" + Request_Data.Block_id + "'";
                }
                if (Request_Data.Village_id != 0)
                {
                    schlsrch += " and Village_id = '" + Request_Data.Village_id + "'";
                }
                if (Request_Data.fromDate != null && Request_Data.toDate != null)
                {
                    schlsrch += " and Approve_date >= '" + Request_Data.fromDate + "' AND Approve_date<= '" + Request_Data.toDate + "'";
                }
                if (Request_Data.verification_State == "School")
                {
                    schlsrch += " and verification_State = 'School'";
                }
                if (Request_Data.verification_State == "Anganwadi")
                {
                    schlsrch += " and verification_State = 'Anganwadi'";
                }
                if (Request_Data.Survey_apporvStat == 1)
                {
                    schlsrch += " and Survey_apporve='Approve'";
                }
                else if (Request_Data.Survey_apporvStat == 2)
                {
                    schlsrch += " and Survey_apporve='Reject'";
                }else if(Request_Data.Survey_apporvStat == 3)
                {
                    schlsrch += " and Survey_apporve='Hold'";
                }
                schlsrch += " and Status='A'";

                ds = objdb.GetDataSet(schlsrch, ref hasExceptionThrown, ref errorMessage);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Survey_Master vm = new Survey_Master();
                        vm.Ssurvey_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Ssurvey_id"].ToString());
                        vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                        vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id ='" + vm.District_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var blk_id = ds.Tables[0].Rows[i]["Block_id"].ToString();
                        vm.Block_name = objdb.GetSingleValue("select Block_name from block_master where Block_id='" + blk_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var vlg_id = ds.Tables[0].Rows[i]["Village_id"].ToString();
                        vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id='" + vlg_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var schl_id = ds.Tables[0].Rows[i]["School_id"].ToString();
                        if (schl_id != null && schl_id != "")
                        {
                            vm.School_id = Convert.ToInt32(schl_id);
                            vm.School_name = objdb.GetSingleValue("select School_name from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        var anganwd_id = ds.Tables[0].Rows[i]["Anganwadi_id"].ToString();
                        if (anganwd_id != null && anganwd_id != "" && Convert.ToInt32(anganwd_id) != 0)
                        {
                            vm.anganwadi_ID = Convert.ToInt32(anganwd_id);
                            vm.Anganwadi_name = objdb.GetSingleValue("select Anganwadi_name from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        vm.Survey_date = ds.Tables[0].Rows[i]["Approve_date"].ToString();
                        vm.dateOfInstallation = ds.Tables[0].Rows[i]["Installation_date"].ToString();
                        vm.Electricity_Avail = ds.Tables[0].Rows[i]["Electricity_Avail"].ToString();
                        vm.HP_Avail = ds.Tables[0].Rows[i]["HP_Avail"].ToString();
                        vm.PipeWater_Avail = ds.Tables[0].Rows[i]["PipeWater_Avail"].ToString();
                        vm.Implmnt_agency = ds.Tables[0].Rows[i]["Implmnt_agency"].ToString();
                        vm.Supply_scheme = ds.Tables[0].Rows[i]["Supply_scheme"].ToString();
                        vm.BoreWell1_WorkDone = ds.Tables[0].Rows[i]["BoreWell1_WorkDone"].ToString();
                        if (vm.BoreWell1_WorkDone == "YES")
                        {
                            vm.BoreWell1_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BoreWell1_Workmanship"].ToString());
                            vm.Providing_BoreWell1 = Workmanshipnam(vm.BoreWell1_Workmanship);
                        }
                        vm.Cpvc_Pipe2_WorkDone = ds.Tables[0].Rows[i]["Cpvc_Pipe2_WorkDone"].ToString();
                        if (vm.Cpvc_Pipe2_WorkDone == "YES")
                        {
                            vm.Cpvc_Pipe2_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["Cpvc_Pipe2_Workmanship"].ToString());
                            vm.Cpvc_Pipe2 = Workmanshipnam(vm.Cpvc_Pipe2_Workmanship);
                        }
                        vm.BrassLong3_WorkDone = ds.Tables[0].Rows[i]["BrassLong3_WorkDone"].ToString();
                        if (vm.BrassLong3_WorkDone == "YES")
                        {
                            vm.BrassLong3_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BrassLong3_Workmanship"].ToString());
                            vm.Providing_BrassLongnose3 = Workmanshipnam(vm.BrassLong3_Workmanship);
                        }
                        vm.CpvcBallValve4_WorkDone = ds.Tables[0].Rows[i]["CpvcBallValve4_WorkDone"].ToString();
                        if (vm.CpvcBallValve4_WorkDone == "YES")
                        {
                            vm.CpvcBallValve4_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["CpvcBallValve4_Workmanship"].ToString());
                            vm.Providing_Cpvc_BallValve4 = Workmanshipnam(vm.CpvcBallValve4_Workmanship);
                        }
                        vm.StorageTank5_WorkDone = ds.Tables[0].Rows[i]["StorageTank5_WorkDone"].ToString();
                        if (vm.StorageTank5_WorkDone == "YES")
                        {
                            vm.StorageTank5_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["StorageTank5_Workmanship"].ToString());
                            vm.Providing_StorageTank5 = Workmanshipnam(vm.StorageTank5_Workmanship);
                        }
                        vm.HandPump6_WorkDone = ds.Tables[0].Rows[i]["HandPump6_WorkDone"].ToString();
                        if (vm.HandPump6_WorkDone == "YES")
                        {
                            vm.HandPump6_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["HandPump6_Workmanship"].ToString());
                            vm.Providing_HandPump6 = Workmanshipnam(vm.HandPump6_Workmanship);
                        }
                        vm.Overall_Scheme = ds.Tables[0].Rows[i]["Overall_Scheme"].ToString();
                        vm.Overall_remark = ds.Tables[0].Rows[i]["Overall_remark"].ToString();
                        string workmanship = "";
                        if (vm.BoreWell1_Workmanship == 0 || vm.Cpvc_Pipe2_Workmanship == 0 || vm.BrassLong3_Workmanship == 0 || vm.CpvcBallValve4_Workmanship == 0 || vm.StorageTank5_Workmanship == 0 || vm.HandPump6_Workmanship == 0)
                        {
                            if (vm.Overall_Scheme == "Non Operational") { workmanship = ""; } else { workmanship = Workmanshipnam(5); }
                        }
                        else if (vm.BoreWell1_Workmanship > 4 || vm.Cpvc_Pipe2_Workmanship > 4 || vm.BrassLong3_Workmanship > 4 || vm.CpvcBallValve4_Workmanship > 4 || vm.StorageTank5_Workmanship > 4 || vm.HandPump6_Workmanship > 4)
                        {
                            workmanship = Workmanshipnam(5);
                        }
                        else if (vm.BoreWell1_Workmanship > 3 || vm.Cpvc_Pipe2_Workmanship > 3 || vm.BrassLong3_Workmanship > 3 || vm.CpvcBallValve4_Workmanship > 3 || vm.StorageTank5_Workmanship > 3 || vm.HandPump6_Workmanship > 3)
                        {
                            workmanship = Workmanshipnam(4);
                        }
                        else if (vm.BoreWell1_Workmanship > 2 || vm.Cpvc_Pipe2_Workmanship > 2 || vm.BrassLong3_Workmanship > 2 || vm.CpvcBallValve4_Workmanship > 2 || vm.StorageTank5_Workmanship > 2 || vm.HandPump6_Workmanship > 2)
                        {
                            workmanship = Workmanshipnam(3);
                        }
                        else if (vm.BoreWell1_Workmanship > 1 || vm.Cpvc_Pipe2_Workmanship > 1 || vm.BrassLong3_Workmanship > 1 || vm.CpvcBallValve4_Workmanship > 1 || vm.StorageTank5_Workmanship > 1 || vm.HandPump6_Workmanship > 1)
                        {
                            workmanship = Workmanshipnam(2);
                        }
                        else if (vm.BoreWell1_Workmanship == 1 || vm.Cpvc_Pipe2_Workmanship == 1 || vm.BrassLong3_Workmanship == 1 || vm.CpvcBallValve4_Workmanship == 1 || vm.StorageTank5_Workmanship == 1 || vm.HandPump6_Workmanship == 1)
                        {
                            workmanship = Workmanshipnam(1);
                        }
                        vm.Survey_apporve = ds.Tables[0].Rows[i]["Survey_apporve"].ToString();
                        vm.Survey_remark = ds.Tables[0].Rows[i]["Survey_remark"].ToString();
                        vm.photo_storageTank = ds.Tables[0].Rows[i]["photo_storageTank"].ToString();
                        vm.photo_overallStatus = ds.Tables[0].Rows[i]["photo_overallStatus"].ToString();
                        vm.Work_boq = vm.Overall_Scheme + " - " + workmanship;
                        vm.user_code = ds.Tables[0].Rows[i]["Created_user"].ToString();
                        Survey_list.Add(vm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Survey_list;
        }
        public List<Survey_Master> SchoolReport_A(Survey_Master Request_Data)
        {
            List<Survey_Master> Report_list = new List<Survey_Master>();
            try
            {
                var District_id = Convert.ToInt32(Request_Data.District_id);
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var Village_id = Convert.ToInt32(Request_Data.Village_id);
                var verif_State = Request_Data.verification_State;
                var fromdate = Request_Data.fromDate;
                var todate = Request_Data.toDate;
                DataSet ds = new DataSet();

                string schlsrch = "Select * from school_survey where ";
                if (Request_Data.District_id != 0)
                {
                    schlsrch += "District_id = '" + Request_Data.District_id + "'";
                }
                if (Request_Data.Block_id != 0)
                {
                    schlsrch += " and Block_id = '" + Request_Data.Block_id + "'";
                }
                if (Request_Data.Village_id != 0)
                {
                    schlsrch += " and Village_id = '" + Request_Data.Village_id + "'";
                }
                if (Request_Data.verification_State == "School")
                {
                    schlsrch += " and verification_State = 'School'";
                }
                if (Request_Data.verification_State == "Anganwadi")
                {
                    schlsrch += " and verification_State = 'Anganwadi'";
                }
                if (Request_Data.fromDate != null && Request_Data.toDate != null)
                {
                    schlsrch += " and Installation_date >= '" + Request_Data.fromDate + "' AND Installation_date<= '" + Request_Data.toDate + "'";
                }
                schlsrch += " and Status='A' and Survey_apporve='Approve'";

                ds = objdb.GetDataSet(schlsrch, ref hasExceptionThrown, ref errorMessage);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Survey_Master vm = new Survey_Master();
                        vm.X = ds.Tables[0].Rows[i]["lati"].ToString();
                        vm.Y = ds.Tables[0].Rows[i]["longi"].ToString();
                        vm.Ssurvey_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Ssurvey_id"].ToString());
                        vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                        vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id ='" + vm.District_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var blk_id = ds.Tables[0].Rows[i]["Block_id"].ToString();
                        vm.Block_name = objdb.GetSingleValue("select Block_name from block_master where Block_id='" + blk_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var pac_id = ds.Tables[0].Rows[i]["Panchayat_id"].ToString();
                        vm.Panchayat_name = objdb.GetSingleValue("select Panchayat_name from panchayat_master where Panchayat_id='" + pac_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var vlg_id = ds.Tables[0].Rows[i]["Village_id"].ToString();
                        vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id='" + vlg_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var schl_id = Convert.ToInt32(ds.Tables[0].Rows[i]["School_id"].ToString());
                        if (schl_id != 0)
                        {
                            vm.School_id = schl_id;
                            vm.School_name = objdb.GetSingleValue("select School_name from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                            vm.school_Code = objdb.GetSingleValue("select School_code from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        var anganwd_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Anganwadi_id"].ToString());
                        if (anganwd_id != 0)
                        {
                            vm.anganwadi_ID = anganwd_id;
                            vm.Anganwadi_name = objdb.GetSingleValue("select Anganwadi_name from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                            vm.anganwadi_Centre = objdb.GetSingleValue("select Anganwadi_building from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        vm.dateOfInstallation = ds.Tables[0].Rows[i]["Installation_date"].ToString();
                        vm.Electricity_Avail = ds.Tables[0].Rows[i]["Electricity_Avail"].ToString();
                        vm.HP_Avail = ds.Tables[0].Rows[i]["HP_Avail"].ToString();
                        vm.PipeWater_Avail = ds.Tables[0].Rows[i]["PipeWater_Avail"].ToString();
                        vm.Implmnt_agency = ds.Tables[0].Rows[i]["Implmnt_agency"].ToString();
                        vm.Supply_scheme = ds.Tables[0].Rows[i]["Supply_scheme"].ToString();
                        vm.BoreWell1_WorkDone = ds.Tables[0].Rows[i]["BoreWell1_WorkDone"].ToString();
                        if (vm.BoreWell1_WorkDone == "YES")
                        {
                            vm.BoreWell1_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BoreWell1_Workmanship"].ToString());
                            vm.Providing_BoreWell1 = Workmanshipnam(vm.BoreWell1_Workmanship);
                        }
                        vm.Cpvc_Pipe2_WorkDone = ds.Tables[0].Rows[i]["Cpvc_Pipe2_WorkDone"].ToString();
                        if (vm.Cpvc_Pipe2_WorkDone == "YES")
                        {
                            vm.Cpvc_Pipe2_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["Cpvc_Pipe2_Workmanship"].ToString());
                            vm.Cpvc_Pipe2 = Workmanshipnam(vm.Cpvc_Pipe2_Workmanship);
                        }
                        vm.BrassLong3_WorkDone = ds.Tables[0].Rows[i]["BrassLong3_WorkDone"].ToString();
                        if (vm.BrassLong3_WorkDone == "YES")
                        {
                            vm.BrassLong3_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BrassLong3_Workmanship"].ToString());
                            vm.Providing_BrassLongnose3 = Workmanshipnam(vm.BrassLong3_Workmanship);
                        }
                        vm.CpvcBallValve4_WorkDone = ds.Tables[0].Rows[i]["CpvcBallValve4_WorkDone"].ToString();
                        if (vm.CpvcBallValve4_WorkDone == "YES")
                        {
                            vm.CpvcBallValve4_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["CpvcBallValve4_Workmanship"].ToString());
                            vm.Providing_Cpvc_BallValve4 = Workmanshipnam(vm.CpvcBallValve4_Workmanship);
                        }
                        vm.StorageTank5_WorkDone = ds.Tables[0].Rows[i]["StorageTank5_WorkDone"].ToString();
                        if (vm.StorageTank5_WorkDone == "YES")
                        {
                            vm.StorageTank5_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["StorageTank5_Workmanship"].ToString());
                            vm.Providing_StorageTank5 = Workmanshipnam(vm.StorageTank5_Workmanship);
                        }
                        vm.HandPump6_WorkDone = ds.Tables[0].Rows[i]["HandPump6_WorkDone"].ToString();
                        if (vm.HandPump6_WorkDone == "YES")
                        {
                            vm.HandPump6_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["HandPump6_Workmanship"].ToString());
                            vm.Providing_HandPump6 = Workmanshipnam(vm.HandPump6_Workmanship);
                        }
                        vm.Overall_Scheme = ds.Tables[0].Rows[i]["Overall_Scheme"].ToString();
                        vm.Overall_remark = ds.Tables[0].Rows[i]["Overall_remark"].ToString();
                        string workmanship = "";
                        if (vm.BoreWell1_Workmanship == 0 || vm.Cpvc_Pipe2_Workmanship == 0 || vm.BrassLong3_Workmanship == 0 || vm.CpvcBallValve4_Workmanship == 0 || vm.StorageTank5_Workmanship == 0 || vm.HandPump6_Workmanship == 0)
                        {
                            if (vm.Overall_Scheme == "Non Operational") { workmanship = ""; } else { workmanship = Workmanshipnam(5); }
                        }
                        else if (vm.BoreWell1_Workmanship > 4 || vm.Cpvc_Pipe2_Workmanship > 4 || vm.BrassLong3_Workmanship > 4 || vm.CpvcBallValve4_Workmanship > 4 || vm.StorageTank5_Workmanship > 4 || vm.HandPump6_Workmanship > 4)
                        {
                            workmanship = Workmanshipnam(5);
                        }
                        else if (vm.BoreWell1_Workmanship > 3 || vm.Cpvc_Pipe2_Workmanship > 3 || vm.BrassLong3_Workmanship > 3 || vm.CpvcBallValve4_Workmanship > 3 || vm.StorageTank5_Workmanship > 3 || vm.HandPump6_Workmanship > 3)
                        {
                            workmanship = Workmanshipnam(4);
                        }
                        else if (vm.BoreWell1_Workmanship > 2 || vm.Cpvc_Pipe2_Workmanship > 2 || vm.BrassLong3_Workmanship > 2 || vm.CpvcBallValve4_Workmanship > 2 || vm.StorageTank5_Workmanship > 2 || vm.HandPump6_Workmanship > 2)
                        {
                            workmanship = Workmanshipnam(3);
                        }
                        else if (vm.BoreWell1_Workmanship > 1 || vm.Cpvc_Pipe2_Workmanship > 1 || vm.BrassLong3_Workmanship > 1 || vm.CpvcBallValve4_Workmanship > 1 || vm.StorageTank5_Workmanship > 1 || vm.HandPump6_Workmanship > 1)
                        {
                            workmanship = Workmanshipnam(2);
                        }
                        else if (vm.BoreWell1_Workmanship == 1 || vm.Cpvc_Pipe2_Workmanship == 1 || vm.BrassLong3_Workmanship == 1 || vm.CpvcBallValve4_Workmanship == 1 || vm.StorageTank5_Workmanship == 1 || vm.HandPump6_Workmanship == 1)
                        {
                            workmanship = Workmanshipnam(1);
                        }
                        vm.Work_boq = vm.Overall_Scheme + " - " + workmanship;
                        Report_list.Add(vm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Report_list;
        }
        public List<Survey_Master> Survey_Reports(Survey_Master Request_Data)
        {
            List<Survey_Master> Survey_list = new List<Survey_Master>();
            try
            {
                var District_id = Convert.ToInt32(Request_Data.District_id);
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var Village_id = Convert.ToInt32(Request_Data.Village_id);
                var verif_State = Request_Data.verification_State;
                var fromdate = Request_Data.fromDate;
                var todate = Request_Data.toDate;
                DataSet ds = new DataSet();

                string schlsrch = "Select * from school_survey where ";
                if (Request_Data.District_id != 0)
                {
                    schlsrch += "District_id = '" + Request_Data.District_id + "'";
                }
                if (Request_Data.Block_id != 0)
                {
                    schlsrch += " and Block_id = '" + Request_Data.Block_id + "'";
                }
                if (Request_Data.Village_id != 0)
                {
                    schlsrch += " and Village_id = '" + Request_Data.Village_id + "'";
                }
                if (Request_Data.fromDate != null && Request_Data.toDate != null)
                {
                    schlsrch += " and Installation_date >= '" + Request_Data.fromDate + "' AND Installation_date<= '" + Request_Data.toDate + "'";
                }
                schlsrch += " and Status='A' and Survey_apporve='Approve'";

                ds = objdb.GetDataSet(schlsrch, ref hasExceptionThrown, ref errorMessage);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Survey_Master vm = new Survey_Master();
                        vm.Ssurvey_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Ssurvey_id"].ToString());
                        vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                        vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id ='" + vm.District_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var blk_id = ds.Tables[0].Rows[i]["Block_id"].ToString();
                        vm.Block_name = objdb.GetSingleValue("select Block_name from block_master where Block_id='" + blk_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var vlg_id = ds.Tables[0].Rows[i]["Village_id"].ToString();
                        vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id='" + vlg_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var schl_id = ds.Tables[0].Rows[i]["School_id"].ToString();
                        if (schl_id != null && schl_id != "")
                        {
                            vm.School_id = Convert.ToInt32(schl_id);
                            vm.School_name = objdb.GetSingleValue("select School_name from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        var anganwd_id = ds.Tables[0].Rows[i]["Anganwadi_id"].ToString();
                        if (anganwd_id != null && anganwd_id != "")
                        {
                            vm.anganwadi_ID = Convert.ToInt32(anganwd_id);
                            vm.Anganwadi_name = objdb.GetSingleValue("select Anganwadi_name from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        vm.dateOfInstallation = ds.Tables[0].Rows[i]["Installation_date"].ToString();
                        vm.Electricity_Avail = ds.Tables[0].Rows[i]["Electricity_Avail"].ToString();
                        vm.HP_Avail = ds.Tables[0].Rows[i]["HP_Avail"].ToString();
                        vm.PipeWater_Avail = ds.Tables[0].Rows[i]["PipeWater_Avail"].ToString();
                        vm.Implmnt_agency = ds.Tables[0].Rows[i]["Implmnt_agency"].ToString();
                        vm.Supply_scheme = ds.Tables[0].Rows[i]["Supply_scheme"].ToString();
                        vm.BoreWell1_WorkDone = ds.Tables[0].Rows[i]["BoreWell1_WorkDone"].ToString();
                        if (vm.BoreWell1_WorkDone == "YES")
                        {
                            vm.BoreWell1_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BoreWell1_Workmanship"].ToString());
                            vm.Providing_BoreWell1 = Workmanshipnam(vm.BoreWell1_Workmanship);
                        }
                        vm.Cpvc_Pipe2_WorkDone = ds.Tables[0].Rows[i]["Cpvc_Pipe2_WorkDone"].ToString();
                        if (vm.Cpvc_Pipe2_WorkDone == "YES")
                        {
                            vm.Cpvc_Pipe2_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["Cpvc_Pipe2_Workmanship"].ToString());
                            vm.Cpvc_Pipe2 = Workmanshipnam(vm.Cpvc_Pipe2_Workmanship);
                        }
                        vm.BrassLong3_WorkDone = ds.Tables[0].Rows[i]["BrassLong3_WorkDone"].ToString();
                        if (vm.BrassLong3_WorkDone == "YES")
                        {
                            vm.BrassLong3_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["BrassLong3_Workmanship"].ToString());
                            vm.Providing_BrassLongnose3 = Workmanshipnam(vm.BrassLong3_Workmanship);
                        }
                        vm.CpvcBallValve4_WorkDone = ds.Tables[0].Rows[i]["CpvcBallValve4_WorkDone"].ToString();
                        if (vm.CpvcBallValve4_WorkDone == "YES")
                        {
                            vm.CpvcBallValve4_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["CpvcBallValve4_Workmanship"].ToString());
                            vm.Providing_Cpvc_BallValve4 = Workmanshipnam(vm.CpvcBallValve4_Workmanship);
                        }
                        vm.StorageTank5_WorkDone = ds.Tables[0].Rows[i]["StorageTank5_WorkDone"].ToString();
                        if (vm.StorageTank5_WorkDone == "YES")
                        {
                            vm.StorageTank5_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["StorageTank5_Workmanship"].ToString());
                            vm.Providing_StorageTank5 = Workmanshipnam(vm.StorageTank5_Workmanship);
                        }
                        vm.HandPump6_WorkDone = ds.Tables[0].Rows[i]["HandPump6_WorkDone"].ToString();
                        if (vm.HandPump6_WorkDone == "YES")
                        {
                            vm.HandPump6_Workmanship = Convert.ToInt32(ds.Tables[0].Rows[i]["HandPump6_Workmanship"].ToString());
                            vm.Providing_HandPump6 = Workmanshipnam(vm.HandPump6_Workmanship);
                        }
                        vm.Overall_Scheme = ds.Tables[0].Rows[i]["Overall_Scheme"].ToString();
                        vm.Overall_remark = ds.Tables[0].Rows[i]["Overall_remark"].ToString();
                        string workmanship = "";
                        if (vm.BoreWell1_Workmanship == 0 || vm.Cpvc_Pipe2_Workmanship == 0 || vm.BrassLong3_Workmanship == 0 || vm.CpvcBallValve4_Workmanship == 0 || vm.StorageTank5_Workmanship == 0 || vm.HandPump6_Workmanship == 0)
                        {
                            if (vm.Overall_Scheme == "Non Operational") { workmanship = ""; } else { workmanship = Workmanshipnam(5); }
                        }
                        else if (vm.BoreWell1_Workmanship > 4 || vm.Cpvc_Pipe2_Workmanship > 4 || vm.BrassLong3_Workmanship > 4 || vm.CpvcBallValve4_Workmanship > 4 || vm.StorageTank5_Workmanship > 4 || vm.HandPump6_Workmanship > 4)
                        {
                            workmanship = Workmanshipnam(5);
                        }
                        else if (vm.BoreWell1_Workmanship > 3 || vm.Cpvc_Pipe2_Workmanship > 3 || vm.BrassLong3_Workmanship > 3 || vm.CpvcBallValve4_Workmanship > 3 || vm.StorageTank5_Workmanship > 3 || vm.HandPump6_Workmanship > 3)
                        {
                            workmanship = Workmanshipnam(4);
                        }
                        else if (vm.BoreWell1_Workmanship > 2 || vm.Cpvc_Pipe2_Workmanship > 2 || vm.BrassLong3_Workmanship > 2 || vm.CpvcBallValve4_Workmanship > 2 || vm.StorageTank5_Workmanship > 2 || vm.HandPump6_Workmanship > 2)
                        {
                            workmanship = Workmanshipnam(3);
                        }
                        else if (vm.BoreWell1_Workmanship > 1 || vm.Cpvc_Pipe2_Workmanship > 1 || vm.BrassLong3_Workmanship > 1 || vm.CpvcBallValve4_Workmanship > 1 || vm.StorageTank5_Workmanship > 1 || vm.HandPump6_Workmanship > 1)
                        {
                            workmanship = Workmanshipnam(2);
                        }
                        else if (vm.BoreWell1_Workmanship == 1 || vm.Cpvc_Pipe2_Workmanship == 1 || vm.BrassLong3_Workmanship == 1 || vm.CpvcBallValve4_Workmanship == 1 || vm.StorageTank5_Workmanship == 1 || vm.HandPump6_Workmanship == 1)
                        {
                            workmanship = Workmanshipnam(1);
                        }
                        vm.photo_boreWell = ds.Tables[0].Rows[i]["photo_boreWell"].ToString();
                        vm.photo_handPump = ds.Tables[0].Rows[i]["photo_handPump"].ToString();
                        vm.photo_storageTank = ds.Tables[0].Rows[i]["photo_storageTank"].ToString();
                        vm.photo_overallStatus = ds.Tables[0].Rows[i]["photo_overallStatus"].ToString();
                        vm.Work_boq = vm.Overall_Scheme + " - " + workmanship;
                        vm.Survey_apporve = ds.Tables[0].Rows[i]["Survey_apporve"].ToString();
                        vm.Survey_remark = ds.Tables[0].Rows[i]["Survey_remark"].ToString();
                        Survey_list.Add(vm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Survey_list;
        }

        public List<Survey_Master> SchoolReport_N(Survey_Master Request_Data)
        {
            List<Survey_Master> Report_list = new List<Survey_Master>();
            try
            {
                var District_id = Convert.ToInt32(Request_Data.District_id);
                var Block_id = Convert.ToInt32(Request_Data.Block_id);
                var Village_id = Convert.ToInt32(Request_Data.Village_id);
                var verif_State = Request_Data.verification_State;
                var fromdate = Request_Data.fromDate;
                var todate = Request_Data.toDate;
                DataSet ds = new DataSet();

                string schlsrch = "Select * from school_survey where ";
                if (Request_Data.District_id != 0)
                {
                    schlsrch += "District_id = '" + Request_Data.District_id + "' and";
                }
                if (Request_Data.Block_id != 0)
                {
                    schlsrch += " Block_id = '" + Request_Data.Block_id + "' and";
                }
                if (Request_Data.Village_id != 0)
                {
                    schlsrch += " Village_id = '" + Request_Data.Village_id + "' and";
                }
                if (Request_Data.verification_State == "School")
                {
                    schlsrch += " verification_State = 'School' and";
                }
                if (Request_Data.verification_State == "Anganwadi")
                {
                    schlsrch += " verification_State = 'Anganwadi' and";
                }
                if (Request_Data.fromDate != null && Request_Data.toDate != null)
                {
                    schlsrch += " Installation_date >= '" + Request_Data.fromDate + "' AND Installation_date<= '" + Request_Data.toDate + "' and";
                }
                schlsrch += " Status='A' order by Created_date";

                ds = objdb.GetDataSet(schlsrch, ref hasExceptionThrown, ref errorMessage);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {                        
                        Survey_Master vm = new Survey_Master();
                        vm.Ssurvey_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Ssurvey_id"].ToString());
                        vm.District_id = Convert.ToInt32(ds.Tables[0].Rows[i]["District_id"].ToString());
                        vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id ='" + vm.District_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var blk_id = ds.Tables[0].Rows[i]["Block_id"].ToString();
                        vm.Block_name = objdb.GetSingleValue("select Block_name from block_master where Block_id='" + blk_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var pac_id = ds.Tables[0].Rows[i]["Panchayat_id"].ToString();
                        vm.Panchayat_name = objdb.GetSingleValue("select Panchayat_name from panchayat_master where Panchayat_id='" + pac_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var vlg_id = ds.Tables[0].Rows[i]["Village_id"].ToString();
                        vm.Village_name = objdb.GetSingleValue("select Village_name from village_master where Village_id='" + vlg_id + "'", ref hasExceptionThrown, ref errorMessage);
                        var schl_id = Convert.ToInt32(ds.Tables[0].Rows[i]["School_id"].ToString());
                        if (schl_id != 0)
                        {
                            vm.School_id = schl_id;
                            vm.School_name = objdb.GetSingleValue("select School_name from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                            vm.school_Code = objdb.GetSingleValue("select School_code from school_master where School_id='" + vm.School_id + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        var anganwd_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Anganwadi_id"].ToString());
                        if (anganwd_id != 0)
                        {
                            vm.anganwadi_ID = anganwd_id;
                            vm.Anganwadi_name = objdb.GetSingleValue("select Anganwadi_name from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                            vm.anganwadi_Centre = objdb.GetSingleValue("select Anganwadi_building from anganwadi_master where Anganwadi_id='" + vm.anganwadi_ID + "'", ref hasExceptionThrown, ref errorMessage);
                        }
                        vm.dateOfInstallation = ds.Tables[0].Rows[i]["Installation_date"].ToString();
                        vm.Electricity_Avail = ds.Tables[0].Rows[i]["Electricity_Avail"].ToString();
                        vm.HP_Avail = ds.Tables[0].Rows[i]["HP_Avail"].ToString();
                        vm.PipeWater_Avail = ds.Tables[0].Rows[i]["PipeWater_Avail"].ToString();
                        vm.Implmnt_agency = ds.Tables[0].Rows[i]["Implmnt_agency"].ToString();
                        vm.Supply_scheme = ds.Tables[0].Rows[i]["Supply_scheme"].ToString();
                        vm.Status= ds.Tables[0].Rows[i]["Survey_apporve"].ToString();
                        Report_list.Add(vm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Report_list;
        }


        public List<Survey_Master> Survey_Pending(Survey_Master Request_Data)
        {
            List<Survey_Master> Survey_list = new List<Survey_Master>();
            var District_id = Convert.ToInt32(Request_Data.District_id);
            var Block_id = Convert.ToInt32(Request_Data.Block_id);
            var verif_State = Request_Data.verification_State;
            try
            {
                DataSet ds1 = new DataSet();
                if (Block_id != 0)
                {
                    ds1 = objdb.GetDataSet("select * from block_master where Block_id= '" + Block_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                } else if (District_id != 0)
                {
                    ds1 = objdb.GetDataSet("select * from block_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int a = 0; a < ds1.Tables[0].Rows.Count; a++)
                    {
                        Survey_Master vm1 = new Survey_Master();
                        vm1.Block_id = Convert.ToInt32(ds1.Tables[0].Rows[a]["Block_id"].ToString());
                        vm1.Block_name = ds1.Tables[0].Rows[a]["Block_name"].ToString();
                        DataSet ds = new DataSet();                        
                        if (verif_State=="School")
                        {
                            if (vm1.Block_id != 0)
                            {
                                ds = objdb.GetDataSet("select * from school_master where Block_id= '" + vm1.Block_id + "' and School_status='0' and status='A'", ref hasExceptionThrown, ref errorMessage);
                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Survey_Master vm = new Survey_Master();
                                    vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                                    vm.Block_name = vm1.Block_name;
                                    vm.Panchayat_name = ds.Tables[0].Rows[i]["Panchayat_name"].ToString();
                                    vm.Village_name = objdb.GetSingleValue("select District_name from district_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                                    vm.School_name = ds.Tables[0].Rows[i]["School_name"].ToString();
                                    vm.school_Code = ds.Tables[0].Rows[i]["School_code"].ToString();
                                    vm.School_id = Convert.ToInt32(ds.Tables[0].Rows[i]["School_id"].ToString());
                                    vm.Survey_status = ds.Tables[0].Rows[i]["Survey_status"].ToString();
                                    Survey_list.Add(vm);
                                }
                            }
                        }
                        else if (verif_State == "Anganwadi")
                        {
                            if (vm1.Block_id != 0)
                            {
                                ds = objdb.GetDataSet("select * from anganwadi_master where Block_id= '" + vm1.Block_id + "' and Anganwadi_status='0' and status='A'", ref hasExceptionThrown, ref errorMessage);
                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Survey_Master vm = new Survey_Master();
                                    vm.District_name = objdb.GetSingleValue("select District_name from district_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                                    vm.Block_name = vm1.Block_name;
                                    vm.Panchayat_name = ds.Tables[0].Rows[i]["Panchayat_name"].ToString();
                                    vm.Village_name = objdb.GetSingleValue("select District_name from district_master where District_id= '" + District_id + "' and status='A'", ref hasExceptionThrown, ref errorMessage);
                                    vm.Anganwadi_name = ds.Tables[0].Rows[i]["Anganwadi_name"].ToString();
                                    vm.anganwadi_Centre = ds.Tables[0].Rows[i]["Anganwadi_building"].ToString();
                                    vm.anganwadi_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Anganwadi_id"].ToString());
                                    vm.Survey_status = ds.Tables[0].Rows[i]["Survey_status"].ToString();
                                    Survey_list.Add(vm);
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
            return Survey_list;            
        }

        public string Workmanshipnam(int workmanid)
        {
            string Workmannam;
            switch (workmanid)
            {
                case 1:
                    Workmannam = "Good";
                    break;
                case 2:
                    Workmannam = "Satisfactory";
                    break;
                case 3:
                    Workmannam = "Not upto the mark";
                    break;
                case 4:
                    Workmannam = "Poor";
                    break;
                case 5:
                    Workmannam = "Need to rework";
                    break;
                default:
                    Workmannam = "Workmanship";
                    break;
            }
            return Workmannam;
        }

    }
}