using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                SELECT DepartmentId, DepartmentName FROM dbo.Department";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                }

                myCon.Close();
            }

            var departments = table.AsEnumerable().Select(row => new Department
            {
                DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                DepartmentName = Convert.ToString(row["DepartmentName"])
            }).ToList();

            return new JsonResult(departments);
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            string query = @"
                    insert into dbo.Department values 
                    ('" + dep.DepartmentName + @"')
                    ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                }

                myCon.Close();
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
                    update dbo.Department set 
                    DepartmentName= '" + dep.DepartmentName + @"'
                    Where DepartmentId =" + dep.DepartmentId + @"";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                }

                myCon.Close();
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Department
                    Where DepartmentId =" +id + @"";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                }

                myCon.Close();
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
