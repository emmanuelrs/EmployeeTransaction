﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;
using IsolationLevel = System.Transactions.IsolationLevel;
using System.Diagnostics;
using TransactionServiceInterfaces;

namespace TransactionDatabase
{
    public class EmployeeDatabase
    {
        private static List<Employee> employeeData = new List<Employee>();

        public List<Employee> employeeInfo = new List<Employee>();

        public void employeeRegistration(string employee_name)
        {
            
            /*ConnectionStringSettings cnSettings = ConfigurationManager.ConnectionStrings["transaction_system"];
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnSettings.ConnectionString;
                cn.Open();

                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadCommitted;
                option.Timeout = TimeSpan.FromMinutes(5);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    
                }
            }*/

        }

        public List<Employee> getEmployeeList()
        {

            if (!EventLog.SourceExists("EmployeesTransactions"))
            {
                EventLog.CreateEventSource("EmployeesTransactions", "MyNewLog");
            }
            EventLog myLog = new EventLog();
            myLog.Source = "EmployeesTransactions";

            Debug.Listeners.Add(new ConsoleTraceListener());
            Debug.Indent();
            Debug.WriteLine("Start Get Employee Info ");
            Debug.Unindent();


            ConnectionStringSettings cnSettings = ConfigurationManager.ConnectionStrings["transaction_system"];
            using (SqlConnection cn = new SqlConnection())
            {
                Debug.Assert(cn != null, "Conection cannot be null");

                cn.ConnectionString = cnSettings.ConnectionString;
                cn.Open();

                Debug.Indent();
                Debug.WriteLine("Connection Stablish succesfull");
                Debug.Unindent();

                SqlDataReader rdr = null;

                var option = new TransactionOptions();

                Debug.Assert(option != null, "Transaction cannot be null");
                
                option.IsolationLevel = IsolationLevel.ReadCommitted;
                option.Timeout = TimeSpan.FromMinutes(5);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    Debug.WriteLine("Transaction Scope started");
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("get_employee_info", cn))
                        {
                            Debug.Indent();
                            Debug.WriteLine("Execute Store Procedure");
                            Debug.Unindent();

                            cmd.CommandType = CommandType.StoredProcedure;
                            rdr = cmd.ExecuteReader();
                            Debug.Indent();
                            Debug.WriteLine("Procedure executed succesfull");
                            Debug.Unindent();

                            while (rdr.Read())
                            {
                                Employee emp = new Employee();
                                Debug.Indent();
                                Debug.WriteLine("Reading Results");
                                Debug.Unindent();
                                emp.employee_id = rdr["employee_id"].ToString();
                                emp.employee_name = rdr["employee_name"].ToString();
                                emp.employee_first_surname = rdr["employee_first_surname"].ToString();
                                emp.employee_second_surname = rdr["employee_second_surname"].ToString();
                                emp.employee_email = rdr["employee_email"].ToString();
                                emp.employee_username = rdr["employee_username"].ToString();
                                emp.employee_salary = rdr["employee_salary"].ToString();
                                employeeInfo.Add(emp);
                            }
                            rdr.Close();
                            Debug.Indent();
                            Debug.WriteLine("reader Closed");
                            Debug.Unindent();
                        }
                        scope.Complete();
                        Debug.Indent();
                        Debug.WriteLine("Transaction Completed");
                        Debug.Unindent();
                        return employeeInfo;

                    }
                    catch (Exception e)
                    {
                        myLog.WriteEntry("Could not connect", EventLogEntryType.Error, 1001, 1);

                        scope.Dispose();
                        MessageBox.Show(e.Message);

                    }

                }
            }
            Debug.WriteLine("Get Info function done");

            return employeeData;
        }
    }
}
