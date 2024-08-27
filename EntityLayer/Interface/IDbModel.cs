using EntityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Interface
{
    public interface  IDbModel
    {

        AbstractDapperRepository Repository { get; set; }


        void SetId(object id);


        void SetRepository(AbstractDapperRepository dapperRepository);




    }
}
