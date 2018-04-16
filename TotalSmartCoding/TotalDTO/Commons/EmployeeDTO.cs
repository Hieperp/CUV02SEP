using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalBase.Enums;

namespace TotalDTO.Commons
{
    public interface IEmployeeBaseDTO
    {
        int EmployeeID { get; set; }
        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhân viên")]
        string Name { get; set; }
    }

    public class EmployeeBaseDTO : BaseDTO, IEmployeeBaseDTO
    {
        private int employeeID;
        [DefaultValue(0)]
        public int EmployeeID
        {
            get { return this.employeeID; }
            set { ApplyPropertyChange<EmployeeBaseDTO, int>(ref this.employeeID, o => o.EmployeeID, value); }
        }

        private string name;
        [DefaultValue(null)]
        public string Name
        {
            get { return this.name; }
            set { ApplyPropertyChange<EmployeeBaseDTO, string>(ref this.name, o => o.Name, value); }
        }
    }

    public class EmployeePrimitiveDTO : EmployeeBaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.Employee; } }

        public override int GetID() { return this.EmployeeID; }
        public void SetID(int id) { this.EmployeeID = id; }

        private string code;
        [DefaultValue(null)]
        public string Code
        {
            get { return this.code; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, string>(ref this.code, o => o.Code, value); }
        }

        private Nullable<int> teamID;
        [DefaultValue(null)]
        public Nullable<int> TeamID
        {
            get { return this.teamID; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, Nullable<int>>(ref this.teamID, o => o.TeamID, value); }
        }

        private string title;
        [DefaultValue(null)]
        public string Title
        {
            get { return this.title; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, string>(ref this.title, o => o.Title, value); }
        }

        private DateTime? birthday;
        public DateTime? Birthday
        {
            get { return this.birthday; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, DateTime?>(ref this.birthday, o => o.Birthday, value); }
        }

        private string telephone;
        [DefaultValue(null)]
        public string Telephone
        {
            get { return this.telephone; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, string>(ref this.telephone, o => o.Telephone, value); }
        }

        private string address;
        [DefaultValue(null)]
        public string Address
        {
            get { return this.address; }
            set { ApplyPropertyChange<EmployeePrimitiveDTO, string>(ref this.address, o => o.Address, value); }
        }

        [DefaultValue(null)]
        public string EmployeeRoleIDs { get; set; }

        [DefaultValue(null)]
        public string EmployeeLocationIDs { get; set; }
    }

    public class EmployeeDTO : EmployeePrimitiveDTO
    {
    }
}
