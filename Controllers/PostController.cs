#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostController.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc.
// 
//     Copyright in the application source code, and in the information and
//     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
//     unless otherwise indicated.
// 
//     You shall not remove or obscure any copyright, trademark or other notices.
//     You may not copy, republish, redistribute, transmit, participate in the
//     transmission of, create derivatives of, alter edit or exploit in any
//     manner any material including by storage on retrieval systems, without the
//     express written permission of United Shore Financial Services LLC.
// </copyright>
//------------------------------------------------------------------------------------------

#endregion

namespace USFS.WebUI.Me2U.Controllers
{
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using USFS.Core;
    using USFS.Core.Command;
    using USFS.Core.Email;
    using USFS.Domain.Me2U.Constants;
    using USFS.Domain.Me2U.Contracts.Commands;
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.Domain.Me2U.DTO;
    using USFS.Domain.Me2U.Enumerations;
    using USFS.WebUI.Me2U.Constants;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;
    using Category = USFS.Domain.Me2U.DTO.Category;

    /// <summary>
    /// Controller for the post view
    /// </summary>
    [Authorize]
    public class PostController : Controller
    {

        /// <summary>
        /// Instantiating the command bus
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// Instantiating the emailing service
        /// </summary>
        private readonly IEmailServices emailServices;

        /// <summary>
        /// the claims helper
        /// </summary>
        private readonly IClaimsHelper claimsHelper;

        /// <summary>
        /// the logging helper
        /// </summary>
        private readonly ILoggingHelper loggingHelper;

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog LOG = LogManager.GetLogger(typeof(Exception));

        /// <summary>
        /// Constructor for the post controller.
        /// </summary>
        /// <param name="commandBus">the command bus</param>
        /// <param name="emailServices">the service that handles emails</param>
        /// <param name="loggingHelper">the logging helper</param> 
        public PostController(ICommandBus commandBus, IEmailServices emailServices, IClaimsHelper claimsHelper, ILoggingHelper loggingHelper)
        {
            this.commandBus = commandBus;
            this.emailServices = emailServices;
            this.claimsHelper = claimsHelper;
            this.loggingHelper = loggingHelper;
        }

        /// <summary>
        /// The Index method for the post controller. 
        /// </summary>
        /// <param name="loginName">login name of the currently active user.</param>
        /// <returns>The Team Member Post View</returns>
        public ActionResult Index(string loginName)
        {
            PostModel model = new PostModel();
            List<PostPreview> postPreviewList = new List<PostPreview>();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            for (int i = 1; i <= 8; i++)
            {
                Category current = new Category(i);
                GetAllPostsForCategoryQuery carouselQuery = new GetAllPostsForCategoryQuery(current);
                IEnumerable<PostPreview> postList = commandBus.ProcessQuery(carouselQuery);
                foreach (PostPreview post in postList)
                {
                    post.CategoryId = i;
                    postPreviewList.Add(post);
                }
            }
            model.PostPreviews = postPreviewList;

            return View(ViewNames.TeamMemberPostHome, model);
        }

        /// <summary>
        /// Method that grabs all the posts when the user clicks on a category link.
        /// </summary>
        /// <param name="categoryId">The category id of posts to find.</param>    
        /// <returns>The Post Index View</returns>
        public ActionResult GetPostsForCategory(int categoryId)
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllPostsForCategoryQuery postQuery = new GetAllPostsForCategoryQuery(new Category(categoryId));
            model.AllPostsForCategory = commandBus.ProcessQuery(postQuery);

            model.CategoryTitle = Enumeration.TryFindById<CategoryEnum>(categoryId).DisplayValue;

            return View(ViewNames.PostIndex, model);
        }

        /// <summary>
        /// Method that grabs all the posts when the user clicks on a category link.
        /// </summary>
        /// <param name="categoryId">the identification number of a category of posts</param>
        /// <returns>The Post Index View</returns>
        public ActionResult GetItemRequestPostsForCategory(int categoryId)
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllItemRequestPostsForCategoryQuery postQuery = new GetAllItemRequestPostsForCategoryQuery(new Category(categoryId));
            model.AllPostsForCategory = commandBus.ProcessQuery(postQuery);

            model.CategoryTitle = Enumeration.TryFindById<CategoryEnum>(categoryId).DisplayValue;

            return View(ViewNames.PostIndex, model);
        }

        /// <summary>
        /// Gets all of the posts that have a type id of 'request an item'
        /// </summary>
        /// <returns>a view of all the item request post previews.</returns>
        public ActionResult GetAllItemRequestPosts()
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllItemRequestPostsQuery postQuery = new GetAllItemRequestPostsQuery();
            model.AllPostsForCategory = commandBus.ProcessQuery(postQuery);

            model.CategoryTitle = "All Item Requests";

            return View(ViewNames.PostIndex, model);
        }

        /// <summary>
        /// Method that grabs the post and shows all the relevant details on the post details page.
        /// </summary>
        /// <param name="postId">the id of the post to get the details of.</param>
        /// <returns>The Post Details View</returns>
        public ActionResult PostDetails(int postId)
        {
            PostModel model = new PostModel();

            GetPostByPostIdQuery query = new GetPostByPostIdQuery(postId);
            model.Post = commandBus.ProcessQuery(query);
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            if (model.Post.PostStatus == 1)
            {
                model.Post.SetPostPictures(new List<string>());

                SelectPicturesForPostQuery pictureQuery = new SelectPicturesForPostQuery(postId);
                List<Picture> pictures = commandBus.ProcessQuery(pictureQuery);

                foreach (Picture picture in pictures)
                {
                    model.Post.Pictures.Add(GetBaseImage(picture.PictureImagePath));
                }

                return View(ViewNames.PostDetails, model);
            }

            return RedirectToAction("Index", "Post");
        }

        /// <summary>
        ///  Method for the create post page.
        /// </summary>
        /// <returns>The Create Post View</returns>
        public ActionResult CreatePost()
        {
            CreatePostModel model = new CreatePostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            model.ExpirationDate = DateTime.Now;
            return View(ViewNames.CreatePost, model);
        }

        /// <summary>
        /// Method for the edit post page.
        /// </summary>
        /// <param name="postId">the id of the post to edit.</param>
        /// <returns>The Create Post View</returns>
        public ActionResult EditPost(int postId)
        {
            CreatePostModel model = new CreatePostModel();
            Post itemPost = new Post();

            GetPostByPostIdQuery query = new GetPostByPostIdQuery(postId);
            itemPost = commandBus.ProcessQuery(query);
            model.PostId = itemPost.PostId;
            model.PostedBy = itemPost.PostedBy;
            model.PostPurpose = itemPost.PostPurpose;
            model.PostTitle = itemPost.PostTitle;
            model.PostDescription = itemPost.PostDescription;
            model.DatePosted = itemPost.DatePosted;
            model.PostStatus = itemPost.PostStatus;
            model.ExpirationDate = itemPost.ExpirationDate;
            model.CategoryId = itemPost.CategoryId;
            model.SubCategoryId = itemPost.SubCategoryId;
            model.Pictures = itemPost.Pictures;
            model.PostedByEmailAddress = itemPost.PostedByEmailAddress;
            model.TestPicturePaths = itemPost.TestPicturePaths;

            IEnumerable<SubCategoryEnum> subcategoryEnum = Enumeration.GetAll<SubCategoryEnum>().ToList();
            List<SubCategoryEnum> subCategoriesList = new List<SubCategoryEnum>();
            foreach (SubCategoryEnum subCat in Enumeration.GetAll<SubCategoryEnum>())
            {
                if (subCat.ParentId == model.CategoryId)
                {
                    subCategoriesList.Add(subCat);
                }
            }
            IEnumerable<SelectListItem> subcategoryList = subCategoriesList.Select(item => new SelectListItem()
            {
                Text = item.DisplayValue,
                Value = item.Id,
            });

            model.SubcategoryList = subcategoryList;

            if (claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity) == model.PostedBy)
            {
                SelectPicturesForPostQuery pictureQuery = new SelectPicturesForPostQuery(model.PostId);
                model.TestPicturePaths = commandBus.ProcessQuery(pictureQuery);
                model.Pictures = new List<string>();

                foreach (Picture picture in model.TestPicturePaths)
                {
                    model.Pictures.Add(GetBaseImage(picture.PictureImagePath));
                }

                return View(ViewNames.CreatePost, model);
            }

            return RedirectToAction("Index", "Post");
        }

        /// <summary>
        /// Method that redirects to the post details page after a post is created.
        /// </summary>
        /// <returns>The Post Details View</returns>
        public ActionResult RedirectToPost()
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);
            model.Post = commandBus.ProcessQuery(new GetLatestPostByUserQuery(model.UserLoginName));
            
            List<Picture> pictures = commandBus.ProcessQuery(new SelectPicturesForPostQuery(model.Post.PostId));
            model.Post.SetPostPictures(new List<string>());

            foreach (Picture picture in pictures)
            {
                model.Post.Pictures.Add(GetBaseImage(picture.PictureImagePath));
            }

            return View(ViewNames.PostDetails, model);
        }

        /// <summary>
        /// Method for claiming items.
        /// </summary>
        /// <param name="postId">the id of the post that is being claimed</param>
        /// <param name="postedBy">the individual who posted the item</param>
        /// <param name="postTitle">the title of the post</param>
        /// <param name="postEmail">the email of the individual who posted the item.</param>
        /// <param name="postPurpose">representation of what the pupose of the post is.</param>
        [HttpPost]
        public JsonResult ClaimItem(int postId, string postedBy, string postTitle, string postEmail, string postPurpose)
        {
            String[] jsonResult = new String[2];

            //Queries for the current user and their email address. - Chris
            SelectUserQuery currentUser = new SelectUserQuery(new CurrentUser(claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity)));
            CurrentUser user = commandBus.ProcessQuery(currentUser);

            SelectAllPostClaimsByUserWithinThirtyDaysQuery postQuery =
                new SelectAllPostClaimsByUserWithinThirtyDaysQuery(user.LoginName);
            List<PostClaim> returnedClaims = commandBus.ProcessQuery(postQuery);

            if (returnedClaims.Count >= 2 && postPurpose == PostPurposeEnum.ItemPost.Id)
            {
                jsonResult[0] = "False";
                jsonResult[1] = returnedClaims.OrderBy(x => x.DateClaimed).Select(x => x.DateClaimed).FirstOrDefault().AddDays(30).ToString("D");
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
            else
            {
                InsertPostClaimCommand command =
                    new InsertPostClaimCommand(
                        new PostClaim(postId, claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity), user.EmailAddress, DateTime.Now));
                commandBus.Execute(command);

                if (postPurpose == PostPurposeEnum.ItemPost.Id)
                {
                    //Query for the email template
                    GetEmailTemplateQuery query = new GetEmailTemplateQuery(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(1).DisplayValue));
                    EmailTemplate ClaimedEmail = commandBus.ProcessQuery(query);

                    //Replace the email body/subject with the correct parameters
                    ClaimedEmail.EmailBody = ClaimedEmail.EmailBody.Replace("@@PostOwner@@", postedBy);
                    ClaimedEmail.EmailBody = ClaimedEmail.EmailBody.Replace("@@FullName@@", user.FullName);
                    ClaimedEmail.EmailBody = ClaimedEmail.EmailBody.Replace("@@PostTitle@@", postTitle);
                    ClaimedEmail.EmailSubject = ClaimedEmail.EmailSubject.Replace("@@PostTitle@@", postTitle);

                    SendEmailCommand emailCommand = new SendEmailCommand(new Email(
                        Me2YouConstants.EmailProfile,
                        postEmail,
                        ClaimedEmail.EmailSubject,
                        ClaimedEmail.EmailBody));
                    commandBus.Execute(emailCommand);

                    //Query for the email template
                    GetEmailTemplateQuery claimerEmailQuery = new GetEmailTemplateQuery(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(2).DisplayValue));
                    EmailTemplate ClaimerEmail = commandBus.ProcessQuery(claimerEmailQuery);

                    //Replace the email body/subject with the correct parameters
                    ClaimerEmail.EmailBody = ClaimerEmail.EmailBody.Replace("@@PostOwner@@", postedBy);
                    ClaimerEmail.EmailBody = ClaimerEmail.EmailBody.Replace("@@PostTitle@@", postTitle);
                    ClaimerEmail.EmailSubject = ClaimerEmail.EmailSubject.Replace("@@PostTitle@@", postTitle);

                    SendEmailCommand claimerEmailCommand = new SendEmailCommand(new Email(
                        Me2YouConstants.EmailProfile,
                        user.EmailAddress,
                        ClaimerEmail.EmailSubject,
                        ClaimerEmail.EmailBody));
                    commandBus.Execute(claimerEmailCommand);
                }
                else if (postPurpose == PostPurposeEnum.ItemRequest.Id)
                {
                    //Query for the email template
                    GetEmailTemplateQuery postedItemRequestEmailQuery = new GetEmailTemplateQuery(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(5).DisplayValue));
                    EmailTemplate postedItemRequestEmail = commandBus.ProcessQuery(postedItemRequestEmailQuery);

                    postedItemRequestEmail.EmailBody = postedItemRequestEmail.EmailBody.Replace("@@PosterName@@", postedBy);
                    postedItemRequestEmail.EmailBody = postedItemRequestEmail.EmailBody.Replace("@@ClaimerName@@", user.FullName);
                    postedItemRequestEmail.EmailSubject = postedItemRequestEmail.EmailSubject.Replace("@@ItemTitle@@", postTitle);

                    SendEmailCommand postedItemRequestEmailCommand = new SendEmailCommand(new Email(
                    Me2YouConstants.EmailProfile,
                    postEmail,
                    postedItemRequestEmail.EmailSubject,
                    postedItemRequestEmail.EmailBody));
                    commandBus.Execute(postedItemRequestEmailCommand);

                    //Query for the email template
                    GetEmailTemplateQuery claimedItemRequestEmailQuery = new GetEmailTemplateQuery(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(6).DisplayValue));
                    EmailTemplate claimedItemRequestEmail = commandBus.ProcessQuery(claimedItemRequestEmailQuery);

                    claimedItemRequestEmail.EmailBody = claimedItemRequestEmail.EmailBody.Replace("@@PosterName@@", postedBy);
                    claimedItemRequestEmail.EmailSubject = claimedItemRequestEmail.EmailSubject.Replace("@@ItemTitle@@", postTitle);

                    SendEmailCommand claimedItemRequestEmailCommand = new SendEmailCommand(new Email(
                    Me2YouConstants.EmailProfile,
                    user.EmailAddress,
                    claimedItemRequestEmail.EmailSubject,
                    claimedItemRequestEmail.EmailBody));
                    commandBus.Execute(claimedItemRequestEmailCommand);
                }
                jsonResult[0] = "True";
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Method thats called when the user submits a post on the create post page.
        /// </summary>
        /// <param name="model">The model from the view.</param>
        /// <returns>A Post Object</returns>
        [HttpPost]
        public Post SubmitPost(CreatePostModel model)
        {
            //If statement to update the post if there is already one in the database.
            if (model.PostId != 0)
            {
                //converts the data into a post object.
                Post newPost = ConvertToPostWithPostId(model.PostPurpose, model.PostTitle, model.PostDescription,
                    model.ExpirationDate, model.PostStatus, model.SubCategoryId,
                    model.DatePosted, model.CategoryId, model.PostedBy, model.PostId);

                //command to update the post.
                UpdatePostCommand command = new UpdatePostCommand(newPost);
                commandBus.Execute(command);

                //grabs all images that were uploaded.
                List<String> updateImagePaths = ImagePathCreation();

                //inserts each image into the picture database.
                foreach (string path in updateImagePaths)
                {
                    InsertPictureCommand pictureCommand =
                        new InsertPictureCommand(new Picture(newPost.PostId, path));
                    commandBus.Execute(pictureCommand);
                }

                return newPost;
            }

            //converts the data into a post object.
            Post post = ConvertToPost(model.PostPurpose, model.PostTitle, model.PostDescription, model.ExpirationDate,
                model.PostStatus, model.SubCategoryId, model.DatePosted, model.CategoryId,
                model.PostedBy);
            InsertPostCommand postcommand = new InsertPostCommand(post);
            commandBus.Execute(postcommand, delegate (Post result) { post = result; });

            // grabs all images that were uploaded.
            List<String> imagePaths = ImagePathCreation();


            //inserts each image into the picture database.
            foreach (string path in imagePaths)
            {
                InsertPictureCommand command = new InsertPictureCommand(new Picture(post.PostId, path));
                commandBus.Execute(command);
            }
            return post;
        }

        /// <summary>
        /// method to convert a createPostModel to a post
        /// </summary>
        /// <param name="postTitle">the title of the item post</param>
        /// <param name="postDescription">the description of the item</param>
        /// <param name="expirationDate">the date in which the post expires</param>
        /// <param name="postStatus">the current status of the post (active/pending delivery/ etc)</param>
        /// <param name="subCategoryId">the id that identifies the sub-category of an item</param>
        /// <param name="datePosted">the date the item was posted</param>
        /// <param name="categoryId">the id that identifies the category of an item</param>
        /// <param name="postedBy">the individual who posted the item</param>
        /// <param name="postPurpose">the purpose of the post (item post/ item request)</param>
        /// <returns>A Post Object</returns>
        private Post ConvertToPost(string postPurpose, string postTitle, string postDescription, DateTime expirationDate, int postStatus, int subCategoryId, DateTime datePosted,
             int categoryId, string postedBy)
        {
            Post post = new Post(postPurpose, postTitle, postDescription, datePosted, subCategoryId, categoryId, expirationDate, postedBy, postStatus);
            return post;
        }

        /// <summary>
        /// method to convert a createPostModel to a post
        /// </summary>
        /// <param name="postTitle">the title of the item post</param>
        /// <param name="postDescription">the description of the item</param>
        /// <param name="expirationDate">the date in which the post expires</param>
        /// <param name="postStatus">the current status of the post (active/pending delivery/ etc)</param>
        /// <param name="subCategoryId">the id that identifies the sub-category of an item</param>
        /// <param name="datePosted">the date the item was posted</param>
        /// <param name="categoryId">the id that identifies the category of an item</param>
        /// <param name="postedBy">the individual who posted the item</param>
        /// <param name="postPurpose">the purpose of the post (item post/ item request)</param>
        /// <param name="postId">the id number of the post</param>
        /// <returns>A Post Object</returns>
        private Post ConvertToPostWithPostId(string postPurpose, string postTitle, string postDescription, DateTime expirationDate, int postStatus, int subCategoryId, DateTime datePosted,
             int categoryId, string postedBy, int postId)
        {
            Post post = new Post(postPurpose, postTitle, postDescription, postId, datePosted, subCategoryId, categoryId, expirationDate, postedBy, postStatus);
            return post;
        }

        /// <summary>
        /// Gets all subcategories when a parent category link is clicked.
        /// </summary>
        /// <param name="categoryId">the id of the parent category</param>
        /// <param name="subCategoryId">the id of a subcategory</param>
        /// <returns>The Post Index View</returns>
        public ActionResult GetSubCategoriesForLink(int categoryId, int subCategoryId)
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllPostsForSubCategoryQuery sQuery =
                new GetAllPostsForSubCategoryQuery(new Category(categoryId, subCategoryId));
            model.AllPostsForCategory = commandBus.ProcessQuery(sQuery);

            model.CategoryTitle = Enumeration.TryFindById<SubCategoryEnum>(subCategoryId).DisplayValue;

            return View(ViewNames.PostIndex, model);
        }

        /// <summary>
        /// method to get all subcategories for the sub category dropdown.
        /// </summary>
        /// <param name="categoryId">the id of the category to get all of the subcategories from.</param>
        /// <returns>A Json object of SubCategories</returns>
        public JsonResult GetSubCategories(int categoryId = 0)
        {
            List<SubCategoryEnum> subCategories = new List<SubCategoryEnum>();

            foreach (SubCategoryEnum subCat in Enumeration.GetAll<SubCategoryEnum>())
            {
                if (subCat.ParentId == categoryId)
                {
                    subCategories.Add(subCat);
                }
            }
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Marks a post as deliverd by changing its status
        /// </summary>
        /// <param name="postId">the id of the post to change the status of</param>
        /// <returns>true / false, true if the status is successfully changed, false if not.</returns>
        public JsonResult MarkPostAsDelivered(int postId)
        {
            ClaimsIdentity id = (ClaimsIdentity)User.Identity;
            //Queries for the current user and their email address. - Chris
            SelectUserQuery currentUser = new SelectUserQuery(new CurrentUser(id.Claims.ElementAt(0).Value));
            CurrentUser user = commandBus.ProcessQuery(currentUser);

            GetPostByPostIdQuery query = new GetPostByPostIdQuery(postId);
            Post newPost = commandBus.ProcessQuery(query);
            if (newPost.PostStatus != 2)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }

            UpdatePostToDeliveredCommand command = new UpdatePostToDeliveredCommand(new Post(postId), user.LoginName);
            commandBus.Execute(command);

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Changes the status of a post to active.
        /// </summary>
        /// <param name="postId">the id of the post to set to active status</param>
        /// <returns>fase if it is trying to change the status on a post that is not allowed, true if everything works ok</returns>
        public JsonResult RepostItem(int postId, DateTime expirationDate)
        {
            ClaimsIdentity id = (ClaimsIdentity)User.Identity;
            //Queries for the current user and their email address. - Chris
            SelectUserQuery currentUser = new SelectUserQuery(new CurrentUser(id.Claims.ElementAt(0).Value));
            CurrentUser user = commandBus.ProcessQuery(currentUser);

            GetPostByPostIdQuery query = new GetPostByPostIdQuery(postId);
            Post newPost = commandBus.ProcessQuery(query);
            if (newPost.PostStatus == 1 || newPost.PostStatus == 3 || newPost.PostStatus == 5)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }

            UpdatePostToActiveCommand command = new UpdatePostToActiveCommand(postId, expirationDate, user.LoginName);
            commandBus.Execute(command);

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        /// <param name="postId">the id of the post to delete</param>
        /// <returns>true/false, true if successfully deleted, false otherwise</returns>
        public JsonResult DeletePost(int postId)
        {
            //Queries for the current user and their email address. - Chris
            SelectUserQuery currentUser = new SelectUserQuery(new CurrentUser(claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity)));
            CurrentUser user = commandBus.ProcessQuery(currentUser);

            GetPostByPostIdQuery query = new GetPostByPostIdQuery(postId);
            Post newPost = commandBus.ProcessQuery(query);

            if (newPost.PostStatus == Convert.ToInt32(PostStatusEnum.Delivered.Id) || newPost.PostStatus == Convert.ToInt32(PostStatusEnum.PendingDelivery.Id))
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            RemovePostCommand command = new RemovePostCommand(new Post(postId), user.LoginName);
            commandBus.Execute(command);

            return Json("true", JsonRequestBehavior.AllowGet);
        }
        #region Picture Area

        /// <summary>
        /// Method to remove a photo from a post.
        /// </summary>
        /// <param name="postId">the id of the post to remove the image from</param>
        /// <param name="imagePath">filepath to the image</param>
        /// <param name="eventId">the id of the event that the post exists in.</param>
        /// <returns>a Json object of an image path</returns>
        public JsonResult RemovePhoto(int postId, string imagePath, int eventId)
        {
            List<Picture> updatedPhotos = new List<Picture>();

            RemovePhotoCommand command = new RemovePhotoCommand(new Picture(postId, imagePath, eventId));
            commandBus.Execute(command, delegate (List<Picture> result) { updatedPhotos = result; });

            return Json(updatedPhotos);
        }

        /// <summary>
        /// Converts the image into a base64string.
        /// </summary>
        /// <param name="imagePath">filepath to the image.</param>
        /// <returns>A picture turned into a base 64 string</returns>
        public static string GetBaseImage(string imagePath)
        {
            string imageBase64 = String.Empty;
            if (System.IO.File.Exists(imagePath))
            {
                using (FileStream file = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    if (bytes.Length > 0)
                    {
                        imageBase64 = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(bytes));
                    }

                }
            }
            return imageBase64;
        }

        /// <summary>
        /// Grabs all the pictures and gives them a unique filepath.
        /// </summary>
        /// <returns>A List Of Filepaths</returns>
        private List<string> ImagePathCreation()
        {

            List<String> listOfFiles = new List<String>();
            bool isSavedSuccessfully = true;
            try
            {
                if (Request.Files.Count > 0)
                {
                    foreach (string fileName in Request.Files)
                    {
                        //Save file content goes here                    
                        HttpPostedFileBase file = Request.Files[fileName];
                        var uniqueFilename = CreateGuid();

                        if (file != null && file.ContentLength > 0)
                        {

                            var filename = Path.GetFileName(file.FileName);

                            uniqueFilename += Path.GetExtension(filename);

                            string path = ImageHelper.GetPathFromConfig(uniqueFilename);

                            file.SaveAs(path);
                            listOfFiles.Add(path);
                        }

                    }
                }

            }
            catch (Exception exception)
            {
                isSavedSuccessfully = false;
                LOG.Error(exception.Message, exception);
            }

            if (isSavedSuccessfully)
            {
                return listOfFiles;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method to create a unique filename.
        /// </summary>
        /// <returns>a GUID</returns>
        private string CreateGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Replace("{", "").Replace("}", "");
        }
        #endregion
    }
}