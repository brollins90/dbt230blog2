<%@ Page Title="Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="P.aspx.cs" Inherits="DBT230_blog.P" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: daPost.posttitle %></h2>
    <p><%: daPost.content %></p>
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
