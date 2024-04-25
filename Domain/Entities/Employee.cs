using Core.Entities;

namespace Domain.Entities;

public class Employee:Entity<int>
{   
    // ***** This is inherited from Entity<int> *****
    //public int EMPLOYEE_ID { get; set; }
    //public DateTime RECORD_DATE { get; set; }
    //public int RECORD_EMP { get; set; }
    //public string RECORD_IP { get; set; }
    //public DateTime UPDATE_DATE { get; set; }
    //public int UPDATE_EMP { get; set; }
    //public string UPDATE_IP { get; set; }

    public bool EMPLOYEE_STATUS { get; set; }
    public int EMPAPP_ID { get; set; }
    public string MEMBER_CODE { get; set; }
    public string EMPLOYEE_USERNAME { get; set; }
    public string EMPLOYEE_PASSWORD { get; set; }
    public string EMPLOYEE_NO { get; set; }
    public string EMPLOYEE_NAME { get; set; }
    public string EMPLOYEE_SURNAME { get; set; }
    public string TASK { get; set; }
    public string EMPLOYEE_EMAIL { get; set; }
    public int __IMCAT_ID { get; set; }
    public string __IM { get; set; }
    public int __IMCAT2_ID { get; set; }
    public string __IM2 { get; set; }
    public string DIRECT_TELCODE { get; set; }
    public string DIRECT_TEL { get; set; }
    public string EXTENSION { get; set; }
    public string MOBILCODE { get; set; }
    public string MOBILTEL { get; set; }
    public string CORBUS_TEL { get; set; }
    public string PHOTO { get; set; } // Assuming photo is stored as a file path
    public bool IS_AGENDA_OPEN { get; set; }
    public int PERIOD_ID { get; set; }
    public int COMPANY_ID { get; set; }
    public bool IS_IP_CONTROL { get; set; }
    public string IP_ADDRESS { get; set; }
    public string COMPUTER_NAME { get; set; }
    public DateTime GROUP_STARTDATE { get; set; }
    public string DYNAMIC_HIERARCHY { get; set; }
    public string DYNAMIC_HIERARCHY_ADD { get; set; }
    public string HIERARCHY { get; set; }
    public string OZEL_KOD { get; set; }
    public string OZEL_KOD2 { get; set; }
    public DateTime KIDEM_DATE { get; set; }
    public DateTime IZIN_DATE { get; set; }
    public int IN_COMPANY_REASON_ID { get; set; }
    public bool IS_CRITICAL { get; set; }
    public int PHOTO_SERVER_ID { get; set; }
    public DateTime EXPIRY_DATE { get; set; }
    public int EMPLOYEE_STAGE { get; set; }
    public string BIOGRAPHY { get; set; }
    public string WET_SIGNATURE { get; set; } // Assuming wet signature is stored as a file path
    public int PER_ASSIGN_ID { get; set; }
    public bool IS_ACC_INFO { get; set; }
    public float IZIN_DAYS { get; set; }
    public int OLD_SGK_DAYS { get; set; }
    public int EXT_OFFTIME_MINUTES { get; set; }
    public DateTime EXT_OFFTIME_DATE { get; set; }
    public string EMPLOYEE_KEP_ADRESS { get; set; }
    public bool WORKTIPS_OPEN { get; set; }
    public float EINS_POINT { get; set; }
    public float BRUC_POINT { get; set; }
    public int TEL_TYPE { get; set; }
    public bool IS_VACCINE { get; set; }
    public bool IS_COVID { get; set; }
}