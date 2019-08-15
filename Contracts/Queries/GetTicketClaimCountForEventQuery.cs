using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{

    /// <summary>
    /// Get Event Info As Well As Ticket Claim Count From TicketClaims Table
    /// </summary>
    public class GetTicketClaimCountForEventQuery : IQuery<List<Event>>
    {


    }

}
