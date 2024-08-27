using EntityLayer.Interface;
using EntityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employee : IDbModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime StartDate { get; set; }

        public String Department { get; set; }

        public String PhoneNumber { get; set; }

        public String Email { get; set; }

        public String City { get; set; }



        public String FullNAme
        {
            get
            {
                return FirstName + "" + LastName;
            }

        }
        #region Implemente Operations

        public AbstractDapperRepository Repository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetId(object id)
        {
            try
            {
                Id = (int)id;
            }
            catch
            {

            }
        }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        }
        #endregion
    }
}
