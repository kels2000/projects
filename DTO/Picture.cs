using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USFS.Domain.Me2U.DTO
{
    public class Picture
    {
        /// <summary>
        /// Database ID of Post 
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Url to the image for the Post
        /// </summary>
        public string PictureImagePath { get; set; }


        /// <summary>
        /// Database ID of Event 
        /// </summary>
        public int EventId { get; set; }

        //overloaded constructors

        public Picture(int postId, string pictureImagePath)
        {
            PostId = postId;
            PictureImagePath = pictureImagePath;
        }

        public Picture(int postId, string pictureImagePath, int eventId)
        {
            PostId = postId;
            PictureImagePath = pictureImagePath;
            EventId = eventId;
        }       
    }
}
