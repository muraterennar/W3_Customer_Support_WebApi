using Core.Entities;
using Core.Security.Entities;
using Domain.Entities;
using System.Data.SqlClient;

namespace Persistence.Repositories.RepositoryMaps;

public class RepositoryMap : IRepositoryMap
{
    public Employee MapEmployeeFromDataReader(SqlDataReader reader)
    {

        return new Employee
        {
            EMPLOYEE_STATUS = reader["EMPLOYEE_STATUS"] != DBNull.Value ? Convert.ToBoolean(reader["EMPLOYEE_STATUS"]) : false,
            Id = reader["EMPLOYEE_ID"] != DBNull.Value ? Convert.ToInt32(reader["EMPLOYEE_ID"]) : 0,
            EMPAPP_ID = reader["EMPAPP_ID"] != DBNull.Value ? Convert.ToInt32(reader["EMPAPP_ID"]) : 0,
            MEMBER_CODE = reader["MEMBER_CODE"] != DBNull.Value ? reader["MEMBER_CODE"].ToString() : string.Empty,
            EMPLOYEE_USERNAME = reader["EMPLOYEE_USERNAME"] != DBNull.Value ? reader["EMPLOYEE_USERNAME"].ToString() : string.Empty,
            EMPLOYEE_PASSWORD = reader["EMPLOYEE_PASSWORD"] != DBNull.Value ? reader["EMPLOYEE_PASSWORD"].ToString() : string.Empty,
            EMPLOYEE_NO = reader["EMPLOYEE_NO"] != DBNull.Value ? reader["EMPLOYEE_NO"].ToString() : string.Empty,
            EMPLOYEE_NAME = reader["EMPLOYEE_NAME"] != DBNull.Value ? reader["EMPLOYEE_NAME"].ToString() : string.Empty,
            EMPLOYEE_SURNAME = reader["EMPLOYEE_SURNAME"] != DBNull.Value ? reader["EMPLOYEE_SURNAME"].ToString() : string.Empty,
            TASK = reader["TASK"] != DBNull.Value ? reader["TASK"].ToString() : string.Empty,
            EMPLOYEE_EMAIL = reader["EMPLOYEE_EMAIL"] != DBNull.Value ? reader["EMPLOYEE_EMAIL"].ToString() : string.Empty,
            __IMCAT_ID = reader["__IMCAT_ID"] != DBNull.Value ? Convert.ToInt32(reader["__IMCAT_ID"]) : 0,
            __IM = reader["__IM"] != DBNull.Value ? reader["__IM"].ToString() : string.Empty,
            __IMCAT2_ID = reader["__IMCAT2_ID"] != DBNull.Value ? Convert.ToInt32(reader["__IMCAT2_ID"]) : 0,
            __IM2 = reader["__IM2"] != DBNull.Value ? reader["__IM2"].ToString() : string.Empty,
            DIRECT_TELCODE = reader["DIRECT_TELCODE"] != DBNull.Value ? reader["DIRECT_TELCODE"].ToString() : string.Empty,
            DIRECT_TEL = reader["DIRECT_TEL"] != DBNull.Value ? reader["DIRECT_TEL"].ToString() : string.Empty,
            EXTENSION = reader["EXTENSION"] != DBNull.Value ? reader["EXTENSION"].ToString() : string.Empty,
            MOBILCODE = reader["MOBILCODE"] != DBNull.Value ? reader["MOBILCODE"].ToString() : string.Empty,
            MOBILTEL = reader["MOBILTEL"] != DBNull.Value ? reader["MOBILTEL"].ToString() : string.Empty,
            CORBUS_TEL = reader["CORBUS_TEL"] != DBNull.Value ? reader["CORBUS_TEL"].ToString() : string.Empty,
            PHOTO = reader["PHOTO"] != DBNull.Value ? reader["PHOTO"].ToString() : string.Empty, // Assuming photo is stored as a file path
            IS_AGENDA_OPEN = reader["IS_AGENDA_OPEN"] != DBNull.Value ? Convert.ToBoolean(reader["IS_AGENDA_OPEN"]) : false,
            PERIOD_ID = reader["PERIOD_ID"] != DBNull.Value ? Convert.ToInt32(reader["PERIOD_ID"]) : 0,
            COMPANY_ID = reader["COMPANY_ID"] != DBNull.Value ? Convert.ToInt32(reader["COMPANY_ID"]) : 0,
            IS_IP_CONTROL = reader["IS_IP_CONTROL"] != DBNull.Value ? Convert.ToBoolean(reader["IS_IP_CONTROL"]) : false,
            IP_ADDRESS = reader["IP_ADDRESS"] != DBNull.Value ? reader["IP_ADDRESS"].ToString() : string.Empty,
            COMPUTER_NAME = reader["COMPUTER_NAME"] != DBNull.Value ? reader["COMPUTER_NAME"].ToString() : string.Empty,
            GROUP_STARTDATE = reader["GROUP_STARTDATE"] != DBNull.Value ? Convert.ToDateTime(reader["GROUP_STARTDATE"]) : DateTime.MinValue,
            DYNAMIC_HIERARCHY = reader["DYNAMIC_HIERARCHY"] != DBNull.Value ? reader["DYNAMIC_HIERARCHY"].ToString() : string.Empty,
            DYNAMIC_HIERARCHY_ADD = reader["DYNAMIC_HIERARCHY_ADD"] != DBNull.Value ? reader["DYNAMIC_HIERARCHY_ADD"].ToString() : string.Empty,
            HIERARCHY = reader["HIERARCHY"] != DBNull.Value ? reader["HIERARCHY"].ToString() : string.Empty,
            OZEL_KOD = reader["OZEL_KOD"] != DBNull.Value ? reader["OZEL_KOD"].ToString() : string.Empty,
            RECORD_DATE = reader["RECORD_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["RECORD_DATE"]) : DateTime.MinValue,
            RECORD_EMP = reader["RECORD_EMP"] != DBNull.Value ? Convert.ToInt32(reader["RECORD_EMP"]) : 0,
            RECORD_IP = reader["RECORD_IP"] != DBNull.Value ? reader["RECORD_IP"].ToString() : string.Empty,
            UPDATE_DATE = reader["UPDATE_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["UPDATE_DATE"]) : DateTime.MinValue,
            UPDATE_EMP = reader["UPDATE_EMP"] != DBNull.Value ? Convert.ToInt32(reader["UPDATE_EMP"]) : 0,
            UPDATE_IP = reader["UPDATE_IP"] != DBNull.Value ? reader["UPDATE_IP"].ToString() : string.Empty,
            OZEL_KOD2 = reader["OZEL_KOD2"] != DBNull.Value ? reader["OZEL_KOD2"].ToString() : string.Empty,
            KIDEM_DATE = reader["KIDEM_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["KIDEM_DATE"]) : DateTime.MinValue,
            IZIN_DATE = reader["IZIN_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["IZIN_DATE"]) : DateTime.MinValue,
            IN_COMPANY_REASON_ID = reader["IN_COMPANY_REASON_ID"] != DBNull.Value ? Convert.ToInt32(reader["IN_COMPANY_REASON_ID"]) : 0,
            IS_CRITICAL = reader["IS_CRITICAL"] != DBNull.Value ? Convert.ToBoolean(reader["IS_CRITICAL"]) : false,
            PHOTO_SERVER_ID = reader["PHOTO_SERVER_ID"] != DBNull.Value ? Convert.ToInt32(reader["PHOTO_SERVER_ID"]) : 0,
            EXPIRY_DATE = reader["EXPIRY_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["EXPIRY_DATE"]) : DateTime.MinValue,
            EMPLOYEE_STAGE = reader["EMPLOYEE_STAGE"] != DBNull.Value ? Convert.ToInt32(reader["EMPLOYEE_STAGE"]) : 0,
            BIOGRAPHY = reader["BIOGRAPHY"] != DBNull.Value ? reader["BIOGRAPHY"].ToString() : string.Empty,
            WET_SIGNATURE = reader["WET_SIGNATURE"] != DBNull.Value ? reader["WET_SIGNATURE"].ToString() : string.Empty, // Assuming wet signature is stored as a file path
            PER_ASSIGN_ID = reader["PER_ASSIGN_ID"] != DBNull.Value ? Convert.ToInt32(reader["PER_ASSIGN_ID"]) : 0,
            IS_ACC_INFO = reader["IS_ACC_INFO"] != DBNull.Value ? Convert.ToBoolean(reader["IS_ACC_INFO"]) : false,
            IZIN_DAYS = reader["IZIN_DAYS"] != DBNull.Value ? Convert.ToSingle(reader["IZIN_DAYS"]) : 0f,
            OLD_SGK_DAYS = reader["OLD_SGK_DAYS"] != DBNull.Value ? Convert.ToInt32(reader["OLD_SGK_DAYS"]) : 0,
            EXT_OFFTIME_MINUTES = reader["EXT_OFFTIME_MINUTES"] != DBNull.Value ? Convert.ToInt32(reader["EXT_OFFTIME_MINUTES"]) : 0,
            EXT_OFFTIME_DATE = reader["EXT_OFFTIME_DATE"] != DBNull.Value ? Convert.ToDateTime(reader["EXT_OFFTIME_DATE"]) : DateTime.MinValue,
            EMPLOYEE_KEP_ADRESS = reader["EMPLOYEE_KEP_ADRESS"] != DBNull.Value ? reader["EMPLOYEE_KEP_ADRESS"].ToString() : string.Empty,
            WORKTIPS_OPEN = reader["WORKTIPS_OPEN"] != DBNull.Value ? Convert.ToBoolean(reader["WORKTIPS_OPEN"]) : false,
            EINS_POINT = reader["EINS_POINT"] != DBNull.Value ? Convert.ToSingle(reader["EINS_POINT"]) : 0f,
            BRUC_POINT = reader["BRUC_POINT"] != DBNull.Value ? Convert.ToSingle(reader["BRUC_POINT"]) : 0f,
            TEL_TYPE = reader["TEL_TYPE"] != DBNull.Value ? Convert.ToInt32(reader["TEL_TYPE"]) : 0,
            IS_VACCINE = reader["IS_VACCINE"] != DBNull.Value ? Convert.ToBoolean(reader["IS_VACCINE"]) : false,
            IS_COVID = reader["IS_COVID"] != DBNull.Value ? Convert.ToBoolean(reader["IS_COVID"]) : false
        };
    }

    public OperationClaim MapOperationClaimFromDataReader(SqlDataReader reader)
    {
        return new OperationClaim
        {
            Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
            Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty
        };
    }

    private void AddUserParameters(SqlCommand command, Employee user)
    {
        command.Parameters.AddWithValue("@EMPLOYEE_ID", user.Id);
        command.Parameters.AddWithValue("@RECORD_DATE", user.RECORD_DATE);
        command.Parameters.AddWithValue("@RECORD_EMP", user.RECORD_EMP);
        command.Parameters.AddWithValue("@RECORD_IP", user.RECORD_IP);
        command.Parameters.AddWithValue("@UPDATE_DATE", user.UPDATE_DATE);
        command.Parameters.AddWithValue("@UPDATE_EMP", user.UPDATE_EMP);
        command.Parameters.AddWithValue("@UPDATE_IP", user.UPDATE_IP);
        command.Parameters.AddWithValue("@EMPLOYEE_STATUS", user.EMPLOYEE_STATUS);
        command.Parameters.AddWithValue("@EMPAPP_ID", user.EMPAPP_ID);
        command.Parameters.AddWithValue("@MEMBER_CODE", user.MEMBER_CODE);
        command.Parameters.AddWithValue("@EMPLOYEE_USERNAME", user.EMPLOYEE_USERNAME);
        command.Parameters.AddWithValue("@EMPLOYEE_PASSWORD", user.EMPLOYEE_PASSWORD);
        command.Parameters.AddWithValue("@EMPLOYEE_NO", user.EMPLOYEE_NO);
        command.Parameters.AddWithValue("@EMPLOYEE_NAME", user.EMPLOYEE_NAME);
        command.Parameters.AddWithValue("@EMPLOYEE_SURNAME", user.EMPLOYEE_SURNAME);
        command.Parameters.AddWithValue("@TASK", user.TASK);
        command.Parameters.AddWithValue("@EMPLOYEE_EMAIL", user.EMPLOYEE_EMAIL);
        command.Parameters.AddWithValue("@__IMCAT_ID", user.__IMCAT_ID);
        command.Parameters.AddWithValue("@__IM", user.__IM);
        command.Parameters.AddWithValue("@__IMCAT2_ID", user.__IMCAT2_ID);
        command.Parameters.AddWithValue("@__IM2", user.__IM2);
        command.Parameters.AddWithValue("@DIRECT_TELCODE", user.DIRECT_TELCODE);
        command.Parameters.AddWithValue("@DIRECT_TEL", user.DIRECT_TEL);
        command.Parameters.AddWithValue("@EXTENSION", user.EXTENSION);
        command.Parameters.AddWithValue("@MOBILCODE", user.MOBILCODE);
        command.Parameters.AddWithValue("@MOBILTEL", user.MOBILTEL);
        command.Parameters.AddWithValue("@CORBUS_TEL", user.CORBUS_TEL);
        command.Parameters.AddWithValue("@PHOTO", user.PHOTO);
        command.Parameters.AddWithValue("@IS_AGENDA_OPEN", user.IS_AGENDA_OPEN);
        command.Parameters.AddWithValue("@PERIOD_ID", user.PERIOD_ID);
        command.Parameters.AddWithValue("@COMPANY_ID", user.COMPANY_ID);
        command.Parameters.AddWithValue("@IS_IP_CONTROL", user.IS_IP_CONTROL);
        command.Parameters.AddWithValue("@IP_ADDRESS", user.IP_ADDRESS);
        command.Parameters.AddWithValue("@COMPUTER_NAME", user.COMPUTER_NAME);
        command.Parameters.AddWithValue("@GROUP_STARTDATE", user.GROUP_STARTDATE);
        command.Parameters.AddWithValue("@DYNAMIC_HIERARCHY", user.DYNAMIC_HIERARCHY);
        command.Parameters.AddWithValue("@DYNAMIC_HIERARCHY_ADD", user.DYNAMIC_HIERARCHY_ADD);
        command.Parameters.AddWithValue("@HIERARCHY", user.HIERARCHY);
        command.Parameters.AddWithValue("@OZEL_KOD", user.OZEL_KOD);
        command.Parameters.AddWithValue("@OZEL_KOD2", user.OZEL_KOD2);
        command.Parameters.AddWithValue("@KIDEM_DATE", user.KIDEM_DATE);
        command.Parameters.AddWithValue("@IZIN_DATE", user.IZIN_DATE);
        command.Parameters.AddWithValue("@IN_COMPANY_REASON_ID", user.IN_COMPANY_REASON_ID);
        command.Parameters.AddWithValue("@IS_CRITICAL", user.IS_CRITICAL);
        command.Parameters.AddWithValue("@PHOTO_SERVER_ID", user.PHOTO_SERVER_ID);
        command.Parameters.AddWithValue("@EXPIRY_DATE", user.EXPIRY_DATE);
        command.Parameters.AddWithValue("@EMPLOYEE_STAGE", user.EMPLOYEE_STAGE);
        command.Parameters.AddWithValue("@BIOGRAPHY", user.BIOGRAPHY);
        command.Parameters.AddWithValue("@WET_SIGNATURE", user.WET_SIGNATURE);
        command.Parameters.AddWithValue("@PER_ASSIGN_ID", user.PER_ASSIGN_ID);
        command.Parameters.AddWithValue("@IS_ACC_INFO", user.IS_ACC_INFO);
        command.Parameters.AddWithValue("@IZIN_DAYS", user.IZIN_DAYS);
        command.Parameters.AddWithValue("@OLD_SGK_DAYS", user.OLD_SGK_DAYS);
        command.Parameters.AddWithValue("@EXT_OFFTIME_MINUTES", user.EXT_OFFTIME_MINUTES);
        command.Parameters.AddWithValue("@EXT_OFFTIME_DATE", user.EXT_OFFTIME_DATE);
        command.Parameters.AddWithValue("@EMPLOYEE_KEP_ADRESS", user.EMPLOYEE_KEP_ADRESS);
        command.Parameters.AddWithValue("@WORKTIPS_OPEN", user.WORKTIPS_OPEN);
        command.Parameters.AddWithValue("@EINS_POINT", user.EINS_POINT);
        command.Parameters.AddWithValue("@BRUC_POINT", user.BRUC_POINT);
        command.Parameters.AddWithValue("@TEL_TYPE", user.TEL_TYPE);
        command.Parameters.AddWithValue("@IS_VACCINE", user.IS_VACCINE);
        command.Parameters.AddWithValue("@IS_COVID", user.IS_COVID);
    }

    private void AddOperationClaimParameters(SqlCommand command, OperationClaim operationClaim)
    {
        command.Parameters.AddWithValue("@Name", operationClaim.Name);
        command.Parameters.AddWithValue("@CreatedDate", operationClaim.RECORD_DATE);
        command.Parameters.AddWithValue("@UpdatedDate", operationClaim.UPDATE_DATE ?? (object) DBNull.Value);
    }
}