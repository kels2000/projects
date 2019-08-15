using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    public class InsertPictureCommand : DefaultCommand
    {
        public Picture Picture { get; set; }

        /// <summary>
        /// InsertPictureCommand constructor.
        /// </summary>
        /// <param name="picture"></param>

        public InsertPictureCommand(Picture picture)
        {
            Picture = picture;
        }

    }
}
