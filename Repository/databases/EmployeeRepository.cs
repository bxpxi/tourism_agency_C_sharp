using System;
using System.Collections.Generic;
using System.Data;
using Domain;
using log4net;
using Repository.interfaces;

namespace Repository.databases
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(EmployeeRepository));

    public EmployeeRepository()
    {
        logger.Info("EmployeeRepository initialized");
    }

    public Employee FindById(int id)
    {
        logger.Info("Finding Employee By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM employees WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    string agencyName = result["agencyName"].ToString();
                    string password = result["password"].ToString();
                    Employee employee = new Employee(agencyName, password);
                    employee.Id = Convert.ToInt32(result["id"]);
                    return employee;
                }
            }
        }
        return null;
    }

    public IEnumerable<Employee> FindAll()
    {
        logger.Info("Finding All Employees");
        IDbConnection connection = JdbcUtils.getConnection();
        List<Employee> employees = new List<Employee>();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM employees";
            using (IDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    int id = Convert.ToInt32(result["id"]);
                    string clientName = result["agencyName"].ToString();
                    string password = result["password"].ToString();
                    Employee employee = new Employee(clientName, password);
                    employee.Id = id;
                    employees.Add(employee);
                }
            }
            
        }
        return employees;
    }

    public void Save(Employee employee)
    {
        logger.Info("Saving Employee");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO employees (agencyName, password) VALUES (@agencyName, @password)";
            IDataParameter agencyNameParameter = command.CreateParameter();
            agencyNameParameter.ParameterName = "@agencyName";
            agencyNameParameter.Value = employee.AgencyName;
            command.Parameters.Add(agencyNameParameter);
            IDataParameter passwordParameter = command.CreateParameter();
            passwordParameter.ParameterName = "@password";
            passwordParameter.Value = employee.Password;
            command.Parameters.Add(passwordParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Saved employees: " + result);
        }
    }

    public void Delete(int id)
    {
        logger.Info("Deleting Employee");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "DELETE FROM employees WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Deleted employees: " + result);
        }
    }

    public void Update(Employee employee)
    {
        logger.Info("Updating Employee");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "UPDATE employees SET agencyName = @agencyName, password = @password WHERE id = @id";
            IDataParameter agencyNameParameter = command.CreateParameter();
            agencyNameParameter.ParameterName = "@agencyName";
            agencyNameParameter.Value = employee.AgencyName;
            command.Parameters.Add(agencyNameParameter);
            IDataParameter passwordParameter = command.CreateParameter();
            passwordParameter.ParameterName = "@password";
            passwordParameter.Value = employee.Password;
            command.Parameters.Add(passwordParameter);
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = employee.Id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Updated employees: " + result);
        }
    }

    public Employee FindByAgencyNameAndPassword(string agencyName, string password)
    {
        logger.Info("Finding Employee By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM employees WHERE agencyName = @agencyName AND password = @password";
            IDataParameter agencyNameParameter = command.CreateParameter();
            agencyNameParameter.ParameterName = "@agencyName";
            agencyNameParameter.Value = agencyName;
            command.Parameters.Add(agencyNameParameter);
            IDataParameter passwordParameter = command.CreateParameter();
            passwordParameter.ParameterName = "@password";
            passwordParameter.Value = password;
            command.Parameters.Add(passwordParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    string agencyName1 = result["agencyName"].ToString();
                    string password1 = result["password"].ToString();
                    Employee employee = new Employee(agencyName1, password1);
                    employee.Id = Convert.ToInt32(result["id"]);
                    return employee;
                }
            }
        }
        return null;
    }
    }
}