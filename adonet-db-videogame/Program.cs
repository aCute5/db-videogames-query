// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;


var connStr = "Data Source=localhost; Integrated Security = True";
SqlConnection conn = new SqlConnection(connStr);
try
{
 conn.Open();

}
catch
{

}


  
  
