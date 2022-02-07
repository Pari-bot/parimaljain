using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mul.Models
{
    public class rawClearWtr
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public int NodeNo { get; set; }
        public int ChainageFrom { get; set; }
        public int ChainageTo { get; set; }
        public string dateOfInstallation { get; set; }
        public Double diameter_mtr { get; set; }
        public Double length_mtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public int subWork { get; set; }
        public int ExcavationCheck { get; set; }
        public int BackFillingCheck { get; set; }
        public int HydroTestingCheck { get; set; }
        public string remark { get; set; }
        public string location { get; set; }
        public string material { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<rawClearWtr> List { get; set; }

    }
    public class IntakeWell
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double bottomWidth { get; set; }
        public Double bottomWidthMtr { get; set; }
        public Double deptMtr { get; set; }
        public Double diaMtr { get; set; }
        public Double lengthMtr { get; set; }
        public Double topWidth { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string IntakeWellPhoto { get; set; }
        public int packageName { get; set; }
        public string intakeWellItemList { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<IntakeWell> List { get; set; }

    }
    public class connectingMain
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double deptMtr { get; set; }
        public Double diaMtr { get; set; }
        public Double lengthMtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string ConnectingMainPhoto { get; set; }
        public int packageName { get; set; }
        public int connectingMainItem { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<connectingMain> List { get; set; }

    }
    public class jackwell
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double deptMtr { get; set; }
        public Double diaMtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string isSelected { get; set; }
        public int jackWellItemList { get; set; }
        public string jackWellWellPhoto { get; set; }
        public int packageName { get; set; }
        public Double prgPercent { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<jackwell> List { get; set; }

    }
    public class approachBridge
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double heightMtr { get; set; }
        public Double diaMtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string file_attachment2 { get; set; }
        public string fileExtension2 { get; set; }
        public string file_attachment3 { get; set; }
        public string fileExtension3 { get; set; }
        public string file_attachment4 { get; set; }
        public string fileExtension4 { get; set; }
        public string file_attachment5 { get; set; }
        public string fileExtension5 { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string isSelected { get; set; }
        public int approachItems { get; set; }
        public int pier_floor_slab { get; set; }
        public int pier_gl { get; set; }
        public string Photo { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string video { get; set; }
        public int packageName { get; set; }
        public int pierItem { get; set; }        
        public Double prgPercent { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<approachBridge> List { get; set; }

    }
    public class clearWaterReservoir
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double breadthMtr { get; set; }
        public Double lengthMtr { get; set; }
        public Double deptMtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string clearWaterReservoirPhoto { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int clearWaterReservoirItemList { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<clearWaterReservoir> List { get; set; }

    }
    public class pumpHouse
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double breadthMtr { get; set; }
        public Double lengthMtr { get; set; }
        public Double deptMtr { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string pumpHousePhoto { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int pumpHouseItemList { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<pumpHouse> List { get; set; }

    }
    public class serviceReservoir
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double capacityKl { get; set; }
        public Double daiDepthContainer { get; set; }
        public Double staHeight { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string serviceReservoirPhoto { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int serviceReservoirItemList { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<serviceReservoir> List { get; set; }

    }
    public class ConstBoundary
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double height { get; set; }
        public Double length { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int boundaryItem { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<ConstBoundary> List { get; set; }

    }
    public class ConstWTP
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public Double capacity { get; set; }
        public Double height { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int wtpItem { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<ConstWTP> List { get; set; }

    }
    public class totalNoHouseServiceConn
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public int noOfConnection { get; set; }
        public Double height { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int totalNoOfHouseServiceConn { get; set; }
        public string remark { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string status { get; set; }
        public string versionName { get; set; }
        public List<totalNoHouseServiceConn> List { get; set; }

    }
    public class valveChamber
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public int nos { get; set; }
        public Double height { get; set; }
        public int quantity { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public int items { get; set; }
        public string location { get; set; }
        public int totalValveChamber { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public Double prgPercent { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<valveChamber> List { get; set; }
    }
    public class fireHydrant
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public int noOfFireHydrant { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int constructionOfFireHydrant     { get; set; }
        public string remark { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<fireHydrant> List { get; set; }
    }
    public class standPost
    {
        public Int64 uid { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public string dateOfInstallation { get; set; }
        public int noOfStandPost { get; set; }
        public string file_attachment { get; set; }
        public string fileExtension { get; set; }
        public string globalID { get; set; }
        public int id { get; set; }
        public string Photo { get; set; }
        public int packageName { get; set; }
        public string location { get; set; }
        public int constructionNoStandPost { get; set; }
        public string remark { get; set; }
        public string userName { get; set; }
        public string userLocation { get; set; }
        public string versionName { get; set; }
        public List<standPost> List { get; set; }
    }

    public class FileModel
    {
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public string filpath { get; set; }
    }

    public class Dashbard
    {
        public Int64 uid { get; set; }
        public string packageName { get; set; }
        public string status { get; set; }
        public List<Dashbard> List { get; set; }

    }
    public class packageDashboard
    {
        public Int64 uid { get; set; }
        public Int64 package_id { get; set; }
        public Int64 fromch { get; set; }
        public Int64 tochng { get; set; }
        public string excavation { get; set; }
        public string backfill { get; set; }
        public string hydrot { get; set; }
        public string status { get; set; }
        public List<packageDashboard> List { get; set; }

    }
    public class DashboardGet
    {
        public Int64 uid { get; set; }
        public int User_id { get; set; }
        public int Pack_id { get; set; }
        public string dashIcon { get; set; }
        public string MobuleName { get; set; }
        public string MobuleKey { get; set; }
        public string status { get; set; }
        public List<DashboardGet> List { get; set; }
    }

}