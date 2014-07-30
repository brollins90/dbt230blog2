<%@ Page Title="Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="P.aspx.cs" Inherits="DBT230_blog.P" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: daPost.posttitle %></h2>
    <p><%: daPost.content %></p>
    <p><a href='AddComment.aspx?id=<%: daPost.postid %>'>Add a comment</a></p>
    <p>
        <% foreach (CassandraBlogStuff.Comment current in comments)
          {
              Response.Write(string.Format("<p>{0} {1} {2}</p>", current.poster, current.content, current.posttime));
          }
                   %></p>
</asp:Content>
