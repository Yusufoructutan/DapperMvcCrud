using Dapper;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Repository
{
    public abstract class AbstractDapperRepository : IDisposable
    {
        #region Connection İşlemleri

        //Bunu koyduğumuz anda using.system.data kütüphanesini eklemek lazım
        public readonly IDbConnection DbConnection;


        protected AbstractDapperRepository()
        {

            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);

        }
        protected AbstractDapperRepository(string connectionName)
        {
            //web configden bizim connectionstring değerini alacak
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }

        protected AbstractDapperRepository(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;

        }

        #endregion


        #region Crud Operations

         public TEntity Insert<TEntity>(string sqlQuery,TEntity item) where TEntity : IDbModel
        {

            try
            {
                var result = DbConnection.ExecuteScalar(sqlQuery, item);
                item.SetId(result); 

            }

            catch (Exception ex) { 
                //todo Log
            }

            return item;

        }


        //sql Query'i çağırmak için where kısmını oluşturduk 
        public IEnumerable<TEntity> GetAll<TEntity>(string sqlQuery) where TEntity: IDbModel
        {

            try
            {
                return DbConnection.Query<TEntity>(sqlQuery).ToList();

            }
            catch (Exception ex)
            {

                //Todo Log

                return null;
            }

        }



        public IEnumerable<TEntity> GetById<TEntity>(string sqlQuery, object parameters) where TEntity : IDbModel
        {

            try
            {
               return  DbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            }
            catch (Exception ex)
            {
                //todo log
                return null;
        }

        }


        public  TEntity Update<TEntity>(string sqlQuery, TEntity item) where TEntity : IDbModel
        {

            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception ex)
            {
                // todolog

                
            }
            return item;
        }

 
        public void Delete<TEntity>(string sqlQuery,TEntity item) where TEntity : IDbModel
        {

            try
            {
                DbConnection.Execute(sqlQuery, item);

            }
            catch (Exception ex)
            {

                //todolog;
            }


            
        }




        #endregion


        #region Execute


        public void ExecuteNonQuery(string sqlQuery, object parameter)
        {
            try
            {
                DbConnection.Execute(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                //todo log
            }
        }


        public void ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                DbConnection.Execute(sqlQuery);
            }
            catch (Exception ex)
            {
                //todo log
            }
        }


        public int Execute(string sqlQuery,object parameter)
        {
            try
            {
                return DbConnection.ExecuteScalar<int>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {

                //todolog
                return 0;
            }
        }

        public object Execute<T>(string sqlQuery,object parameter)
        {
            try
            {
                return DbConnection.ExecuteScalar<T>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                //todolog
                return null;
            }
        }





        #endregion


        #region Dispose işlemleri 
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbConnection?.Dispose();
            }
        }
        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);


        }
        #endregion
    }
}
