using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using NPoco.FluentMappings;

namespace EventsCalendar.Repositories.NPoco
{
    /// <summary>
    /// NPoco Fluent Mapping for OSU.Portal.Model objects
    /// Decorates the POCOs for use with NPoco
    /// </summary>
    public partial class NPocoModelMappings : Mappings 
    {
        public NPocoModelMappings()
        {
        }
    }
}