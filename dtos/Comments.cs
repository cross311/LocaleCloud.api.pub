using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/comments", "GET", Summary = "Get all user and system comments meeting filters.")]
    [Route("/apps/{AppName}/tokens/{TokenName}/comments", "GET", Summary = "Get all user and system comments for token.")]
    public class Comments : IReturn<List<Comment>>
    {
        [ApiMember(Name = "AppName", Description = "Comment's app", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Comment's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "TokenName", Description = "Comment's token name", IsRequired = true, ParameterType = "path")]
        public string TokenName { get; set; }
    }

    [Route("/comments", "PUT", Summary = "Create user comment for token.")]
    [Route("/apps/{AppName}/tokens/{TokenName}/comments", "PUT", Summary = "Create user comment for token.")]
    public class CreateComment : IReturnVoid
    {
        [ApiMember(Name = "AppName", Description = "Comment's app", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Comment's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "TokenName", Description = "Comment's token name", IsRequired = true, ParameterType = "path")]
        public string TokenName { get; set; }

        [ApiMember(Name = "Text", Description = "Comment's comment text", IsRequired = true, ParameterType = "path")]
        public string Text { get; set; }
    }


    [Route("/comments/{CommentId}", "POST", Summary = "Update user comment.")]
    [Route("/comments/{CommentId}", "DELETE", Summary = "Delete user comment.")]
    [Route("/apps/{AppName}/tokens/{TokenName}/comments/{CommentId}", "POST", Summary = "Update user comment.")]
    [Route("/apps/{AppName}/tokens/{TokenName}/comments/{CommentId}", "DELETE", Summary = "Delete user comment.")]
    public class ModifyComment : IReturnVoid
    {
        [ApiMember(Name = "CommentId", Description = "Comment's id", IsRequired = true, ParameterType = "path")]
        public long CommentId { get; set; }

        [ApiMember(Name = "Text", Description = "Comment's comment text", IsRequired = true, ParameterType = "path", Verb="POST")]
        public string Text { get; set; }
    }
}
