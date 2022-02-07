using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Mul.Models;
using System.Data;
using Mul.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mul.Controllers
{
    public class SchoolSurveyController : Controller
    {       
        // GET: SchoolSurvey
        public ActionResult InvoiceUpload()
        {
            return View();
        }
        public ActionResult SurveyApprove()
        {
            return View();
        }
        public ActionResult SurveyApprove_A()
        {
            return View();
        }
        public ActionResult UpdatedSurvey()
        {
            return View();
        }
        public ActionResult SurveyReports_A()
        {
            return View();
        }
        public ActionResult SurveyReports_N()
        {
            return View();
        }
        public ActionResult SurveyReports()
        {
            return View();
        }
        public ActionResult SurveyDashboard()
        {
            return View();
        }
        public ActionResult SurveyPending()
        {
            return View();
        }
        public ActionResult getDistrictList()
        {
            List<VM_District> result = new SchoolReportService().District_list(Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getPanchayatList(VM_Panchayat Request_Data)
        {
            List<VM_Panchayat> result = new SchoolReportService().Panchayat_list(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getVillagetList(VM_Village Request_Data)
        {
            List<VM_Village> result = new SchoolReportService().Village_list(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSchoolList(Invoice_Upload Request_Data)
        {
            List<Invoice_Upload> result = new SchoolReportService().School_list(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }        
        public ActionResult Upload_invoice(Invoice_Upload Request_Data)
        {
            if (Request.Files.Count > 0)
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                string fname_path = "";
                for (int k = 0; k < files.Count; k++)
                {
                    HttpPostedFileBase file = files[k];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        string prepend = DateTime.Now.ToString("dd-MMM-yyyy");
                        fname = prepend + "_" + Request_Data.Invoice_no + file.FileName;
                    }
                    fname = Path.Combine(Server.MapPath("~/Files/"), fname);
                    file.SaveAs(fname);
                }
            }
            bool result = new SchoolReportService().InvoiceUploads(Request_Data, Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getInvoiceList()
        {
            List<Invoice_Upload> result = new SchoolReportService().Invoice_list(Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSurveyList(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().Survey_list(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ApprovSurvey(int School_id, string verification_State, string Survey_remark)
        {
            bool result = new SchoolReportService().Approval_Survey(School_id, verification_State, Survey_remark, Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RejectSurvey(int School_id, string verification_State, string Survey_remark)
        {
            bool result = new SchoolReportService().Reject_Survey(School_id, verification_State, Survey_remark, Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TochangeSurvey(int School_id, string verification_State, string Survey_remark)
        {
            bool result = new SchoolReportService().Tochange_Survey(School_id, verification_State, Survey_remark, Session["username"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getUpdatedSurveyList(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().UpdatSurvey_list(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSchoolReport_A(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().SchoolReport_A(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSurveyReports(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().Survey_Reports(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSchoolReport_N(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().SchoolReport_N(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSurveyPending(Survey_Master Request_Data)
        {
            List<Survey_Master> result = new SchoolReportService().Survey_Pending(Request_Data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //private void printpdf()
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
        //    pdfReport.RenderControl(hw);

        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    pdfDoc.AddHeader("this is header part ", "this is header content remeber spell");

        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();
        //}

        //protected void btnPDF_Click(object sender, EventArgs e)
        //{
        //    printpdf();

        //}
        //[HttpPost]
        //public FileResult Export(string GridHtml)
        //{
        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader sr = new StringReader(GridHtml);
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //        pdfDoc.Open();
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        return File(stream.ToArray(), "application/pdf", "Grid.pdf");
        //    }
        //}




    }
}