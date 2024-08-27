using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SqlQuery
{
    public static class QueryWarehouse
    {
        //multiple Model için  => employe'den Farklı model olursa aşağıya ekle
        public static class Employee
        {
            public static String Insert => @"INSERT INTO EMPLOYEE(
                                            [FirstName]
                                            ,[LastName]
                                            ,[DateOfBirth]
                                            ,[StartDate]
                                            ,[Department]
                                            ,[PhoneNumber]
                                            ,[Email]
                                            ,[City])
                                               
                                                    VALUES
                                                
                                            (
                                                @FirstName,
                                                @LastName,
                                                @DateOfBirth,
                                                @StartDate,
                                                @Department,
                                                @PhoneNumber,
                                                @Email,
                                                @City
                                            )SELECT SCOPE_IDENTITY()";


            public static String Update => @"UPDATE EMPLOYEE SET
                                            [FirstName] =@FirstName
                                            ,[LastName]=@LastName
                                            ,[DateOfBirth]=@DateOfBirth
                                            ,[StartDate]=@StartDate
                                            ,[Department]=@Department
                                            ,[PhoneNumber]=@PhoneNumber
                                            ,[Email]=@Email
                                            ,[City]=@City
                                                WHERE    Id = @Id";

            public static String Delete => "DELETE FROM EMPLOYEE  WHERE Id =@Id";

            public static String GetAll => "SELECT * FROM EMPLOYEE WITH(NOLOCK)"; //DEADLOCK PROBLEM SOLVED

            public static String GetByID => "SELECT * FROM EMPLOYEE WITH(NOLOCK) WHERE Id = @Id";

        }



    }
}
