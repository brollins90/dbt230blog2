<%@ Page Title="Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="P.aspx.cs" Inherits="DBT230_blog.P" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%
        if (daPost.poster.Equals(Context.User.Identity.Name))
        {
            %> 
    <p><a href='EditPost.aspx?id=<%: daPost.postid %>'>Edit Post</a></p> <%
        }
        string htmlPost = string.Format("<div class='wholepost'>" +
            "<h2>{0}</h2>" +
            "<div class='poster'>Post by {1} | {3:MM/dd/yyyy}</div>" +
            "<div class='postcontentp'>{2}</div>" +
            "</div><hr>",
            daPost.posttitle, daPost.poster, daPost.content, daPost.posttime);
        Response.Write(htmlPost);
         %>

    <p><a href='AddComment.aspx?id=<%: daPost.postid %>'>Add a comment</a></p>
    <p>
        <% foreach (CassandraBlogStuff.Comment current in comments)
          {
              string htmlComment = string.Format("<div class='commentsection'>" +
                  "<div class='commenter'>Comment by <strong>{0}</strong> | {1:MM/dd/yyyy}</div>" +
                  "<div class='commentcontent'>{2}</div>" +
                  "</div>",
                  current.poster, current.posttime, current.content);
              Response.Write(htmlComment);
              //Response.Write(string.Format("<p>{0} {1} {2}</p>", current.poster, current.content, current.posttime.LocalDateTime));
          }
                   %></p>
</asp:Content>
