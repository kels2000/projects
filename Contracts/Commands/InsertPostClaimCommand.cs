using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    public class InsertPostClaimCommand : DefaultCommand
    {
        public PostClaim PostClaim { get; set; }

        public InsertPostClaimCommand(PostClaim postClaim)
        {
            PostClaim = postClaim;
        }
    }
}
